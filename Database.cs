using MySql.Data.MySqlClient;
using System.Threading;
using System;

namespace Movie
{
    public static class Database 
    {
        public static void InitiateTable(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = @"
                    CREATE TABLE IF NOT EXISTS Movies (
                        id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(255),
                        Description VARCHAR(255),
                        Path VARCHAR(255)
                    );
                    INSERT INTO Movies (name, description, path)
                    VALUES ('senhor dos aneis', 'aventura muito louca', 'senhordosaneis');
                ";

                var command = connection.CreateCommand();
                connection.Open();
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }

        public static void Bootstrap(string connectionString, int timeOut = 30000)
        {
            var time = 1000;
            Thread.Sleep(time);
            try
            {
                InitiateTable(connectionString);
            }
            catch (System.Exception ex)
            {
                if(timeOut < 0) throw ex;

                Console.WriteLine(ex.Message);
                Console.WriteLine(timeOut / time + " tries left...");
                Bootstrap(connectionString, timeOut - time);
            }
        }
    }
}