using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy
{
    public enum OutputFormat
    {
        Markdown,
        Html
    }

    public interface IListStrategy
    {
        void Start(StringBuilder sb);
        void End(StringBuilder sb);
        void AddListItem(StringBuilder sb, string item);
    }

    public class MarkdownListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
        }

        public void End(StringBuilder sb)
        {
        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" * {item}");
        }
    }

    public class HtmlListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
            sb.AppendLine("<ul>");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("</ul>");
        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"  <li>{item}</li>");
        }
    }

    public class TextProcessor
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        private IListStrategy _listStrategy;

        public void SetOutputFormat(OutputFormat format)
        {
            switch (format)
            {
                case OutputFormat.Markdown:
                    _listStrategy = new MarkdownListStrategy();
                    break;
                case OutputFormat.Html:
                    _listStrategy = new HtmlListStrategy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

        public void AppendList(IEnumerable<string> items)
        {
            _listStrategy.Start(_stringBuilder);
            foreach (var item in items)
                _listStrategy.AddListItem(_stringBuilder, item);
            _listStrategy.End(_stringBuilder);
        }

        public void Clear()
        {
            _stringBuilder.Clear();
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }

    public class DynamicStrategy
    {
        public void Demo()
        {
            var textProcessor = new TextProcessor();
            textProcessor.SetOutputFormat(OutputFormat.Markdown);
            textProcessor.AppendList(new[] {"foo", "bar", "baz"});
            Console.WriteLine(textProcessor);

            textProcessor.Clear();
            textProcessor.SetOutputFormat(OutputFormat.Html);
            textProcessor.AppendList(new[] {"foo", "bar", "baz"});
            Console.WriteLine(textProcessor);
        }
    }
}
