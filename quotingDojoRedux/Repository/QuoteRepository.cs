using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dapperRelations.Models;
using Microsoft.Extensions.Options;

namespace DapperApp.Repository
{
    public class QuoteRepository : IRepository<Quote>
    {
        private readonly IOptions<MySqlOptions> mysqlConfig;
        public QuoteRepository(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }
        public void Delete(string Id)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  $"DELETE FROM quotes WHERE id = {Id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public void Add(Quote item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO quotes (quote, user_id, created_at, updated_at) VALUES (@quote, @user_id, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public void Update(string quote, string Id)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  $"UPDATE quotes SET quote='{quote}', updated_at=NOW() WHERE id = {Id}";
                dbConnection.Open();
                dbConnection.Execute(query);
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
        public IEnumerable<Quote> QuotesForUserById()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM quotes JOIN users ON quotes.user_id WHERE users.id = quotes.user_id";
                dbConnection.Open();
                var myUsers = dbConnection.Query<Quote, User, Quote>(query, (quote, user) => { quote.user = user; return quote; });
                return myUsers;
            }
        }
    }
}
