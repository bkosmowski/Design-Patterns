using System;
using DesignPatterns.Visitor;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new AcyclicVisitor().Demo();

            Console.ReadKey();
        }
    }
}