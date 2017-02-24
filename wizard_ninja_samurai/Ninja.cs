using System;

namespace wizard_ninja_samurai
{
    public class Ninja : Human
    {
        public int dexterity = 175;
        public Ninja(string person) : base(person)
        {

        }
        public void Steal(Human human2)
        {
            base.attack(human2);
            health += 10; 
            Console.WriteLine("{0}'s health is {1}", human2.name, human2.health);
            Console.WriteLine("{0}'s health is {1}", name, health);
        }
        public void get_away()
        {
            health -= 15;
            Console.WriteLine("{0}'s health is {1}", name, health);
        }
    }
}