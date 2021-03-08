using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralDecorator
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon// no need for interfaces
    {
        private int _age;
        private readonly Bird _bird;
        private readonly Lizard _lizard;
        public Dragon(Bird bird, Lizard lizard)
        {
            _bird = bird;
            _lizard = lizard;
        }
        public int Age
        {
            get => _age;
            set => _age = _lizard.Age = _bird.Age = value;
        }

        public string Fly()
        {
            return _bird.Fly();
        }

        public string Crawl()
        {
            return _lizard.Crawl();
        }
    }
}
