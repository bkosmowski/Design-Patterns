using System;

namespace DesignPatterns.TemplateMethod
{
    public abstract class Game
    {
        public void Run()
        {
            Start();
            while (!HaveWinner)
            {
                TakeTurn();
            }
            Console.WriteLine($"Player {WinningPlayer} wins.");
        }

        protected abstract void Start();
        protected abstract bool HaveWinner { get; }
        protected abstract void TakeTurn();
        protected abstract int WinningPlayer { get; }

        protected int CurrentPlayer;
        protected readonly int NumberOfPlayers;

        protected Game(int numberOfPlayers)
        {
            this.NumberOfPlayers = numberOfPlayers;
        }
    }

    // simulate a game of chess
    public class Chess : Game
    {
        private readonly int _maxTurns = 10;
        private int _turn = 1;

        public Chess() : base(2)
        {
        }

        protected override void Start()
        {
            Console.WriteLine($"Starting a game of chess with {NumberOfPlayers} players.");
        }

        protected override bool HaveWinner => _turn == _maxTurns;


        protected override void TakeTurn()
        {
            Console.WriteLine($"Turn {_turn++} taken by player {CurrentPlayer}.");
            CurrentPlayer = (CurrentPlayer + 1) % NumberOfPlayers;
        }

        protected override int WinningPlayer => CurrentPlayer;
    }
}
