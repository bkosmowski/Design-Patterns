using System;
using DesignPatterns.Builder;
using DesignPatterns.Factory;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new HotDrinkMachine().PrepareDrink();

            Console.ReadKey();
        }
    }
}