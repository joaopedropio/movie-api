using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace Movie
{
    public class MovieRepository
    {
        private string connectionString { get; set; }

        public MovieRepository(string connectionString)
        {
            this.connectionString = connectionString;

            using (var connection = new MySqlConnection(connectionString))
            {
                var query = @"
                    CREATE TABLE MOVIES (
                        id int,
                        Name varchar(255),
                        Description varchar(255),
                        Path varchar(255)
                    );
                ";

                var command = connection.CreateCommand();
                connection.Open();
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }
        public List<Movie> GetAllMovies()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM MOVIES";
                return conn.Query<Movie>(query).ToList();
            }
        }

        public Movie GetMovieById(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var query = $"SELECT * FROM MOVIES WHERE ID = '{id}'";
                return conn.QuerySingle<Movie>(query);
            }
        }

        public bool DeleteMovieById(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var query = $"DELETE FROM MOVIES WHERE ID = '{id}'";
                var affectedrows = conn.Execute(query);
                return affectedrows > 0;
            }
        }
    }
}
