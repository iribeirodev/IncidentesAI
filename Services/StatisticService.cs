using Microsoft.Data.Sqlite;

namespace IncidentesAI.Services;

public class StatisticService(string dbPath)
{
    private readonly string _connectionString = dbPath.Contains("Data Source")
        ? dbPath
        : $"Data Source={dbPath}";

    public async Task<Dictionary<string, int>> ObterDadosGraficoStatusAsync()
    {
        var dados = new Dictionary<string, int>();
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        string sql = "SELECT State, COUNT(*) as Total FROM Incidentes GROUP BY State ORDER BY Total DESC";

        using var cmd = new SqliteCommand(sql, connection);
        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
            dados.Add(reader.GetString(0), reader.GetInt32(1));

        return dados;
    }

    public async Task<Dictionary<string, int>> ObterTopAplicacoesAsync(int top = 5)
    {
        var dados = new Dictionary<string, int>();
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        string sql = @"SELECT ConfigurationItem, COUNT(*) as Total 
                           FROM Incidentes 
                           WHERE ConfigurationItem IS NOT NULL AND ConfigurationItem <> ''
                           GROUP BY ConfigurationItem 
                           ORDER BY Total DESC LIMIT @top";

        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@top", top);

        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
            dados.Add(reader.GetString(0), reader.GetInt32(1));

        return dados;
    }

    public async Task<Dictionary<string, int>> ObterTopCallersAsync(int top = 5)
    {
        var dados = new Dictionary<string, int>();
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        string sql = @"SELECT Caller, COUNT(*) as Total 
                           FROM Incidentes 
                           WHERE Caller IS NOT NULL AND Caller <> ''
                           GROUP BY Caller 
                           ORDER BY Total DESC LIMIT @top";

        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@top", top);

        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
            dados.Add(reader.GetString(0), reader.GetInt32(1));

        return dados;
    }
}
