using Microsoft.Data.Sqlite;
using IncidentesAI.Model;
using IncidentesAI.Helpers;
using System.Runtime.InteropServices;


namespace IncidentesAI.Services;

/// <summary>
/// Serviço responsável por acessar e manipular dados de incidentes
/// armazenados em um banco SQLite. Fornece métodos para consulta,
/// filtragem, exclusão e preparação de contexto para IA.
/// </summary>

public class IncidenteDataService(string DbPath)
{
    private readonly string _connectionString;

    #region Métodos Públicos

    /// <summary>
    /// Obtém todos os incidentes do banco de dados, limitando a quantidade
    /// conforme o parâmetro informado.
    /// </summary>
    /// <param name="numeroIncidentesConsiderar">Número máximo de incidentes a retornar. Se 0, retorna todos.</param>
    /// <returns>Lista de objetos <see cref="Incidente"/> carregados do banco.</returns>
    public List<Incidente> ObterTodosIncidentes(int numeroIncidentesConsiderar)
    {
        var incidentes = new List<Incidente>();

        using var connection = DbUtils.OpenConnection(DbPath);

        connection.Open();

        string commandText = """
            SELECT 
                Id, 
                "Number", 
                AssignmentGroup, 
                State, 
                Caller, 
                AssignedTo, 
                Priority, 
                Created, 
                strftime('%d/%m/%Y %H:%M:%S', Created) AS CreatedFormatado,
                ShortDescription, 
                ConfigurationItem, 
                Email
            FROM 
                Incidentes
            ORDER BY 
                datetime(Created) DESC
        """;

        if (numeroIncidentesConsiderar > 0)
            commandText += $" LIMIT {numeroIncidentesConsiderar}";

        using var cmd = new SqliteCommand(commandText, connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            incidentes.Add(new Incidente
            {
                Id = reader.GetInt32(0),
                Number = reader[1] as string ?? string.Empty,
                AssignmentGroup = reader[2] as string ?? string.Empty,
                State = reader[3] as string ?? string.Empty,
                Caller = reader[4] as string ?? string.Empty,
                AssignedTo = reader[5] as string ?? string.Empty,
                Priority = reader[6] as string ?? string.Empty,
                Created = DateTime.TryParse(
                            reader[7]?.ToString(), 
                            out var dt) 
                        ? dt 
                        : DateTime.MinValue,
                CreatedFormatado = reader[8] as string ?? string.Empty,
                ShortDescription = reader[9] as string ?? string.Empty,
                ConfigurationItem = reader[10] as string ?? string.Empty,
                Email = reader[11] as string ?? string.Empty
            });
        }

        return incidentes;
    }

    /// <summary>
    /// Obtém a lista de status únicos presentes nos incidentes.
    /// </summary>
    /// <returns>Lista de strings com os status distintos.</returns>
    public List<string> ObterStatusUnicos()
    {
        var lista = new List<string>();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string cmdText = """
            SELECT 
                DISTINCT State 
            FROM 
                Incidentes 
            WHERE 
                State IS NOT NULL 
            ORDER BY 
                State ASC
            """;

        using var cmd = new SqliteCommand(cmdText, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read()) lista.Add(reader.GetString(0));

        return lista;
    }

    /// <summary>
    /// Obtém a lista de solicitantes (callers) únicos presentes nos incidentes.
    /// </summary>
    /// <returns>Lista de strings com os solicitantes distintos.</returns>
    public List<string> ObterCallersUnicos()
    {
        var lista = new List<string>();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string cmdText = """
            SELECT DISTINCT Caller 
            FROM 
                Incidentes 
            WHERE 
                Caller IS NOT NULL 
            ORDER BY 
                Caller
            """;

        using var cmd = new SqliteCommand(cmdText, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read()) lista.Add(reader.GetString(0));

        return lista;
    }

    /// <summary>
    /// Obtém a lista de itens de configuração (Apps) únicos presentes nos incidentes.
    /// </summary>
    /// <returns>Lista de strings com os itens de configuração distintos.</returns>
    public List<string> ObterItensConfiguracaoUnicos()
    {
        var lista = new List<string>();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string cmdText = """
            SELECT DISTINCT ConfigurationItem 
            FROM 
                Incidentes 
            WHERE 
                ConfigurationItem IS NOT NULL 
            ORDER BY 
                ConfigurationItem
            """;

        using var cmd = new SqliteCommand(cmdText, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read()) lista.Add(reader.GetString(0));

        return lista;
    }

    /// <summary>
    /// Gera um texto de contexto para ser usado pela IA, contendo os incidentes
    /// mais recentes até o limite especificado. Se o texto exceder o limite de tokens,
    /// reduz a lista até caber.
    /// </summary>
    /// <param name="top">Número máximo de incidentes a incluir.</param>
    /// <returns>Texto formatado com os incidentes selecionados.</returns>
    public string ObterContextoParaIA(int top = 10)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string cmdText = $@"SELECT 
                                Number, 
                                State, 
                                strftime('%d/%m/%Y %H:%M:%S', Created) AS Created, 
                                ShortDescription, 
                                AssignedTo, 
                                Caller
                            FROM 
                                Incidentes 
                            ORDER BY 
                                Created DESC LIMIT {top}";

        using var cmd = new SqliteCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@top", top);
        using var reader = cmd.ExecuteReader();

        var linhas = new List<string>();

        while (reader.Read())
        {
            var number = reader["Number"]?.ToString();
            var state = reader["State"]?.ToString();
            var created = reader["Created"]?.ToString();
            var assigned = reader["AssignedTo"]?.ToString();
            var caller = reader["Caller"]?.ToString();
            var desc = (reader["ShortDescription"]?.ToString() ?? "")
                .Replace("|", " ")
                .Replace("\n", " ")
                .Replace("\r", " ")
                .Replace("\t", " ")
                .Trim();
            desc = (desc.Length > 120) ? desc.Substring(0, 120) : desc;

            linhas.Add($"{number} | {state} | {created} | {assigned} | {caller} | {desc}");
        }

        return string.Join("\n", linhas);

        //// Junta tudo em texto delimitado
        //string contexto = string.Join("\n", linhas);

        //// Estima tokens
        //int tokensEstimados = EstimarTokens(contexto);

        //// Se exceder limite, corta a lista até caber
        //while (tokensEstimados > limiteTokens && linhas.Count > 0)
        //{
        //    linhas.RemoveAt(linhas.Count - 1); // remove último incidente
        //    contexto = string.Join("\n", linhas);
        //    tokensEstimados = EstimarTokens(contexto);
        //}

        //return contexto;
    }

    /// <summary>
    /// Exclui um incidente do banco de dados com base no seu identificador.
    /// </summary>
    /// <param name="id">Identificador único do incidente.</param>
    public void ExcluirIncidentePorId(int id)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "DELETE FROM Incidentes WHERE Id = @Id";

        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@Id", id);

        cmd.ExecuteNonQuery();
    }
    #endregion

    #region Métodos Private
    /// <summary>
    /// Estima a quantidade de tokens em um texto com base no número de caracteres.
    /// Aproximação: 1 token ≈ 4 caracteres.
    /// </summary>
    /// <param name="texto">Texto a ser analisado.</param>
    /// <returns>Número estimado de tokens.</returns>
    public int EstimarTokens(string texto)
    {
        if (string.IsNullOrEmpty(texto)) return 0;
        int caracteres = texto.Length;
        return caracteres / 4; 
    }
    #endregion
}