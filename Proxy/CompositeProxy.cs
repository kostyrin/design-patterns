using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public class Creatures
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public Creatures(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }


        public class CreatureProxy
        {
            private readonly Creatures _creator;
            private readonly int _index;

            public CreatureProxy(Creatures creatures, int index)
            {
                _creator = creatures;
                _index = index;
            }

            public ref byte Age => ref _creator.age[_index];
            public ref int X => ref _creator.x[_index];
            public ref int Y => ref _creator.y[_index];
        }

        public IEnumerator<CreatureProxy> GetEnumerator()
        {
            for (int pos = 0; pos < size; ++pos)
                yield return new CreatureProxy(this, pos);
        }


      //  var creatures2 = new Creatures(100);
      //foreach (var c in creatures2)
      //{
      //  c.X++;
      //}
}

    
}
