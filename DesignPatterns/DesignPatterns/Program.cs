using System;
using DesignPatterns.Builder;
using DesignPatterns.Factory;
using DesignPatterns.Prototype;
using DesignPatterns.Singleton;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var isSingleton = SingletonTester.IsSingleton(() => Database.Instance);
            Console.ReadKey();
        }
    }
}