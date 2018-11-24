using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private int _currentPersonId;

        public PersonFactory()
        {
            _currentPersonId = 0;
        }

        public Person CreatePerson(string name)
        {
            return new Person
            {
                Name = name,
                Id = _currentPersonId++
            };
        }
    }
}
