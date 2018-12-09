using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Interpreter
{
    public enum Type
    {
        Integer,
        Plus,
        Minus,
        LeftBracket,
        RightBracket
    }

    public class Token
    {
        public Token(Type type, string text)
        {
            Type = type;
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public Type Type { get; }

        public string Text { get; }

        public override string ToString()
        {
            return $"`{Text}`";
        }
    }

    public class Lexer
    {
        public List<Token> Lex(string text)
        {
            var result = new List<Token>();

            for (var i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '+':
                        result.Add(new Token(Type.Plus, "+"));
                        break;
                    case '-':
                        result.Add(new Token(Type.Minus, "-"));
                        break;
                    case '(':
                        result.Add(new Token(Type.LeftBracket, "("));
                        break;
                    case ')':
                        result.Add(new Token(Type.RightBracket, ")"));
                        break;
                    default:
                        var stringBuilder = new StringBuilder(text[i].ToString());
                        for (var j = i + 1; j < text.Length; ++j)
                        {
                            if (char.IsDigit(text[j]))
                            {
                                stringBuilder.Append(text[j]);
                                ++i;
                            }
                            else
                            {
                                result.Add(new Token(Type.Integer, stringBuilder.ToString()));
                                break;
                            }
                        }
                        break;
                }
            }

            return result;
        }
    }
}
