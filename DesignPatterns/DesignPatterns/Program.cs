using System;
using System.Collections.Generic;
using DesignPatterns.Bridge;
using DesignPatterns.Composite;
using DesignPatterns.Decorator;
using Square = DesignPatterns.Decorator.Square;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Transparency(new Color(new Square(10), "Red"), 0.76f).AsString());

            Console.ReadKey();
        }
    }
}