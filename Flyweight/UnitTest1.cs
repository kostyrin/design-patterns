using JetBrains.dotMemoryUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Flyweight
{
    public class UnitTest1
    {
        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void TestUser()
        {
            var firstNames = Enumerable.Range(0, 100).Select(x => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(x => RandomString());

            var users = new List<User>();
            foreach (var firstName in firstNames)
                foreach (var lastName in lastNames)
                    users.Add(new User($"{firstName} {lastName}"));

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            dotMemory.Check(m => Console.WriteLine(m.SizeInBytes));
        }

        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void TestUser2()
        {
            Console.WriteLine("here");
            var firstNames = Enumerable.Range(0, 100).Select(x => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(x => RandomString());

            var users = new List<User2>();
            foreach (var firstName in firstNames)
                foreach (var lastName in lastNames)
                    users.Add(new User2($"{firstName} {lastName}"));

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            dotMemory.Check(m => Console.WriteLine(m.SizeInBytes));
        }

        private string RandomString()
        {
            var random = new Random();
            return new string(Enumerable.Range(0, 10)
                .Select(i => (char)('a' + random.Next(26)))
                .ToArray());
        }
    }

    public class User
    {
        private string _fullname;

        public User(string fullname)
        {
            _fullname = fullname;
        }
    }

    public class User2
    {
        static List<string> strings = new List<string>();
        private int[] names;

        public User2(string fullName)
        {
            int getOrAdd(string s)
            {
                int ind = strings.IndexOf(s);
                if (ind != -1) return ind;

                strings.Add(s);
                return strings.Count - 1;
            }

            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(" ", names.Select(i => strings[i]));
    }
}
