using System.Data;
using System.Text;
using Microsoft.Data.Sqlite;
using ExcelDataReader;
using IncidentesAI.Helpers;
using Microsoft.Data.SqlClient;


namespace IncidentesAI.Services;

/// <summary>
/// Serviço responsável pela configuração e manutenção do banco de dados de incidentes.
/// Permite criar a estrutura inicial das tabelas, importar dados a partir de planilhas Excel
/// e cancelar operações em andamento.
/// </summary>
public class IncidenteConfigService //(string DbPath)
{
    private bool _cancelRequested;


    #region Métodos Públicos
    /// <summary>
    /// Solicita o cancelamento da operação em andamento (ex.: importação de planilha).
    /// </summary>
    public void CancelarOperacao() => _cancelRequested = true;

    /// <summary>
    /// Cria o banco de dados e as tabelas necessárias, caso não existam.
    /// Inclui a tabela de incidentes e a tabela de status internos.
    /// </summary>
    public void CriarBancoDeDados()
    {
        //using var connection = DbUtils.OpenConnectionToCreate(DbPath);

        //string commandText = @"
        //        CREATE TABLE IF NOT EXISTS Incidentes (
        //            Id INTEGER PRIMARY KEY AUTOINCREMENT,
        //            Number TEXT NOT NULL,
        //            AssignmentGroup TEXT,
        //            State TEXT,
        //            Caller TEXT,
        //            AssignedTo TEXT,
        //            Priority TEXT,
        //            Created TEXT,
        //            ShortDescription TEXT,
        //            ConfigurationItem TEXT,
        //            Email TEXT
        //        ) STRICT;";


        //using var cmd = new SqliteCommand(commandText, connection);
        // cmd.ExecuteNonQuery();

        //string commandStatus = @"
        //CREATE TABLE IF NOT EXISTS StatusInternos (
        //    NumeroIncidente TEXT PRIMARY KEY, 
        //    StatusInterno TEXT, 
        //    Observacao TEXT, 
        //    DataAtualizacao TEXT
        //) STRICT;";

        //using var cmdStatus = new SqliteCommand(commandStatus, connection);
        //cmdStatus.ExecuteNonQuery();
    }

    /// <summary>
    /// Importa dados de incidentes a partir de uma planilha Excel para o banco de dados.
    /// Permite limpar dados existentes antes da importação e reporta progresso para a UI.
    /// </summary>
    /// <param name="excelPath">Caminho do arquivo Excel a ser importado.</param>
    /// <param name="reportProgress">Ação de callback para reportar progresso (linhas processadas, total).</param>
    /// <param name="limparDados">Indica se os dados existentes devem ser removidos antes da importação.</param>
    /// <remarks>
    /// - A operação pode ser cancelada chamando <see cref="CancelarOperacao"/>.
    /// - O progresso é reportado a cada 10 linhas ou na última linha.
    /// - Os dados são inseridos em transação para garantir consistência.
    /// </remarks>
    public void ImportarPlanilha(
        string excelPath, 
        Action<int, int> reportProgress, 
        bool limparDados)
    {
        _cancelRequested = false;

        //using var connection = DbUtils.OpenConnection(DbPath);
        using var connection = DbUtils.OpenConnection();

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        using var stream = File.Open(excelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = ExcelReaderFactory.CreateReader(stream);

        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
        {
            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
        });

        DataTable table = result.Tables[0];
        int totalLinhas = table.Rows.Count;

        if (limparDados)
        {
            //using var deleteCmd = new SqliteCommand("DELETE FROM Incidentes", connection);
            using var deleteCmd = new SqlCommand("TRUNCATE TABLE Incidentes", connection);
            deleteCmd.ExecuteNonQuery();
        }

        using var transaction = connection.BeginTransaction();

        string commandText = """
            INSERT INTO dbo.Incidentes (
                number, assignment_group, state, caller, assigned_to, 
                priority, created, short_description, configuration_item, email
            ) 
            VALUES (
                @Number, @AG, @State, @Caller, @AssignedTo, 
                @Priority, @Created, @Desc, @CI, @Email
            )
        """;


        //using var command = new SqliteCommand(commandText, connection, transaction);
        using var command = new SqlCommand(commandText, connection, transaction);

        command.Parameters.Add("@Number", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@AG", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@State", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@Caller", SqlDbType.NVarChar, 100);
        command.Parameters.Add("@AssignedTo", SqlDbType.NVarChar, 100);
        command.Parameters.Add("@Priority", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@Created", SqlDbType.DateTime); // corrigido
        command.Parameters.Add("@Desc", SqlDbType.NVarChar, 2000);
        command.Parameters.Add("@CI", SqlDbType.NVarChar, 100);
        command.Parameters.Add("@Email", SqlDbType.NVarChar, 100);

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

            if (DateTime.TryParse(row["Created"]?.ToString(), out var createdDate))
                command.Parameters["@Created"].Value = createdDate;
            else
                command.Parameters["@Created"].Value = DBNull.Value;

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
    #endregion
}
