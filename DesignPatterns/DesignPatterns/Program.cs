using System;
using DesignPatterns.Builder;
using DesignPatterns.Factory;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var personFactory = new PersonFactory();

            var person1 = personFactory.CreatePerson("Tom");

            var person2 = personFactory.CreatePerson("John");

            var person3 = personFactory.CreatePerson("Frank");

            Console.ReadKey();
        }
    }
}