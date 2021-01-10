using System;
using System.Collections.Generic;

namespace Singleton
{
    public class SingletonDatabase
    {
        private readonly Dictionary<string, int> _capitals = new Dictionary<string, int>();
        private SingletonDatabase()
        {
            _capitals.Add("Moscow", 123);
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }

        private static Lazy<SingletonDatabase> _instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => _instance.Value;
    }

    //static class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var db = SingletonDatabase.Instance;
    //        var pop = db.GetPopulation("Moscow");
    //    }
    //}
}
