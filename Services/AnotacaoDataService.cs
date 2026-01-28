using System.Data;
using IncidentesAI.DTO;
using Microsoft.Data.Sqlite;

namespace IncidentesAI.Services;

public class AnotacaoDataService
{
    private readonly string _connectionString;

    public AnotacaoDataService(string dbPath) => 
        _connectionString = dbPath.Contains("Data Source") ? dbPath : $"Data Source={dbPath}";

    public void InicializarBanco()
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();
        string sql = @"CREATE TABLE IF NOT EXISTS StatusInternos (
                            NumeroIncidente TEXT PRIMARY KEY, 
                            StatusInterno TEXT, 
                            Observacao TEXT, 
                            DataAtualizacao TEXT)";
        using var cmd = new SqliteCommand(sql, conn);
        cmd.ExecuteNonQuery();
    }

    public void SalvarAnotacao(string numero, string status, string observacao)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        string sql = @"INSERT OR REPLACE INTO StatusInternos (NumeroIncidente, StatusInterno, Observacao, DataAtualizacao) 
                           VALUES (@num, @status, @obs, datetime('now', 'localtime'))";

        using var cmd = new SqliteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@num", numero ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@status", status ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@obs", observacao ?? (object)DBNull.Value);

        cmd.ExecuteNonQuery();
    }

    public void RemoverAnotacao(string numero)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        string sql = "DELETE FROM StatusInternos WHERE NumeroIncidente = @num";
        using var cmd = new SqliteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@num", numero);
        cmd.ExecuteNonQuery();
    }

    public DataTable ObterDadosAnotacao(string numeroIncidente)
    {
        DataTable dt = new DataTable();
        using var conn = new SqliteConnection(_connectionString);
         conn.Open();

        string sql = "SELECT NumeroIncidente, StatusInterno, DataAtualizacao, Observacao FROM StatusInternos WHERE NumeroIncidente = @num";

        using var cmd = new SqliteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@num", numeroIncidente);

        using var reader =  cmd.ExecuteReader();
        dt.Load(reader);

        return dt;
    }

    public AnotacaoDTO ObterDadosAnotacaoParaExportacao(string numeroIncidente)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();

        string sql = @"SELECT NumeroIncidente, StatusInterno, Observacao 
                   FROM StatusInternos 
                   WHERE NumeroIncidente = @num";

        using var cmd = new SqliteCommand(sql, conn);
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

    public List<string> ObterStatusExistentes()
    {
        var lista = new List<string>();
        using var conn = new SqliteConnection(_connectionString);
         conn.Open();

        string sql = "SELECT DISTINCT StatusInterno FROM StatusInternos WHERE StatusInterno IS NOT NULL ORDER BY StatusInterno ASC";

        using var cmd = new SqliteCommand(sql, conn);
        using var reader =  cmd.ExecuteReader();

        while ( reader.Read())
        {
            lista.Add(reader.GetString(0));
        }
        return lista;
    }
}

