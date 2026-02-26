using System.Data;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace IncidentesAI.Services;

public class IncidenteDataService
{
    private readonly string _connectionString;

    public IncidenteDataService(string dbPath)
        => _connectionString = dbPath.Contains("Data Source") ? dbPath : $"Data Source={dbPath}";

    public DataTable ObterTodosIncidentes(int numeroIncidentesConsiderar)
    {
        DataTable dt = new DataTable();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string commandText = "";
        commandText = "SELECT * FROM Incidentes ORDER BY Created DESC";
        if (numeroIncidentesConsiderar > 0)
            commandText += $" LIMIT {numeroIncidentesConsiderar}";

        using var cmd = new SqliteCommand(commandText, connection);
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

    public string ObterContextoParaIA(int top = 30, int limiteTokens = 800)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string sql = $@"SELECT Number, State, Created, ShortDescription, AssignedTo, Caller
                   FROM Incidentes 
                   ORDER BY Created DESC LIMIT {top}";

        using var cmd = new SqliteCommand(sql, connection);
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

            linhas.Add($"{number} | {state} | {created} | {assigned} | {caller} | {desc}");
        }

        // Junta tudo em texto delimitado
        string contexto = string.Join("\n", linhas);

        // Estima tokens
        int tokensEstimados = EstimarTokens(contexto);

        // Se exceder limite, corta a lista até caber
        while (tokensEstimados > limiteTokens && linhas.Count > 0)
        {
            linhas.RemoveAt(linhas.Count - 1); // remove último incidente
            contexto = string.Join("\n", linhas);
            tokensEstimados = EstimarTokens(contexto);
        }

        return contexto;
    }

    public int EstimarTokens(string texto)
    {
        if (string.IsNullOrEmpty(texto)) return 0;
        int caracteres = texto.Length;
        return caracteres / 4; // aproximação: 1 token ≈ 4 caracteres
    }


    //public string ObterContextoParaIA(int top = 30)
    //{
    //    using var connection = new SqliteConnection(_connectionString);
    //    connection.Open();

    //    string sql = $@"SELECT Number, State, Created, ShortDescription, AssignedTo, Caller
    //               FROM Incidentes 
    //               ORDER BY Created DESC LIMIT {top}";

    //    using var cmd = new SqliteCommand(sql, connection);
    //    using var reader = cmd.ExecuteReader();

    //    var linhas = new List<string>();

    //    while (reader.Read())
    //    {
    //        var number = reader["Number"]?.ToString();
    //        var state = reader["State"]?.ToString();
    //        var created = reader["Created"]?.ToString();
    //        var assigned = reader["AssignedTo"]?.ToString();
    //        var caller = reader["Caller"]?.ToString();
    //        var desc = (reader["ShortDescription"]?.ToString() ?? "")
    //            .Replace("|", " ") // evita conflito com delimitador
    //            .Replace("\n", " ")
    //            .Replace("\r", " ")
    //            .Replace("\t", " ")
    //            .Trim();

    //        linhas.Add($"{number} | {state} | {created} | {assigned} | {caller} | {desc}");
    //    }

    //    return string.Join("\n", linhas);
    //}

}