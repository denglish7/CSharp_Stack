using System;

namespace ConsoleApplication
{
    public class Human{
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(string word){
            name = word;
        }

        public Human(string word, int power, int iq, int val, int unit){
            name = word;
            strength = power;
            intelligence = iq;
            dexterity = val;
            health = unit;
        }
        public Human Attack(Human otherHuman){
            otherHuman.health -= 5 * strength;
            Console.WriteLine(otherHuman.health);
            return otherHuman;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Human human1 = new Human("Daniel");
            Human human2 = new Human("Kuk");

            human1.Attack(human2);
        }
    }
}
