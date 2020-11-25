using System;
using System.Diagnostics;

namespace SOLID
{
    class ProgramOpenClose
    {
        static void Main(string[] args)
        {
            var apple = new Product("apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            var products = new[] { apple, tree, house };

            var filter = new BetterFiler();
            foreach (var item in filter.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Green), new SizeSpecification(Size.Large))))
            {
                Debug.WriteLine($"{item.Name} - {item.Color}, {item.Size}");
            }
        }
    }

    
}
