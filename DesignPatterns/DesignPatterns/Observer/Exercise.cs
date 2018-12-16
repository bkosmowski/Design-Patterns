using System;

namespace DesignPatterns.Observer
{
    public class Exercise
    {
        public class Game
        {
            public event EventHandler<Rat> RatEntered;
            public event EventHandler<Rat> RatUpdate;
            public event EventHandler RatDied;

            public void FireRatEntered(Rat rat)
            {
                RatEntered?.Invoke(this, rat);
            }

            public void FireRatDied()
            {
                RatDied?.Invoke(this, EventArgs.Empty);
            }

            public void UpdateRat(Rat rat)
            {
                RatUpdate?.Invoke(this , rat);
            }
        }

        public class Rat : IDisposable
        {
            private readonly Game _game;
            public int Attack = 1;

            public Rat(Game game)
            {
                _game = game;
                _game.RatEntered += OnRatEntered;
                _game.RatDied += OnRatDied;
                _game.RatUpdate += OnRatUpdate;
                _game.FireRatEntered(this);
            }

            private void OnRatEntered(object sender, Rat rat)
            {
                if (rat != this)
                {
                    Attack++;
                    _game.UpdateRat(rat);
                }
            }

            private void OnRatDied(object sender, EventArgs e)
            {
                Attack--;
            }

            private void OnRatUpdate(object sender, Rat rat)
            {
                if (rat == this)
                    Attack++;
            }


            public void Dispose()
            {
                _game.FireRatDied();
                _game.RatEntered -= OnRatEntered;
                _game.RatDied -= OnRatDied;
            }
        }   
    }
}
