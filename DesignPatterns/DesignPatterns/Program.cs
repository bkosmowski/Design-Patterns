using System;
using System.Collections.Generic;
using DesignPatterns.Bridge;
using DesignPatterns.Composite;
using DesignPatterns.Decorator;
using DesignPatterns.Flyweight;
using DesignPatterns.Proxy;
using Square = DesignPatterns.Decorator.Square;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProtectionProxy().Demo();

            Console.ReadKey();
        }
    }
}