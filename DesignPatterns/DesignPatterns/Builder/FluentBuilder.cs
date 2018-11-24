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

    public class CodeBuilder
    {
        private CodeElement _class = new CodeElement();

        public CodeBuilder(string className)
        {
            _class.Name = className;
        }

        public CodeBuilder AddChild(string childName, string childText)
        {
            _class.Elements.Add(new CodeElement(childName, childText));
            return this;
        }

        public override string ToString()
        {
            return _class.ToString();
        }
    }

    public class CodeElement
    {
        public string Name { get; set; };
        public readonly List<CodeElement> Elements = new List<CodeElement>();
        
        private readonly string _text;
        private const int IndentSize = 2;

        public CodeElement()
        {
            
        }
        
        public CodeElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

        private string ToStringImpl(int indent)
        {
            var stringBuilder = new StringBuilder();
            var i = new string(' ', IndentSize * indent);
            stringBuilder.Append($"{i}<{Name}>\n");
            stringBuilder.Append($"{i}{{");
            if (string.IsNullOrWhiteSpace(_text) == false)
            {
                stringBuilder.Append(new string(' ', IndentSize * (indent + 1)));
            }

            foreach (var element in Elements)
            {
                stringBuilder.Append(element.ToStringImpl(indent + 1));
            }
            
            stringBuilder.Append(${})
        }
    }
}