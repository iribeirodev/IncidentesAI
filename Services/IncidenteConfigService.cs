using System.Data;
using System.Text;
using Microsoft.Data.Sqlite;
using ExcelDataReader;

namespace IncidentesAI.Services;

public class IncidenteConfigService
{
    private readonly string _dbPath;
    private bool _cancelRequested;

    public IncidenteConfigService(string dbPath) 
        => _dbPath = dbPath.Contains("Data Source") ? dbPath : $"Data Source={dbPath}";

    public void CancelarOperacao() => _cancelRequested = true;

    public void CriarBancoDeDados()
    {
        using var connection = new SqliteConnection(_dbPath);
         connection.Open();

        string sql = @"
                CREATE TABLE IF NOT EXISTS Incidentes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Number TEXT NOT NULL,
                    AssignmentGroup TEXT,
                    State TEXT,
                    Caller TEXT,
                    AssignedTo TEXT,
                    Priority TEXT,
                    Created TEXT,
                    ShortDescription TEXT,
                    ConfigurationItem TEXT,
                    Email TEXT
                ) STRICT;";


        using var cmd = new SqliteCommand(sql, connection);
         cmd.ExecuteNonQuery();

        string sqlStatus = @"
        CREATE TABLE IF NOT EXISTS StatusInternos (
            NumeroIncidente TEXT PRIMARY KEY, 
            StatusInterno TEXT, 
            Observacao TEXT, 
            DataAtualizacao TEXT
        ) STRICT;";

        using var cmdStatus = new SqliteCommand(sqlStatus, connection);
        cmdStatus.ExecuteNonQuery();
    }

    public void ImportarPlanilha(string excelPath, Action<int, int> reportProgress, bool limparDados)
    {
        _cancelRequested = false;

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        using var stream = File.Open(excelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = ExcelReaderFactory.CreateReader(stream);

        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
        {
            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
        });

        DataTable table = result.Tables[0];
        int totalLinhas = table.Rows.Count;

        using var connection = new SqliteConnection(_dbPath);
         connection.Open();

        if (limparDados)
        {
            using var deleteCmd = new SqliteCommand("DELETE FROM Incidentes", connection);
             deleteCmd.ExecuteNonQuery();
        }

        using var transaction = connection.BeginTransaction();

        string sql = @"INSERT INTO Incidentes (Number, AssignmentGroup, State, Caller, AssignedTo, Priority, Created, ShortDescription, ConfigurationItem, Email) 
                           VALUES (@Number, @AG, @State, @Caller, @AssignedTo, @Priority, @Created, @Desc, @CI, @Email)";

        using var command = new SqliteCommand(sql, connection, transaction);

        command.Parameters.Add("@Number", SqliteType.Text);
        command.Parameters.Add("@AG", SqliteType.Text);
        command.Parameters.Add("@State", SqliteType.Text);
        command.Parameters.Add("@Caller", SqliteType.Text);
        command.Parameters.Add("@AssignedTo", SqliteType.Text);
        command.Parameters.Add("@Priority", SqliteType.Text);
        command.Parameters.Add("@Created", SqliteType.Text);
        command.Parameters.Add("@Desc", SqliteType.Text);
        command.Parameters.Add("@CI", SqliteType.Text);
        command.Parameters.Add("@Email", SqliteType.Text);

        for (int i = 0; i < totalLinhas; i++)
        {
            if (_cancelRequested)
            {
                 transaction.Rollback();
                return;
            }

            DataRow row = table.Rows[i];

            command.Parameters["@Number"].Value = row["Number"] ?? DBNull.Value;
            command.Parameters["@AG"].Value = row["Assignment group"] ?? DBNull.Value;
            command.Parameters["@State"].Value = row["State"] ?? DBNull.Value;
            command.Parameters["@Caller"].Value = row["Caller"] ?? DBNull.Value;
            command.Parameters["@AssignedTo"].Value = row["Assigned to"] ?? DBNull.Value;
            command.Parameters["@Priority"].Value = row["Priority"] ?? DBNull.Value;
            command.Parameters["@Created"].Value = row["Created"] ?? DBNull.Value;
            command.Parameters["@Desc"].Value = row["Short description"] ?? DBNull.Value;
            command.Parameters["@CI"].Value = row["Configuration item"] ?? DBNull.Value;
            command.Parameters["@Email"].Value = row["Email"] ?? DBNull.Value;

             command.ExecuteNonQuery();

            // Atualiza a UI sem travar
            if (i % 10 == 0 || i == totalLinhas - 1) // Reporta a cada 10 linhas para não sobrecarregar a UI
            {
                reportProgress?.Invoke(i + 1, totalLinhas);
            }
        }

         transaction.Commit();
    }
}
