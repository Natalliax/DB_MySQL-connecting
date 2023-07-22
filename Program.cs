using MySqlConnector;
using System;
using System.Threading.Tasks;


namespace DB_MySQL
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var builder = new MySqlConnectionStringBuilder("Server = 91.149.187.115; port = 43251; UserID = m_n_p; Password = Ejik_7534392; Database = chik_db")
            {
                
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * from nameservice";

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var value = reader.GetValue(1);
                Console.WriteLine(value);
            }
        }
    }
}

        