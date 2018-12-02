using System;

namespace DesignPatterns.Proxy
{
    public class ProtectionProxy
    {
        public void Demo()
        {
            ICar car = new CarProxy(new Driver(17));
            car.Drive();
            car = new CarProxy(new Driver(23));
            car.Drive();
        }
    }

    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car is being driven");
        }
    }
    
    public class Driver
    {
        public Driver(int age)
        {
            Age = age;
        }

        public int Age { get; }
    }

    public class CarProxy : ICar
    {
        private readonly Car _car = new Car();
        private readonly Driver _driver;

        public CarProxy(Driver driver)
        {
            _driver = driver;
        }

        public void Drive()
        {
            if (_driver.Age >= 18)
            {
                _car.Drive();
            }
            else
            {
                Console.WriteLine("Too young");
            }
        }
    }
}
