using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralDecorator
{
    public abstract class CarDecorator : Car
    {
        protected internal readonly List<Type> types = new List<Type>();
        protected internal Car _car;

        public CarDecorator(Car car)
        {
            _car = car;
            if (car is CarDecorator cd)
            {
                types.AddRange(cd.types);
            }
        }
    }

    public abstract class CarDecorator<TSelf, THondaPolicy> : CarDecorator where THondaPolicy : CarDecoratorCarPolicy, new()
    {
        protected readonly THondaPolicy policy = new THondaPolicy();

        public CarDecorator(Car car) : base(car)
        {
            if (policy.TypeAdditionAllowed(typeof(TSelf), types))
            {
                types.Add(typeof(TSelf));
            }
        }
    }

    public class CarDecoratorWithPolicy<T> : CarDecorator<T, ThrowOnCarPolicy>
    {
        public CarDecoratorWithPolicy(Car car) : base(car)
        {
        }
    }
}
