using System;
using System.Collections.Generic;
using DesignPatterns.Bridge;
using DesignPatterns.Composite;
using DesignPatterns.Decorator;
using DesignPatterns.Flyweight;
using Square = DesignPatterns.Decorator.Square;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            Console.WriteLine(sentence);

            Console.ReadKey();
        }
    }
}