using Microsoft.Data.SqlClient;
using IncidentesAI.Model;
using IncidentesAI.Helpers;


namespace IncidentesAI.Services;

/// <summary>
/// Serviço responsável por acessar e manipular dados de incidentes
/// armazenados em um banco SQLite. Fornece métodos para consulta,
/// filtragem, exclusão e preparação de contexto para IA.
/// </summary>

public class IncidenteDataService//(string DbPath)
{
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

        using var connection = DbUtils.OpenConnection(); //DbUtils.OpenConnection(DbPath);

        string commandText = """
            SELECT 
                id, 
                number, 
                assignment_group, 
                state, 
                caller, 
                assigned_to, 
                priority, 
                created, 
                FORMAT(created, 'dd/MM/yyyy HH:mm:ss') AS CreatedFormatado,
                short_description, 
                configuration_item, 
                email
            FROM 
                dbo.Incidentes
            ORDER BY 
                created DESC
        """;

        if (numeroIncidentesConsiderar > 0)
            commandText += $" OFFSET 0 ROWS FETCH NEXT {numeroIncidentesConsiderar} ROWS ONLY";

        using var cmd = new SqlCommand(commandText, connection);
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
                Created = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7),
                CreatedFormatado = reader[8] as string ?? string.Empty,
                ShortDescription = reader[9] as string ?? string.Empty,
                ConfigurationItem = reader[10] as string ?? string.Empty,
                Email = reader[11] as string ?? string.Empty
            });
        }

        return incidentes;
    }

    /// <summary>
    /// Obtém a lista de valores únicos de uma coluna da tabela Incidentes.
    /// </summary>
    /// <param name="columnName">Nome da coluna a consultar.</param>
    /// <returns>Lista de strings com os valores distintos.</returns>
    public List<string> ObterValoresUnicos(string columnName)
    {
        var lista = new List<string>();
        using var connection = DbUtils.OpenConnection(); //(DbPath);

        string cmdText = $"""
        SELECT 
            DISTINCT {columnName}
        FROM 
            Incidentes
        WHERE 
            {columnName} IS NOT NULL
        ORDER BY 
            {columnName} ASC
        """;

        using var cmd = new SqlCommand(cmdText, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read()) lista.Add(reader.GetString(0));

        return lista;
    }

    /// <summary>
    /// Gera um contexto para ser usado pela IA, contendo apenas os incidentes
    /// filtrados na interface. Se não houver incidentes, retorna uma mensagem
    /// indicando que não há registros disponíveis.
    /// </summary>
    /// <param name="incidentesFiltrados">Lista de incidentes filtrados a incluir.</param>
    /// <returns>Texto formatado com os incidentes selecionados.</returns>
    public string ObterContextoFiltradoParaIA(List<Incidente> incidentesFiltrados)
    {
        if (incidentesFiltrados == null || !incidentesFiltrados.Any())
            return "Nenhum incidente filtrado disponível.";

        var linhas = new List<string>();
        foreach (var i in incidentesFiltrados)
        {
            var desc = (i.ShortDescription ?? "")
                .Replace("|", " ")
                .Replace("\n", " ")
                .Replace("\r", " ")
                .Replace("\t", " ")
                .Trim();

            desc = (desc.Length > 120) ? desc.Substring(0, 120) : desc;

            linhas.Add($"{i.Number} | {i.State} | {i.ConfigurationItem} | {i.Created:dd/MM/yyyy HH:mm:ss} | {i.AssignedTo} | {i.Caller} | {desc}");
        }

        return string.Join("\n", linhas);
    }

    /// <summary>
    /// Gera um contexto para ser usado pela IA, contendo os incidentes
    /// mais recentes até o limite especificado. Se o texto exceder o limite de tokens,
    /// reduz a lista até caber.
    /// </summary>
    /// <param name="top">Número máximo de incidentes a incluir.</param>
    /// <returns>Texto formatado com os incidentes selecionados.</returns>
    public string ObterContextoParaIA(int top = 10)
    {
        using var connection = DbUtils.OpenConnection(); //(DbPath);

        string cmdText = $@"
            SELECT TOP {top}
                number, 
                state, 
                FORMAT(created, 'dd/MM/yyyy HH:mm:ss') AS created, 
                short_description, 
                assigned_to, 
                configuration_item,
                caller
            FROM 
                dbo.Incidentes 
            ORDER BY 
                number DESC";

        using var cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@top", top);
        using var reader = cmd.ExecuteReader();

        var linhas = new List<string>();

        while (reader.Read())
        {
            var number = reader["number"]?.ToString();
            var state = reader["state"]?.ToString();
            var created = reader["created"]?.ToString();
            var assigned = reader["assigned_to"]?.ToString();
            var caller = reader["caller"]?.ToString();
            var ci = reader["configuration_item"]?.ToString();
            var desc = (reader["short_description"]?.ToString() ?? "")
                .Replace("|", " ")
                .Replace("\n", " ")
                .Replace("\r", " ")
                .Replace("\t", " ")
                .Trim();

            desc = (desc.Length > 120) ? desc.Substring(0, 120) : desc;

            linhas.Add($"{number} | {state} | {ci} | {created} | {assigned} | {caller} | {desc}");
        }

        return string.Join("\n", linhas);
    }

    /// <summary>
    /// Exclui um incidente do banco de dados com base no seu identificador.
    /// </summary>
    /// <param name="id">Identificador único do incidente.</param>
    public void ExcluirIncidentePorId(int id)
    {
        using var connection = DbUtils.OpenConnection();

        string sql = "DELETE FROM Incidentes WHERE Id = @Id";

        using var cmd = new SqlCommand(sql, connection);
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