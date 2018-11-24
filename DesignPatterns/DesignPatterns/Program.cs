using System;
using DesignPatterns.Builder;
using DesignPatterns.Factory;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new HotDrinkMachine().PrepareDrink(AvailableDrink.Coffee, 100);
            new HotDrinkMachine().PrepareDrink(AvailableDrink.Tea, 100);

            Console.ReadKey();
        }
    }
}