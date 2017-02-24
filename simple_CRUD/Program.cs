using System;
using System.Collections.Generic;
using DbConnection;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Read()
        {
            
            var users = DbConnector.ExecuteQuery("Select * from User"); 
            foreach (var user in users)
            {
                Console.WriteLine("ID = {0} \n First Name = {1} \n Last Name = {2} \n Favorite Number = {3} \n Created at {4} \n", user["id"], user["first_name"], user["last_name"], user["favorite_number"], user["created_at"]);
            }
            
        }
        public static void Create()
        {
            
            // // Console.WriteLine("Enter a First Name, Last Name, and Favorite Number");
            Console.WriteLine("Enter First Name");
            string user_first_name = Console.ReadLine();

            Console.WriteLine("Enter Last Name");
            string user_last_name = Console.ReadLine();

            Console.WriteLine("Enter a Favorite Number");
            string user_fav_number = Console.ReadLine();

            DbConnector.ExecuteQuery($"\n INSERT INTO User(first_name,last_name, favorite_number, created_at) VALUES ('{user_first_name}', '{user_last_name}', '{user_fav_number}', NOW())"); 
            
            Read();
        }
        public static void Update()
        {
            Console.WriteLine("Enter ID of user you wish to update:");
            string user_id = Console.ReadLine();

            Console.WriteLine("Enter new First Name");
            string ud_first_name = Console.ReadLine();

            Console.WriteLine("Enter new Last Name");
            string ud_last_name = Console.ReadLine();

            Console.WriteLine("Enter new Favorite Number");
            string ud_favorite_number = Console.ReadLine();

            DbConnector.ExecuteQuery($"UPDATE User SET first_name='{ud_first_name}', last_name='{ud_last_name}', favorite_number='{ud_favorite_number}', updated_at=NOW() WHERE id = '{user_id}'");

            Read();
        }
        public static void Delete()
        {
            Console.WriteLine("Enter ID of user you wish to delete:");
            string user_id = Console.ReadLine();

            DbConnector.ExecuteQuery($"DELETE FROM User WHERE id = '{user_id}'");

            Read();
        }
        
        public static void Main(string[] args)
        {
            Create();
        }
    }
}
