using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralDecorator
{
    public abstract class Car
    {
        public virtual string AsString() => string.Empty;
    }

    public sealed class Honda : Car
    {
        private int _volume;

        public Honda() : this(0)
        {

        }

        public Honda(int volume)
        {
            _volume = volume;
        }

        public void Tune(int additional)
        {
            _volume *= additional;
        }

        public override string AsString() => $"A Honda of volume {_volume}";
    }

    public sealed class Man : Car
    {
        private int _capacity;

        public Man() : this(0)
        {

        }

        public Man(int capacity)
        {
            _capacity = capacity;
        }

        public void Tune(int additional)
        {
            _capacity *= additional;
        }

        public override string AsString() => $"A Man of capacity {_capacity}";
    }
}
