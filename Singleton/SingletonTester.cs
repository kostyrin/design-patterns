using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var obj1 = func();
            var obj2 = func();
            return ReferenceEquals(obj1, obj2);
        }

        public void Single()
        {
            Func<object> factory = () => new object();
            var result = IsSingleton(factory);
        }
    }
}
