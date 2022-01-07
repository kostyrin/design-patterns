using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public class Percentage
    {
        private readonly float _value;

        internal Percentage(float value)
        {
            _value = value;
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p._value;
        }

        public static Percentage operator +(Percentage a, Percentage b)
        {
            return new Percentage(a._value + b._value);
        }

        public static implicit operator Percentage(int value)
        {
            return value.Percent();
        }

        public bool Equals(Percentage other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Percentage other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_value * 100}%";
        }
    }


    public static class PercentageExtensions
    {
        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }
    }


}
