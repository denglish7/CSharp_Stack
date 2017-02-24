using System;

namespace wizard_ninja_samurai
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human Daniel = new Human("Daniel");
            Ninja Kuk = new Ninja("Kuk");
            Samurai PJ = new Samurai("PJ");
            Samurai Nathaniel = new Samurai("Nathaniel");
            Wizard Josh = new Wizard("Josh");
            // Kuk.Steal(PJ);
            // Kuk.Steal(Daniel);
            // Kuk.get_away();
            // PJ.death_blow(Kuk);
            // PJ.death_blow(Kuk);
            // PJ.death_blow(Kuk);
            // Kuk.Steal(Josh);
            // Josh.Heal();
            // Kuk.Steal(PJ);
            // PJ.meditate();
            Josh.Fireball(PJ);
            Josh.Fireball(PJ);
            Josh.Fireball(PJ);
            PJ.how_many();
        }
    }
}
