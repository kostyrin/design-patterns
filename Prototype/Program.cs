using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Prototype.Coding.Exercise;

namespace Prototype
{
    public static class DeepCopyExtensions
    {
        public static T DeepCopy<T>(this T self)
        {
            var s = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(s, self);
            s.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(s);
            s.Close();
            return (T) copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }
        }
    }

    public static class Program
    {
        static void Main(string[] args)
        {
            //var john = new Person() { Names = new []{ "Andrei", "Kostyrin"}, Address = new Address { Street = "London Road", HouseNumber = 123}};
            //var jane = john.DeepCopyXml();
            //jane.Names[0] = "Jane";
            //jane.Address.HouseNumber = 333;

            var line = new Line {Start = new Point {X = 1, Y = 2}, End = new Point {X = 1, Y = 2}};

            var line2 = line.DeepCopy();
            line2.Start.X = 2;
            line2.Start.Y = 3;
        }
    }
}
