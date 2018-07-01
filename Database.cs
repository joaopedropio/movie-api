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
                        id int,
                        Name varchar(255),
                        Description varchar(255),
                        Path varchar(255)
                    );
                    INSERT INTO Movies (id, name, description, path)
                    VALUES (1, 'senhor dos aneis', 'aventura muito louca', 'senhordosaneis');
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