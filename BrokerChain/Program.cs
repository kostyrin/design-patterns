using BrokerChain;
using static BrokerChain.CarModifier;

//var maintenance = new Maintenance();

//var honda = new Car(maintenance, "Honda", 100);
//Console.WriteLine(honda);
//using var doubleSpeed = new DoubleModifier(maintenance, honda);
//Console.WriteLine(doubleSpeed);
//using var decreaseSpeed = new DecreaseModifier(maintenance, honda);
//Console.WriteLine(honda);

//Console.ReadLine();

using System;

namespace Coding.Exercise
{
    public abstract class Creature
    {
        public int Attack { get; set; }
        public int Defense { get; set; }

    }

    public class Goblin : Creature
    {
        public Goblin(Game game) { }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game) { }
    }

    public class Game
    {
        public IList<Creature> Creatures;
    }
}
