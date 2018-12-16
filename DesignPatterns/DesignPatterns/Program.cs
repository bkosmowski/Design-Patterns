using System;
using DesignPatterns.Strategy;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new DynamicStrategy().Demo();

            Console.ReadKey();
        }
    }
}