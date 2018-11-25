using System;

namespace DesignPatterns.Singleton
{
    public class Monostate
    {
        public void Demo()
        {
            var ceo1 = new CEO {Name = "Adam", Age = 55};
            
            var ceo2 = new CEO {Age = 50};

            Console.WriteLine($"{nameof(ceo1)} {ceo1}");
            Console.WriteLine($"{nameof(ceo2)} {ceo2}");
        }
    }

    public class CEO
    {
        private static string _name;

        private static int _age;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
}
