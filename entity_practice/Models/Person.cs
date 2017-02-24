using System;

namespace EFC.Models
{
    public class Person
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string occupation { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}