using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace DesignPatterns.Builder
{
    public static class Builder
    {
        public static void Demo()
        {
            var htmlBuilder = new HtmlBuilder("ul");
            htmlBuilder.AddChild("li", "hello");
            htmlBuilder.AddChild("li", "word");
            Console.WriteLine(htmlBuilder.ToString());
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

            public void AddChild(string childName, string childText)
            {
                var htmlElement = new HtmlElement(childName, childText);
                _root.Elements.Add(htmlElement);
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
    
    public class HtmlElement
    {
        public string Name;
        public readonly List<HtmlElement> Elements = new List<HtmlElement>();
        private readonly string _text;
        private const int IndentSize = 2;
        
        public HtmlElement()
        {
        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', IndentSize * indent);
            sb.Append($"{i}<{Name}>\n");
            if (string.IsNullOrWhiteSpace(_text) == false)
            {
                sb.Append(new string(' ', IndentSize * (indent + 1)));
                sb.Append(_text);
                sb.Append("\n");
            }

            foreach (var element in Elements)
            {
                sb.Append(element.ToStringImpl(indent + 1));
            }

            sb.Append($"{i}</{Name}>\n");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}