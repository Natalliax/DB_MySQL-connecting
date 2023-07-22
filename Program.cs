using MySqlConnector;
using System;
using System.Threading.Tasks;


namespace DB_MySQL
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var builder = new MySqlConnectionStringBuilder("Server = localhost; port = 3306; UserID = abcd; Password = 12345; Database = db")
            {//логин, пароль и имя базы данных подставляем свою
                
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

        
