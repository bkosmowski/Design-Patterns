using System;
using System.Linq;
using DesignPatterns.Iterator;
using DesignPatterns.Mediator;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var room = new ChatRoom();

            var john = new Person("John");
            var jane = new Person("Jane");

            room.Join(john);
            room.Join(jane);

            john.Say("hi room");
            jane.Say("oh, hey john");

            var simon = new Person("Simon");
            room.Join(simon);
            simon.Say("hi everyone!");

            jane.PrivateMessage("Simon", "glad you could join us!");

            Console.ReadKey();
        }
    }
}