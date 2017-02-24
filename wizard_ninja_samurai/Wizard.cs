using System;

namespace wizard_ninja_samurai
{
    public class Wizard : Human
    {
        public Wizard(string person) : base(person, 3, 25, 3, 50)
        {

        }
        public void Heal()
        {
            health += intelligence*10;
            Console.WriteLine("{0}'s health is {1}", name, health);
        }
        public void Fireball(Human human2)
        {
            Random rand = new Random();
            int r = rand.Next(20,50);
            human2.health -= r;
            Console.WriteLine("{0}'s health is {1}", human2.name, human2.health);
        }
    }
}