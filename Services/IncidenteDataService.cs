using System.Data;
using System.Text;
using Microsoft.Data.Sqlite;

namespace IncidentesAI.Services;

public class IncidenteDataService
{
    private readonly string _connectionString;

    public IncidenteDataService(string dbPath)
        => _connectionString = dbPath.Contains("Data Source") ? dbPath : $"Data Source={dbPath}";

    public DataTable ObterTodosIncidentes()
    {
        DataTable dt = new DataTable();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "SELECT * FROM Incidentes ORDER BY Created DESC";

        using var cmd = new SqliteCommand(sql, connection);
        using var reader = cmd.ExecuteReader();
        dt.Load(reader);

        return dt;
    }

    public List<string> ObterStatusUnicos()
    {
        var lista = new List<string>();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "SELECT DISTINCT State FROM Incidentes WHERE State IS NOT NULL ORDER BY State ASC";

        using var cmd = new SqliteCommand(sql, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read()) lista.Add(reader.GetString(0));

        return lista;
    }

    public List<string> ObterCallersUnicos()
    {
        var lista = new List<string>();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "SELECT DISTINCT Caller FROM Incidentes WHERE Caller IS NOT NULL ORDER BY Caller ASC";

        using var cmd = new SqliteCommand(sql, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read()) lista.Add(reader.GetString(0));

        return lista;
    }

    public List<string> ObterItensConfiguracaoUnicos()
    {
        var lista = new List<string>();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = "SELECT DISTINCT ConfigurationItem FROM Incidentes WHERE ConfigurationItem IS NOT NULL ORDER BY ConfigurationItem ASC";

        using var cmd = new SqliteCommand(sql, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read()) lista.Add(reader.GetString(0));

        return lista;
    }

    public string ObterContextoParaIA(int top = 30)
    {
        StringBuilder sb = new StringBuilder();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = $@"SELECT Number, State, Created, ShortDescription 
                       FROM Incidentes 
                       ORDER BY Created DESC LIMIT {top}";

        using var cmd = new SqliteCommand(sql, connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string number = reader["Number"]?.ToString() ?? "N/A";
            string created = reader["Created"]?.ToString() ?? "N/A";
            string state = reader["State"]?.ToString() ?? "N/A";

            string rawDesc = reader["ShortDescription"]?.ToString() ?? "";
            string cleanDesc = rawDesc
                .Replace("\"", "'")
                .Replace("{", "[")
                .Replace("}", "]")
                .Replace("\n", " ")
                .Replace("\r", " ")
                .Replace("\t", " ")
                .Trim();

            sb.AppendLine($"- Ticket: {number} | Criado: {created} | Status: {state} | Desc: {cleanDesc}");
        }

        return sb.ToString();
    }
}