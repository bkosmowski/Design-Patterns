using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Command;
using DesignPatterns.Interpreter;
using MoreLinq;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var ep = new ExpressionProcessor();
            ep.Variables.Add('x', 5);

            var calculate = ep.Calculate("1");
            var i = ep.Calculate("1+2");
            var calculate1 = ep.Calculate("1+x");
            var i1 = ep.Calculate("1+xy");

            //Assert.That(ep.Calculate("1"), Is.EqualTo(1));

            //Assert.That(ep.Calculate("1+2"), Is.EqualTo(3));

            //Assert.That(ep.Calculate("1+x"), Is.EqualTo(6));

            //Assert.That(ep.Calculate("1+xy"), Is.EqualTo(0));

             Console.ReadKey();
        }
    }
}