using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // int[] array = new int[10];
            // Console.WriteLine(array);

            // string[] names;
            // names = new string[] {"Tim", "Martin", "Nikki", "Sara"};
            // Console.WriteLine(names);

            
            // bool[] myBools = new bool[10] {true, false, true, false, true, false, true, false, true, false};
            // foreach(bool mb in myBools)
            // {
            // Console.WriteLine(mb);
            // }


            for(int i=1; i<10; i++){
                Console.WriteLine("\n");
                Console.WriteLine("\t");
                Console.WriteLine("]");
                for(int j=1; j<10; j++){
                    Console.WriteLine(i*j);
                }
            }

            // int [,] multTable = new int[10,10];
            //     for(int i=0; i<10; i++){
            //         for(int j=0; j<10; j++){
            //            multTable[i,j] = (i+1)*(j+1);          
            //         }
            //     }
            
            var profile1 = new Dictionary<string, object>();
                profile1.Add("Name", "Tim");
                profile1.Add("Favorite Sport", "Football");
                profile1.Add("Num of Pets", 3);
                profile1.Add("Likes ice-cream?", true);
            
            var profile2 = new Dictionary<string, object>();
                profile2.Add("Name", "Martin");
                profile2.Add("Favorite Sport", "Basketball");
                profile2.Add("Num of Pets", 2);
                profile2.Add("Likes ice-cream?", true);
            
            var profile3 = new Dictionary<string, object>();
                profile3.Add("Name", "Nikki");
                profile3.Add("Favorite Sport", "Soccer");
                profile3.Add("Num of Pets", 0);
                profile3.Add("Likes ice-cream?", false);

            var profile4 = new Dictionary<string, object>();
                profile4.Add("Name", "Sara");
                profile4.Add("Favorite Sport", "Volleyball");
                profile4.Add("Num of Pets", 1);
                profile4.Add("Likes ice-cream?", true);

            var allProfiles = new List<object>();
                allProfiles.Add(profile1);
                allProfiles.Add(profile2);
                allProfiles.Add(profile3);
                allProfiles.Add(profile4);

            // foreach (Dictionary<string, object> profile in allProfiles){
            //     foreach (KeyValuePair<string, object> entry in profile){
            //         Console.WriteLine(entry.Key + " - " + entry.Value);
            //     }
            // }
        }
    }
}
