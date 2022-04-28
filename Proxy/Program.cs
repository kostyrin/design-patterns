using Proxy.Aos;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            //AoS
            var creatures = new Creature[100];
            foreach (var item in creatures)
            {
                item.X++;
            }

            //SoA
            var creatures2 = new Creatures(100);
            foreach (Creatures.CreatureProxy item in creatures2)
            {
                item.X++;
            }
        }
    }
}
