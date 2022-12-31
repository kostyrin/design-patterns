using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodChain
{
    public class Car
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Car(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"Name:{Name}, Value:{Value}";
        }
    }

    public class CarModificator
    {
        protected Car _car;
        protected CarModificator _next;
        public CarModificator(Car car)
        {
            _car = car ?? throw new ArgumentNullException(nameof(car));
        }

        public void Add(CarModificator  carModificator)
        {
            if (_next != null) _next.Add(carModificator);
            else _next = carModificator;
        }

        public virtual void Handle() => _next?.Handle();
    }

    public class DoubleValueModificator : CarModificator
    {
        public DoubleValueModificator(Car car) : base(car)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Doubling {_car.Name}'s value.");
            _car.Value *= 2;
            base.Handle();
        }
    }

    public class DecreaseValueModificator : CarModificator
    {
        public DecreaseValueModificator(Car car): base(car)
        {

        }

        public override void Handle()
        {
            Console.WriteLine($"Decreasing {_car.Name}'s value.");
            _car.Value -= 1;
            base.Handle();
        }
    }
}
