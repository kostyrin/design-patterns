using System;

namespace Factories
{
    class Program
    {
        static void Main(string[] args)
        {
            var hotDrinkMachine = new HotDrinkMachine();
            var coffee = hotDrinkMachine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 100);
            Console.WriteLine("Hello World!");
        }
    }
}
