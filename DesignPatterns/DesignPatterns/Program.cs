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
            var eb = new EventBroker();

            var referee = new Ref(eb); // order matters here!
            var coach = new FootballCoach(eb);
            var player1 = new FootballPlayer(eb, "John");
            var player2 = new FootballPlayer(eb, "Chris");
            player1.Score();
            player1.Score();
            player1.Score(); // only 2 notifications
            player1.AssaultReferee();
            player2.Score();

            Console.ReadKey();
        }
    }
}