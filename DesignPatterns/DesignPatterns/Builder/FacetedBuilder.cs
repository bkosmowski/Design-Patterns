using System;

namespace DesignPatterns.Builder
{
    public class FacetedBuilder
    {
        public static void Demo()
        {
            var personBuilder = new PersonBuilder();
            Person person = personBuilder
                .Works
                .At("Fabrikam")
                .AsA("Engineer")
                .Earning(123_000)
                .Lives
                .At("123 London Road")
                .In("London")
                .WithPostcode("12-123");
            Console.WriteLine(person);
        }

        public class Person
        {
            public string StreetAddress { get; set; }
            public string Postcode { get; set; }
            public string City { get; set; }

            public string CompanyName { get; set; }
            public string Position { get; set; }
            public int AnnualIncome { get; set; }

            public override string ToString()
            {
                return
                    $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
            }
        }

        public class PersonBuilder //facade
        {
            protected Person Person = new Person();

            public PersonJobBuilder Works => new PersonJobBuilder(Person);
            
            public PersonAddressBuilder Lives => new PersonAddressBuilder(Person);

            public static implicit operator Person(PersonBuilder personBuilder)
            {
                return personBuilder.Person;
            }
        }

        public class PersonJobBuilder : PersonBuilder
        {
            public PersonJobBuilder(Person person)
            {
                this.Person = person;
            }

            public PersonJobBuilder At(string companyName)
            {
                Person.CompanyName = companyName;
                return this;
            }

            public PersonJobBuilder AsA(string position)
            {
                Person.Position = position;
                return this;
            }

            public PersonJobBuilder Earning(int amount)
            {
                Person.AnnualIncome = amount;
                return this;
            }
        }

        public class PersonAddressBuilder : PersonBuilder
        {
            public PersonAddressBuilder(Person person)
            {
                this.Person = person;
            }

            public PersonAddressBuilder At(string streetAddress)
            {
                Person.StreetAddress = streetAddress;
                return this;
            }

            public PersonAddressBuilder WithPostcode(string postcode)
            {
                Person.Postcode = postcode;
                return this;
            }

            public PersonAddressBuilder In(string city)
            {
                Person.City = city;
                return this;
            }
        }
    }
}