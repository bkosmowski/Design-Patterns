using System;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.Proxy;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            new BrokerChain().Demo();

            Console.ReadKey();
        }
    }
}