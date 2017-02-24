using System;
using EFC.Models;
using System.Collections.Generic;
using System.Linq;

namespace EFC
{
    public class Program
    {
        public static void Add()
        {
            using(var db = new EFCContext())
            {
                Console.WriteLine("Please enter a First Name");
                string new_first_name = Console.ReadLine();

                Console.WriteLine("Please enter a Last Name");
                string new_last_name = Console.ReadLine();

                Console.WriteLine("Please enter an Occupation");
                string new_occupation = Console.ReadLine();
                

                Person NewPerson = new Person
                {
                    first_name = new_first_name,
                    last_name = new_last_name,
                    occupation = new_occupation
                };
                db.Add(NewPerson);
                db.SaveChanges();
                Read();
            }
        }
        public static void Read()
        {
            using(var db = new EFCContext())
            {
                IEnumerable<Person> ReturnedValues = db.friends;
                foreach(var friend in db.friends)
                {
                    Console.WriteLine($"First Name: '{friend.first_name}' \n Last Name: '{friend.last_name}' \n Occupation: '{friend.occupation}'");
                }
            }
            
        }
        public static void Update()
        {
            using(var db = new EFCContext())
            {
                Console.WriteLine("Give the id of the user you would like to update");
                string id_to_update = Console.ReadLine();

                Console.WriteLine("Please enter a First Name");
                string new_first_name = Console.ReadLine();

                Console.WriteLine("Please enter a Last Name");
                string new_last_name = Console.ReadLine();

                Console.WriteLine("Please enter an Occupation");
                string new_occupation = Console.ReadLine();

                Person RetrievedUser = db.friends.SingleOrDefault(friend => friend.id.ToString() == id_to_update);
                RetrievedUser.first_name = new_first_name;
                RetrievedUser.last_name = new_last_name;
                RetrievedUser.occupation = new_occupation;

                db.SaveChanges();

                Read();
            }
        }
        public static void Delete()
        {
            using(var db = new EFCContext())
            {
                Console.WriteLine("Give the id of the user you would like to delete");
                string id_to_delete = Console.ReadLine();

                Person RetrievedUser = db.friends.SingleOrDefault(friend => friend.id.ToString() == id_to_delete);
                db.friends.Remove(RetrievedUser);
                db.SaveChanges();

                Read();
            }
        }
        public static void Main()
        {
            using(var db = new EFCContext())
            {
                var TableContents = db.friends;
                // Read();
                // Update();
                // Delete();
                // Add();
                Read();
                // Person RetrievedUser = db.users.SingleOrDefault(user => user.first_name == "Donald");
                // db.users.Remove(RetrievedUser);
                // db.SaveChanges();
            }
        }
    }
}
