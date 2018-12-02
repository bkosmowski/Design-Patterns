using System;
using DesignPatterns.Proxy;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new PropertyProxy().Demo();

            Console.ReadKey();
        }
    }
}