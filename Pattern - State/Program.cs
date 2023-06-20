using System;

namespace Pattern___State
{
    class Program
    {
        static void Main(string[] args)
        {
            Parameter hp = new Parameter(3, 6, 9);
            Parameter satiety = new Parameter(3, 6, 9);

            Creature creature = new Creature(hp, satiety);

            creature.LiveTheCycles();

            Console.ReadKey();
        }
    }
}

