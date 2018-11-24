using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    public class CodeBuilder
    {
        private readonly CodeElement _class = new CodeElement();

        public CodeBuilder(string className)
        {
            _class.Name = className;
        }

        public CodeBuilder AddField(string childName, string childText)
        {
            _class.Elements.Add(new CodeElement(childName, childText));
            return this;
        }

        public override string ToString()
        {
            return _class.ToString();
        }
    }

    internal class CodeElement
    {
        public string Name { get; set; }
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
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"public class {Name}\n");
            stringBuilder.Append("{\n");
            var i = new string(' ', IndentSize);
            foreach (var element in Elements)
            {
                stringBuilder.Append($"{i}public {element._text} {element.Name};\n");
            }

            stringBuilder.Append('}');

            return stringBuilder.ToString();
        }
    }
}
