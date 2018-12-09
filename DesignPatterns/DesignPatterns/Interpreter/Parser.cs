using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.dotMemoryUnit.Util;

namespace DesignPatterns.Interpreter
{
    public interface IElement
    {
        int Value { get; }
    }

    public class Integer : IElement
    {
        public Integer(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public enum BinaryOperationType
    {
        Addition,
        Subtraction
    }

    public class BinaryOperation : IElement
    {
        public IElement LeftElement { get; set; }

        public IElement RightElement { get; set; }

        public BinaryOperationType Type { get; set; }

        public int Value
        {
            get
            {
                switch (Type)
                {
                    case BinaryOperationType.Addition:
                        return LeftElement.Value + RightElement.Value;
                    case BinaryOperationType.Subtraction:
                        return LeftElement.Value - RightElement.Value;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public class Parser
    {
        public IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            var haveLHS = false;
            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.Type)
                {
                    case Type.Integer:
                        var integer = new Integer(int.Parse(token.Text));
                        if (!haveLHS)
                        {
                            result.LeftElement = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.RightElement = integer;
                        }
                        break;
                    case Type.Plus:
                        result.Type = BinaryOperationType.Addition;
                        break;
                    case Type.Minus:
                        result.Type = BinaryOperationType.Subtraction;
                        break;
                    case Type.LeftBracket:
                        int j = i;
                        for (; j < tokens.Count; ++j)
                            if (tokens[j].Type == Type.RightBracket)
                                break;
                        var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                        var element = Parse(subexpression);
                        if (!haveLHS)
                        {
                            result.LeftElement = element;
                            haveLHS = true;
                        }
                        else result.RightElement = element;

                        i = j;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return result;
        }
    }
}
