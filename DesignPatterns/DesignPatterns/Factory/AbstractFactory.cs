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

    public enum AvailableDrink
    {
        Coffee,
        Tea
    }

    public class HotDrinkMachine
    {
        private readonly Dictionary<AvailableDrink, IHotDrinkFactory> _factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                _factories.Add(drink, (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType($"DesignPatterns.Factory.{Enum.GetName(typeof(AvailableDrink), drink)}Factory")));
            }
        }

        public IHotDrink PrepareDrink(AvailableDrink drink, int amount)
        {
            return _factories[drink].Prepare(amount);
        }
    }
}
