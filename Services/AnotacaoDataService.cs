using IncidentesAI.DTO;
using IncidentesAI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data;


namespace IncidentesAI.Services;

/// <summary>
/// Serviço responsável por gerenciar anotações internas relacionadas a incidentes.
/// Permite salvar, remover e consultar anotações.
/// </summary>
public class AnotacaoDataService(string DbPath)
{
    #region Métodos Públicos
    /// <summary>
    /// Salva ou atualiza uma anotação para um incidente específico.
    /// Caso já exista, substitui os dados anteriores.
    /// </summary>
    /// <param name="numero">Número do incidente.</param>
    /// <param name="status">Status interno associado ao incidente.</param>
    /// <param name="observacao">Observação ou comentário adicional.</param>
    public void SalvarAnotacao(
        string numero, 
        string status, 
        string observacao)
    {
        using var conn = DbUtils.OpenConnection();

        // Primeiro tenta atualizar
        string updateText = @"
        UPDATE dbo.StatusInternos
        SET StatusInterno = @status,
            Observacao = @obs,
            DataAtualizacao = GETDATE()
        WHERE NumeroIncidente = @num";

        using (var updateCmd = new SqlCommand(updateText, conn))
        {
            updateCmd.Parameters.AddWithValue("@num", numero ?? (object)DBNull.Value);
            updateCmd.Parameters.AddWithValue("@status", status ?? (object)DBNull.Value);
            updateCmd.Parameters.AddWithValue("@obs", observacao ?? (object)DBNull.Value);

            int rowsAffected = updateCmd.ExecuteNonQuery();

            // Se não atualizou nada, insere
            if (rowsAffected == 0)
            {
                string insertText = @"
                INSERT INTO dbo.StatusInternos 
                    (NumeroIncidente, StatusInterno, Observacao, DataAtualizacao)
                VALUES 
                    (@num, @status, @obs, GETDATE())";

                using var insertCmd = new SqlCommand(insertText, conn);
                insertCmd.Parameters.AddWithValue("@num", numero ?? (object)DBNull.Value);
                insertCmd.Parameters.AddWithValue("@status", status ?? (object)DBNull.Value);
                insertCmd.Parameters.AddWithValue("@obs", observacao ?? (object)DBNull.Value);

                insertCmd.ExecuteNonQuery();
            }
        }
    }


    /// <summary>
    /// Remove a anotação associada a um incidente específico.
    /// </summary>
    /// <param name="numero">Número do incidente cuja anotação será removida.</param>
    public void RemoverAnotacao(string numero)
    {
        using var conn = DbUtils.OpenConnection();

        string commandText = "DELETE FROM dbo.StatusInternos WHERE NumeroIncidente = @num";
        using var cmd = new SqlCommand(commandText, conn);
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
        using var conn = DbUtils.OpenConnection();

        string commandText = @"
            SELECT 
                NumeroIncidente, StatusInterno, DataAtualizacao, Observacao 
            FROM 
                dbo.StatusInternos 
            WHERE 
                NumeroIncidente = @num";

        using var cmd = new SqlCommand(commandText, conn);
        cmd.Parameters.AddWithValue("@num", numeroIncidente);

        using var reader = cmd.ExecuteReader();
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
        using var conn = DbUtils.OpenConnection();

        string commandText = @"
            SELECT 
                NumeroIncidente, StatusInterno, Observacao 
            FROM 
                dbo.StatusInternos 
            WHERE 
                NumeroIncidente = @num";

        using var cmd = new SqlCommand(commandText, conn);
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
        using var conn = DbUtils.OpenConnection();

        string commandText = @"
            SELECT DISTINCT StatusInterno 
            FROM dbo.StatusInternos 
            WHERE StatusInterno IS NOT NULL 
            ORDER BY StatusInterno";

        using var cmd = new SqlCommand(commandText, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
            lista.Add(reader.GetString(0));

        return lista;
    }
    #endregion
}

