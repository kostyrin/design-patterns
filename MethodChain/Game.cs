using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodChain
{

    public abstract class Creature
    {
        public int Attack { get; set; }
        public int Defense { get; set; }

    }

    public class Goblin : Creature
    {
        public Goblin(Game game) 
        {
            Attack = 1;
            Defense = 1;
        }


    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game) 
        {
            Attack = 3;
            Defense = 3;
        }
    }

    public class Game
    {
        public IList<Creature> Creatures = new List<Creature>();
    }

}
