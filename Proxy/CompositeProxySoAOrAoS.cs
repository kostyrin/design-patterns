using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.Aos
{
    class Creature
    {
        public byte Age { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Creatures
    {
        private readonly int size;
        private readonly byte[] age;
        private readonly int[] x, y;

        public Creatures(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct CreatureProxy
        {
            private readonly Creatures creatures;
            private readonly int index;

            public CreatureProxy(Creatures creatures, int index)
            {
                this.creatures = creatures;
                this.index = index;
            }

            public ref byte Age => ref creatures.age[index];
            public ref int X => ref creatures.x[index];
            public ref int Y => ref creatures.y[index];
        }

        public IEnumerator<CreatureProxy> GetEnumerator()
        {
            for (int pos = 0; pos < size; ++pos)
                yield return new CreatureProxy(this, pos);
        }

        
    }
}
