using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Interpreter
{
    public class ExpressionProcessor
    {
        private enum OperationType
        {
            Plus,
            Minus,
            Integer,
            Letter
        }

        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            var tokens = Lex(expression);

            return Parse(tokens);
        }

        private List<Token> Lex(string expression)
        {
            var tokens = new List<Token>();
            for (var i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '+':
                        tokens.Add(new Token(OperationType.Plus, "+"));
                        break;
                    case '-':
                        tokens.Add(new Token(OperationType.Minus, "-"));
                        break;
                    default:
                        var sb = new StringBuilder();

                        var isDigit = char.IsDigit(expression[i]);

                        if (isDigit)
                        {
                            for (var j = i; j < expression.Length; ++j)
                            {
                                if (char.IsDigit(expression[j]))
                                {
                                    sb.Append(expression[j]);
                                    i = j;
                                }
                                else
                                {
                                    tokens.Add(new Token(OperationType.Integer, sb.ToString()));
                                    break;
                                }

                                if (j == expression.Length - 1)
                                {
                                    tokens.Add(new Token(OperationType.Integer, sb.ToString()));
                                    i = j;
                                }
                            }
                        }
                        else
                        {
                            for (var j = i; j < expression.Length; j++)
                            {
                                if (char.IsDigit(expression[j]) == false)
                                {
                                    sb.Append(expression[j]);
                                    i = j;
                                }
                                else
                                {
                                    tokens.Add(new Token(OperationType.Letter, sb.ToString()));
                                    break;
                                }

                                if (j == expression.Length - 1)
                                {
                                    tokens.Add(new Token(OperationType.Letter, sb.ToString()));
                                    i = j;
                                }
                            }
                        }
                       
                        break;
                }
            }

            return tokens;
        }

        private int Parse(IReadOnlyList<Token> tokens)
        {
            var lastBinaryOperation = BinaryOperationType.None;
            var currentValue = 0;

            foreach (var token in tokens)
            {
                switch (token.Type)
                {
                    case OperationType.Integer:
                        var parsedValue = int.Parse(token.Text);
                        switch (lastBinaryOperation)
                        {
                            case BinaryOperationType.None:
                                currentValue = parsedValue;
                                break;
                            case BinaryOperationType.Addition:
                                currentValue += parsedValue;
                                break;
                            case BinaryOperationType.Subtraction:
                                currentValue -= parsedValue;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case OperationType.Letter:
                        if (token.Text.Length > 1 || Variables.ContainsKey(token.Text.First()) == false)
                        {
                            return 0;
                        }

                        var dictionaryValue = Variables[token.Text.First()];

                        switch (lastBinaryOperation)
                        {
                            case BinaryOperationType.None:
                                currentValue = dictionaryValue;
                                break;
                            case BinaryOperationType.Addition:
                                currentValue += dictionaryValue;
                                break;
                            case BinaryOperationType.Subtraction:
                                currentValue -= dictionaryValue;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case OperationType.Plus:
                        lastBinaryOperation = BinaryOperationType.Addition;
                        break;
                    case OperationType.Minus:
                        lastBinaryOperation = BinaryOperationType.Subtraction;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return currentValue;
        }

        private class Token
        {
            public Token(OperationType type, string text)
            {
                Type = type;
                Text = text ?? throw new ArgumentNullException(nameof(text));
            }

            public OperationType Type { get; }

            public string Text { get; }
        }

        private enum BinaryOperationType
        {
            None,
            Addition,
            Subtraction
        }
    }
}
