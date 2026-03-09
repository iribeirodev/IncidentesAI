using Microsoft.Data.Sqlite;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace IncidentesAI.Helpers
{
    public class DbUtils
    {
        /// <summary>
        /// Abre uma conexão SQLite garantindo que o banco já exista.
        /// Se o arquivo não existir, lança exceção em vez de criar um novo.
        /// </summary>
        /// <param name="dbPath">Caminho do arquivo do banco de dados.</param>
        /// <returns>Conexão SQLite pronta para uso.</returns>
        public static SqliteConnection OpenConnection(string dbPath)
        {
            if (string.IsNullOrWhiteSpace(dbPath))
                throw new ArgumentException("Caminho do banco não pode ser vazio.", nameof(dbPath));

            if (!File.Exists(dbPath))
                throw new FileNotFoundException("Banco de dados não encontrado.", dbPath);

            // Usa URI para abrir em modo leitura/escrita sem criar novo
            string connectionString = $"Data Source=file:{dbPath};Mode=ReadWrite";

            var connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static SqlConnection OpenConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }


        /// <summary>
        /// Abre uma conexão SQLite específica para criação de um novo database.
        /// </summary>
        /// <param name="dbPath">Caminho do arquivo do banco de dados.</param>
        /// <returns>Conexão SQLite pronta para uso.</returns>
        public static SqliteConnection OpenConnectionToCreate(string dbPath)
        {
            string connectionString = $"Data Source={dbPath};Mode=ReadWriteCreate";

            var connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
