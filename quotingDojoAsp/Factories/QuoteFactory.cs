using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using quotingDojoAsp.Models;

namespace quotingDojoAsp.Factory
{
    public class QuoteFactory : IFactory<Quote>
    {
        private string connectionString;
        public QuoteFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=quotes;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(Quote item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO quotes (name, quote, created_at, updated_at) VALUES (@name, @quote, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Quote> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Quote>("SELECT * FROM quotes order by -id");
            }
        }
        public Quote FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Quote>("SELECT * FROM quotes WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}
