using System;
using System.Collections.Generic;

namespace DesignPatterns.Factory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice but I'd prefer it without sugar.");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffee is delicious!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        private readonly List<(string, IHotDrinkFactory)> _factories = new List<(string, IHotDrinkFactory)>();
        public HotDrinkMachine()
        {
            foreach (var type in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(type) && type.IsInterface == false)
                {
                    _factories.Add((type.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory) Activator.CreateInstance(type)));
                }
            }
        }

        public IHotDrink PrepareDrink()
        {
            Console.WriteLine("Available drinks");
            for (var index = 0; index < _factories.Count; index++)
            {
                var tuple = _factories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out var i)
                    && i >= 0
                    && i < _factories.Count)
                {
                    Console.Write("Specify amount: ");
                    s = Console.ReadLine();
                    if (s != null
                        && int.TryParse(s, out var amount)
                        && amount > 0)
                    {
                        return _factories[i].Item2.Prepare(amount);
                    }
                }

                Console.WriteLine("Incorrect input, try again.");
            }
        }
    }
}
