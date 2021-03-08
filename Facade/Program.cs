using System;
using System.Text;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var magicSquareGenerator = new MagicSquareGenerator();
            var result = magicSquareGenerator.Generate(3);
            var sb = new StringBuilder();

            foreach (var row in result)
            {
                
                foreach (var line in row)
                {
                    sb.Append(line);
                    sb.Append(" ");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
    }
}
