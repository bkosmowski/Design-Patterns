using System;
using System.Text;
using DesignPatterns.Visitor;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringBuilder = new StringBuilder();
            var expression = new AdditionExpression(new AdditionExpression(new DoubleExpression(1), new DoubleExpression(2)), new DoubleExpression(3));
            expression.Print(stringBuilder);
            Console.WriteLine(stringBuilder);

            Console.ReadKey();
        }
    }
}