using System;
using DesignPatterns.Strategy;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new StaticStrategy().Demo();

            Console.ReadKey();
        }
    }
}