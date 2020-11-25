using System;

namespace Prototype
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Xml.Serialization;

    namespace Coding.Exercise
    {
        [Serializable]
        public class Point
        {
            public int X, Y;
        }

        [Serializable]
        public class Line
        {
            public Point Start, End;

            public Line DeepCopy()
            {
                //return new Line { Start = new Point { X = Start.X, Y = Start.Y }, End = new Point { X = Start.X, Y = Start.Y }}
                var s = new MemoryStream();
                var formatter = new BinaryFormatter();
                formatter.Serialize(s, this);
                s.Seek(0, SeekOrigin.Begin);
                object copy = formatter.Deserialize(s);
                s.Close();
                return (Line)copy;
            }
        }
    }

}
