using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square { Side = 2};
            var rectangle = new SquareToRectangleAdapter(square);
            var area = rectangle.Area();
            
            Console.WriteLine("Hello World!");
        }
    }
}
