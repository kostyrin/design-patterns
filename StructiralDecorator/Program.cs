using System;
using System.Linq;
using System.Text;

namespace StructuralDecorator
{
    public class ColoredCar : CarDecorator<ColoredCar, CarAllowedPolicy>
    {
        private readonly string _color;
        public ColoredCar(Car car, string color) : base(car)
        {
            _color = color;
        }

        public override string AsString()
        {
            var sb = new StringBuilder($"{_car.AsString()}");
            if (policy.ApplicationAllowed(types[0], types.Skip(1).ToList()))
            {
                sb.Append($" has the color {_color}");
            }

            return sb.ToString();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var honda = new Honda(2);
            var colored1 = new ColoredCar(honda, "black");
            var colored2 = new ColoredCar(colored1, "gray");
            Console.WriteLine(honda.AsString());
            Console.WriteLine(colored1.AsString());
            Console.WriteLine(colored2.AsString());
        }
    }
}
