using System;
using System.Collections.Generic;
using DesignPatterns.Bridge;
using DesignPatterns.Composite;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = new List<IValueContainer>
                {
                    new SingleValue {Value = 0},
                    new SingleValue {Value = 1},
                    new SingleValue {Value = 2}
                }
                .Sum();

            Console.ReadKey();
        }
    }
}