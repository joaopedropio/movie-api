using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

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
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM MOVIES";
                return conn.Query<Movie>(query).ToList();
            }
        }

        public Movie GetMovieById(int id)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var query = $"SELECT * FROM MOVIES WHERE ID = '{id}'";
                return conn.QuerySingle<Movie>(query);
            }
        }

        public bool DeleteMovieById(int id)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var query = $"DELETE FROM MOVIES WHERE ID = '{id}'";
                var affectedrows = conn.Execute(query);
                return affectedrows > 0;

            }
        }
    }
}
