using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerChain
{
    public class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        private Maintenance Maintenance { get; set; }

        public Car(Maintenance maintenance, string name, int value)
        {
            Maintenance = maintenance;
            Name = name;
            Speed = value;
        }

        public override string ToString()
        {
            return $"Name:{Name}, Speed:{Speed}, Maintenance:{Maintenance}, {ForwardSpeed}, {RearSpeed}";
        }

        public int ForwardSpeed
        {
            get
            {
                var query = new Query(Name, Argument.Forward, Speed);
                Maintenance.PerformQuery(this, query);
                return query.Value;
            }
        }

        public int RearSpeed
        {
            get
            {
                var query = new Query(Name, Argument.Rear, Speed);
                Maintenance.PerformQuery(this, query);
                return query.Value;
            }
        }

    }

    
    public enum Argument
    {
        Forward,
        Rear
    }
    public class Query
    {
        public string CarName { get; set; }
        public Argument WhatToQuery { get; set; }
        public int Value { get; set; }

        public Query(string carName, Argument argument, int value)
        {
            CarName = carName;
            WhatToQuery = argument;
            Value = value;
        }
    }

    public class Maintenance //mediator pattern
    {
        public event EventHandler<Query> Queries;
        public void PerformQuery(object obj, Query query)
        {
            Queries?.Invoke(obj, query);
        }
    }

    public abstract class CarModifier : IDisposable
    {
        protected Maintenance Maintenance;
        protected Car Car;

        protected CarModifier(Maintenance maintenance, Car car)
        {
            Maintenance = maintenance;
            Car = car;
            Maintenance.Queries += Handle;
        }

        protected abstract void Handle(object sender, Query q);

        public void Dispose()
        {
            Maintenance.Queries -= Handle;
        }

        public class DoubleModifier : CarModifier
        {
            public DoubleModifier(Maintenance maintenance, Car car) : base(maintenance, car)
            {
            }

            protected override void Handle(object sender, Query q)
            {
                if (q.CarName == Car.Name && q.WhatToQuery == Argument.Forward)
                {
                    q.Value *= 2;
                }
            }
        }

        public class DecreaseModifier : CarModifier
        {
            public DecreaseModifier(Maintenance maintenance, Car car) : base(maintenance, car)
            {
            }

            protected override void Handle(object sender, Query q)
            {
                if (q.CarName == Car.Name && q.WhatToQuery == Argument.Rear)
                {
                    q.Value -= 20;
                }
            }
        }
    }
}
