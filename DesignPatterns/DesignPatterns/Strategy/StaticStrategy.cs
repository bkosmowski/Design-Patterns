using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy
{
    public class StaticTextProcessor<LS> where LS : IListStrategy, new()
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        private readonly IListStrategy _listStrategy = new LS();

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

    public class StaticStrategy
    {
        public void Demo()
        {
            var staticTextProcessor1 = new StaticTextProcessor<MarkdownListStrategy>();
            staticTextProcessor1.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(staticTextProcessor1);

            var staticTextProcessor2 = new StaticTextProcessor<HtmlListStrategy>();
            staticTextProcessor2.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(staticTextProcessor2);
        }
    }
}
