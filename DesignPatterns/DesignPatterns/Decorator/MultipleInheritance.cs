using System;

namespace DesignPatterns.Decorator
{
    public interface IBird
    {
        void Fly();

        int Weight { get; set; }
    }

    public class Bird : IBird
    {
        public void Fly() => Console.WriteLine("I can fly in the sky!");
        public int Weight { get; set; }
    }

    public interface ILizard
    {
        void Crawl();

        int Weight { get; set; }
    }

    public class Lizard : ILizard
    {
        public void Crawl() => Console.WriteLine("I can crawl in the dirt!");
        public int Weight { get; set; }
    }

    public class Dragon : ILizard, IBird //Lizard, Bird
    {
        private readonly Lizard _lizard = new Lizard();
        private readonly Bird _bird = new Bird();

        public void Crawl()
        {
            _lizard.Crawl();
        }

        public void Fly()
        {
            _bird.Fly();
        }

        private int _weight;

        public int Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                _lizard.Weight = value;
                _bird.Weight = value;
            }
        }
    }
}
