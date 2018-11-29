using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Composite
{
    public class GraphicObject
    {
        public virtual string Name { get; set; } = "Group";

        public string Color { get; set; }

        private readonly Lazy<List<GraphicObject>> _children = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => _children.Value;

        private void Print(StringBuilder stringBuilder, int depth)
        {
            stringBuilder.Append(new string('*', depth))
                .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
                .AppendLine($"{Name}");

            foreach (var child in Children)
            {
                child.Print(stringBuilder, depth + 1);
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            Print(stringBuilder, 0);
            return stringBuilder.ToString();
        }

        public class Circle : GraphicObject
        {
            public override string Name => "Circle";
        }

        public class Square : GraphicObject
        {
            public override string Name => "Square";
        }
    }
}
