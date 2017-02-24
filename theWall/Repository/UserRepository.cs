using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dapperRelations.Models;
using Microsoft.Extensions.Options;

namespace DapperApp.Repository {
    public class UserRepository : IRepository<User> {
        private readonly IOptions<MySqlOptions> mysqlConfig;
        public UserRepository(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }
        public void Add(User item){
            using (IDbConnection dbConnection = Connection) {
                string query = "INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES (@first_name, @last_name, @Email, @Password, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }
        public User FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open();
                var query =
                @"
                SELECT * FROM users WHERE id = @Id;
                SELECT * FROM messages WHERE user_id = @Id;";

                using (var multi = dbConnection.QueryMultiple(query, new {Id = id})) {
                    var user = multi.Read<User>().Single();
                    user.messages = multi.Read<Message>().ToList();
                    return user;
        }
    }
        }
        public User FindByEmail(string email)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE email = @Email", new { Email = email }).FirstOrDefault();
            }
        }
    }
}