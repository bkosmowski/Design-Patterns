namespace DesignPatterns.Proxy
{
    public interface IPerson
    {
        int Age { get; set; }
        string Drink();
        string Drive();
        string DrinkAndDrive();
    }

    public class Person : IPerson
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson : IPerson
    {
        private readonly Person _person;

        public ResponsiblePerson(Person person)
        {
            _person = person;
        }

        public int Age
        {
            get => _person.Age;
            set => _person.Age = value;
        }

        public string Drink()
        {
            return _person.Age < 18 ? "too young" : _person.Drink();
        }

        public string Drive()
        {
            return _person.Age < 16 ? "too young" : _person.Drive();
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }
}
