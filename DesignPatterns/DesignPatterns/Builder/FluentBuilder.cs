using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    public class FluentBuilder
    {
        public void Demo()
        {
            var htmlBuilder = new HtmlBuilder("ul");
            htmlBuilder.AddChild("li", "hello").AddChild("li", "word");
            Console.WriteLine(htmlBuilder.ToString());
        }

        public static void DemoGeneric()
        {
            var me = Person.New.Called("Błażej").WorksAsA("Xamarin developer").Builder();
            Console.WriteLine(me);
        }

        private class HtmlBuilder
        {
            private readonly string _rootName;
            HtmlElement _root = new HtmlElement();

            public HtmlBuilder(string rootName)
            {
                _rootName = rootName;
                _root.Name = rootName;
            }

            public HtmlBuilder AddChild(string childName, string childText)
            {
                var htmlElement = new HtmlElement(childName, childText);
                _root.Elements.Add(htmlElement);
                return this;
            }

            public override string ToString()
            {
                return _root.ToString();
            }

            public void Clear()
            {
                _root = new HtmlElement {Name = _rootName};
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public class Builder : PersonJobBuilder<Builder>
        {
        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)} : {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person _person = new Person();

        public Person Builder()
        {
            return _person;
        }
    }

    public class PersonInfoBuilder<T> : PersonBuilder where T : PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            _person.Name = name;
            return (T) this;
        }
    }

    public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>> where T : PersonJobBuilder<T>
    {
        public T WorksAsA(string position)
        {
            _person.Position = position;
            return (T) this;
        }
    }
}