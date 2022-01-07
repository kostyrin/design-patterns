using System;
using System.Linq;
using System.Text;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var sententce = new Sentence("hello world");
            sententce[1].Capitalize = true;
            Console.WriteLine(sententce);
            //var magicSquareGenerator = new MagicSquareGenerator();
            //var result = magicSquareGenerator.Generate(3);
            //var sb = new StringBuilder();

            //foreach (var row in result)
            //{

            //    foreach (var line in row)
            //    {
            //        sb.Append(line);
            //        sb.Append(" ");
            //    }
            //    sb.AppendLine();
            //}

            //Console.WriteLine(sb.ToString());
            //Console.ReadLine();
        }
    }


    
}
