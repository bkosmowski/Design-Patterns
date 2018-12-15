using System;
using DesignPatterns.Observer;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new EventObserver().Demo();

            Console.ReadKey();
        }
    }
}