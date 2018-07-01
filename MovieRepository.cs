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
        }
        public List<Movie> GetAllMovies()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM Movies";
                return conn.Query<Movie>(query).ToList();
            }
        }

        public Movie GetMovieById(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var query = $"SELECT * FROM Movies WHERE ID = '{id}'";
                return conn.QuerySingle<Movie>(query);
            }
        }

        public bool DeleteMovieById(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var query = $"DELETE FROM Movies WHERE ID = '{id}'";
                var affectedrows = conn.Execute(query);
                return affectedrows > 0;
            }
        }
    }
}
