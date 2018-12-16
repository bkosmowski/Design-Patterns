using System;
using DesignPatterns.Visitor;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = new AdditionExpression(new AdditionExpression(new DoubleExpression(1), new DoubleExpression(2)), new DoubleExpression(3));
            var expressionPrinter = new ExpressionPrinter();
            expressionPrinter.Visit(expression);
            Console.WriteLine(expressionPrinter.ToString());

            var expressionCalculator = new ExpressionCalculator();
            expressionCalculator.Visit(expression);
            Console.WriteLine($" = {expressionCalculator.Result}");

            Console.ReadKey();
        }
    }
}