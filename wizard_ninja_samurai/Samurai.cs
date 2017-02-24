using System;

namespace wizard_ninja_samurai
{
    public class Samurai : Human
    {
        public static int Count = 0;
        public Samurai(string person) : base(person, 3, 3, 3, 200)
        {
            Count++;
        }
        public void death_blow(Human human2)
        {
            base.attack(human2);
            if(human2.health < 50)
            {
                human2.health = 0;
            }
            Console.WriteLine("{0}'s health is {1}", human2.name, human2.health);
        }
        public void meditate()
        {
            if(health < 200)
            {
                health = 200;
            }
            Console.WriteLine("{0}'s health is {1}", name, health);
        }
       
        public int how_many()
        {
            if(Count == 1)
            {
                Console.WriteLine("There is {0} Samurai now.", Count);
            }
            else
            {
                Console.WriteLine("There are {0} Samurai's now.", Count);
            }
            return Count;
        }

    }
}