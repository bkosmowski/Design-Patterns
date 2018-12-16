using System;
using DesignPatterns.TemplateMethod;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new Chess().Run();
            Console.ReadKey();
        }
    }
}