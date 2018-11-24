using System;
using DesignPatterns.Builder;
using DesignPatterns.Factory;
using DesignPatterns.Prototype;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = new Line {Start = new Prototype.Point {X = 0, Y = 0}, End = new Prototype.Point {X = 1, Y = 1}};

            var line2 = line.DeepCopy();
            line2.Start = new Prototype.Point {X = 2, Y = 2};

            Console.ReadKey();
        }
    }
}