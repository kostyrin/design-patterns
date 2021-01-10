using System;

namespace Bridge
{
    public interface IRenderer
    {
        void RendererCircle(float radius);
        string WhatToRenderAs { get; }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";

        public void RendererCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius of {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";

        public void RendererCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle with radius of {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer _renderer;

        protected Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public string Name { get; set; }

        public abstract void Draw();
        public abstract void Resize(float factor);

        public override string ToString()
        {
            return $"Drawing {Name} an {_renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triagle";
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Resize(float factor)
        {
            throw new NotImplementedException();
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        } 

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Resize(float factor)
        {
            throw new NotImplementedException();
        }
    }

    public class Circle : Shape
    {
        private float _radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            _radius = radius;
        }
        public override void Draw()
        {
            _renderer.RendererCircle(_radius);
        }

        public override void Resize(float factor)
        {
            _radius *= factor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var renderer = new RasterRenderer();
            var circle = new Circle(renderer, 5);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();

            var triangle = new Triangle(renderer);
            Console.WriteLine(triangle.ToString());

            var renderer2 = new VectorRenderer();
            var triangle2 = new Triangle(renderer2);
            Console.WriteLine(triangle2.ToString());
        }
    }
}
