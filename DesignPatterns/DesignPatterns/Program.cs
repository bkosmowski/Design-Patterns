using System;
using DesignPatterns.Bridge;
using DesignPatterns.Builder;
using DesignPatterns.Factory;
using DesignPatterns.Prototype;
using DesignPatterns.Singleton;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new Renderer().Demo();
            Console.ReadKey();
        }
    }
}