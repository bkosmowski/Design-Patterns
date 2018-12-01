using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;

namespace DesignPatterns.Flyweight
{
    public class User
    {
        private readonly string _fullName;

        public User(string fullName)
        {
            _fullName = fullName;
        }
    }

    public class OptimizedUser
    {
        private static List<string> _strings = new List<string>();

        private readonly int[] _names;

        public OptimizedUser(string fullName)
        {
            int GetOrAdd(string s)
            {
                var idx = _strings.IndexOf(s);
                if (idx != -1) return idx;
                _strings.Add(s);
                return _strings.Count - 1;
            }

            _names = fullName.Split(' ').Select(GetOrAdd).ToArray();
        }

        public string FullName => string.Join(" ", _names);
    }

    [TestFixture]
    public class TestFlyweight
    {   private void ForceGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private string RandomString()
        {
            Random rand = new Random();
            return new string(
                Enumerable.Range(0, 10).Select(i => (char)('a' + rand.Next(26))).ToArray());
        }

        [Test]
        public void TestNonOptimizedUserMemoryUsage()
        {
            var users = new List<User>();
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    users.Add(new User($"{firstName} {lastName}"));
                }
            }
            
            ForceGC();

            dotMemory.Check(memory =>
            {
                Console.WriteLine(memory.SizeInBytes);
            });
        }

        [Test]
        public void TestOptimizedUserMemoryUsage()
        {
            var users = new List<OptimizedUser>();
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    users.Add(new OptimizedUser($"{firstName} {lastName}"));
                }
            }

            ForceGC();

            dotMemory.Check(memory =>
            {
                Console.WriteLine(memory.SizeInBytes);
            });
        }
    }
}
