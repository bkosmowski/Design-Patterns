using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Memento
{
    public class Exercise
    {
        public class Token
        {
            public Token(int value)
            {
                Value = value;
            }

            public int Value { get; set; }
        }

        public class Memento
        {
            public List<Token> Tokens { get; set; }
        }

        public class TokenMachine
        {
            public List<Token> Tokens = new List<Token>();

            public Memento AddToken(int value)
            {
                Tokens.Add(new Token(value));
                var memento = new Memento { Tokens = Tokens.Select(t => new Token(t.Value)).ToList() };
                return memento;
            }

            public Memento AddToken(Token token)
            {
                Tokens.Add(token);
                var memento = new Memento { Tokens = Tokens.Select(t => new Token(t.Value)).ToList() };
                return memento;
            }

            public void Revert(Memento m)
            {
                Tokens = m.Tokens.ToList();
            }
        }
    }
}
