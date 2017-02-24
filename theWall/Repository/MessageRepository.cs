using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dapperRelations.Models;
using Microsoft.Extensions.Options;

namespace DapperApp.Repository {
    public class MessageRepository : IRepository<Message> {
        private readonly IOptions<MySqlOptions> mysqlConfig;
        public MessageRepository(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }
        public void Add(Message item){
            using (IDbConnection dbConnection = Connection) {
                string query = "INSERT INTO messages (message, user_id, created_at, updated_at) VALUES (@message, @user_id, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Message> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Message>("SELECT * FROM messages order by -id");
            }
        }
        public Message FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Message>("SELECT * FROM messages WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
        public IEnumerable<Message> MessagesForUsersByID()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM messages JOIN users ON messages.user_id WHERE users.id = messages.user_id order by -messages.id";
                dbConnection.Open();
                var myMessages = dbConnection.Query<Message, User, Message>(query, (message, user) => { message.user = user; return message; });
                return myMessages;
            }
        }
        
    }
}