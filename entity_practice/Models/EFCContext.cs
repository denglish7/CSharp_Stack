using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace EFC.Models
{
    public class EFCContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Server = "localhost";
            string Port = "8889"; //or 8889 on Mac
            string Database = "friendsdb";
            string UserId = "root";
            string Password = "root";
            string Connection = $"Server={Server};port={Port};database={Database};uid={UserId};pwd={Password};SslMode=None;";
            optionsBuilder.UseMySQL(Connection);
        }
        public DbSet<Person> friends { get; set; }
    }
}