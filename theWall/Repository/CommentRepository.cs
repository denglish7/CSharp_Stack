using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dapperRelations.Models;
using Microsoft.Extensions.Options;

namespace DapperApp.Repository {
    public class CommentRepository : IRepository<Comment> {
        private readonly IOptions<MySqlOptions> mysqlConfig;
        public CommentRepository(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }
        public void Add(Comment item){
            using (IDbConnection dbConnection = Connection) {
                string query = "INSERT INTO comments (comment, message_id, user_id, created_at, updated_at) VALUES (@comment, @message_id, @user_id, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Comment> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Comment>("SELECT * FROM comments order by -id");
            }
        }
        public Comment FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Comment>("SELECT * FROM comments WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
        public IEnumerable<Comment> CommentsForUsersByID()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM comments JOIN users ON comments.user_id WHERE users.id = comments.user_id";
                dbConnection.Open();
                var myComments = dbConnection.Query<Comment, User, Comment>(query, (comment, user) => { comment.user = user; return comment; });
                return myComments;
            }
        }
        public IEnumerable<Comment> CommentsForMessagesByID()
        {
            using (IDbConnection dbConnection = Connection)
            {
                // var query = $"SELECT * FROM comments JOIN messages ON comments.message_id WHERE messages.id = comments.message_id";
                var query = $"SELECT * FROM comments JOIN messages ON comments.message_id = messages.id JOIN users ON comments.user_id = users.id order by comments.created_at";
                dbConnection.Open();
                var myComments = dbConnection.Query<Comment, Message, User, Comment>(query, (comment, message, user) => { comment.message = message; comment.user = user; return comment; });
                return myComments;
            }
        }

        
    }
}