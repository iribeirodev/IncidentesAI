using System.Data;
using Microsoft.Data.Sqlite;
using IncidentesAI.DTO;


namespace IncidentesAI.Services;

/// <summary>
/// Serviço responsável por gerenciar anotações internas relacionadas a incidentes.
/// Permite salvar, remover e consultar anotações.
/// </summary>
public class AnotacaoDataService
{
    private readonly string _connectionString;

    #region Construtor
    /// <summary>
    /// Inicializa o serviço com o caminho do banco de dados.
    /// Se o caminho não contiver "Data Source", adiciona automaticamente.
    /// </summary>
    /// <param name="dbPath">Caminho do arquivo SQLite ou string de conexão.</param>
    public AnotacaoDataService(string dbPath) => 
        _connectionString = dbPath.Contains("Data Source") ? dbPath : $"Data Source={dbPath}";
    #endregion

    #region Métodos Públicos
    /// <summary>
    /// Salva ou atualiza uma anotação para um incidente específico.
    /// Caso já exista, substitui os dados anteriores.
    /// </summary>
    /// <param name="numero">Número do incidente.</param>
    /// <param name="status">Status interno associado ao incidente.</param>
    /// <param name="observacao">Observação ou comentário adicional.</param>
    public void SalvarAnotacao(string numero, string status, string observacao)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        string commandText = @"INSERT OR REPLACE INTO StatusInternos (
                                    NumeroIncidente, StatusInterno, Observacao, DataAtualizacao) 
                                VALUES (
                                    @num, @status, @obs, datetime('now', 'localtime'))";

        using var cmd = new SqliteCommand(commandText, conn);
        cmd.Parameters.AddWithValue("@num", numero ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@status", status ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@obs", observacao ?? (object)DBNull.Value);

        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Remove a anotação associada a um incidente específico.
    /// </summary>
    /// <param name="numero">Número do incidente cuja anotação será removida.</param>
    public void RemoverAnotacao(string numero)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        string commandText = "DELETE FROM StatusInternos WHERE NumeroIncidente = @num";
        using var cmd = new SqliteCommand(commandText, conn);
        cmd.Parameters.AddWithValue("@num", numero);
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Obtém os dados completos da anotação de um incidente em formato de DataTable.
    /// </summary>
    /// <param name="numeroIncidente">Número do incidente a consultar.</param>
    public DataTable ObterDadosAnotacao(string numeroIncidente)
    {
        DataTable dt = new DataTable();
        using var conn = new SqliteConnection(_connectionString);
         conn.Open();

        string commandText = """
            SELECT 
                NumeroIncidente, StatusInterno, DataAtualizacao, Observacao 
            FROM 
                StatusInternos 
            WHERE 
                NumeroIncidente = @num
            """;

        using var cmd = new SqliteCommand(commandText, conn);
        cmd.Parameters.AddWithValue("@num", numeroIncidente);

        using var reader =  cmd.ExecuteReader();
        dt.Load(reader);

        return dt;
    }

    /// <summary>
    /// Obtém os dados da anotação de um incidente em formato de DTO,
    /// preparado para exportação.
    /// </summary>
    /// <param name="numeroIncidente">Número do incidente a consultar.</param>
    /// <returns>Objeto <see cref="AnotacaoDTO"/> com os dados da anotação, ou null se não encontrado.</returns>
    public AnotacaoDTO ObterDadosAnotacaoParaExportacao(string numeroIncidente)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        string commandText = """
                SELECT 
                    NumeroIncidente, StatusInterno, Observacao 
                FROM 
                   StatusInternos 
                WHERE 
                    NumeroIncidente = @num
            """;

        using var cmd = new SqliteCommand(commandText, conn);
        cmd.Parameters.AddWithValue("@num", numeroIncidente);

        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new AnotacaoDTO
            {
                NumeroIncidente = reader["NumeroIncidente"].ToString(),
                StatusInterno = reader["StatusInterno"].ToString(),
                Observacao = reader["Observacao"].ToString()
            };
        }

        return null;
    }

    /// <summary>
    /// Obtém a lista de status internos distintos já cadastrados no banco.
    /// </summary>
    /// <returns>Lista de strings com os status internos existentes.</returns>
    public List<string> ObterStatusExistentes()
    {
        var lista = new List<string>();
        using var conn = new SqliteConnection(_connectionString);
         conn.Open();

        string commandText = """
            SELECT 
                DISTINCT StatusInterno 
            FROM 
                StatusInternos 
            WHERE 
                StatusInterno IS NOT NULL 
            ORDER BY 
                StatusInterno
            """;

        using var cmd = new SqliteCommand(commandText, conn);
        using var reader =  cmd.ExecuteReader();

        while ( reader.Read())
            lista.Add(reader.GetString(0));

        return lista;
    }
    #endregion
}

