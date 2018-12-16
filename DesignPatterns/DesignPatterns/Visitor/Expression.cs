using System;
using System.Text;

namespace DesignPatterns.Visitor
{
    public interface IExpressionVisitor
    {
        void Visit(DoubleExpression de);
        void Visit(AdditionExpression ae);
    }

    public abstract class Expression
    {
        public abstract void Accept(IExpressionVisitor visitor);
    }

    public class DoubleExpression : Expression
    {
        public DoubleExpression(double value)
        {
            Value = value;
        }

        public double Value { get; }
        
        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class AdditionExpression : Expression
    {
        public AdditionExpression(Expression left, Expression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }
        public Expression Left { get; }
        public Expression Right { get; }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ExpressionPrinter : IExpressionVisitor
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public void Visit(DoubleExpression de)
        {
            _sb.Append(de.Value);
        }

        public void Visit(AdditionExpression ae)
        {
            _sb.Append("(");
            ae.Left.Accept(this);
            _sb.Append("+");
            ae.Right.Accept(this);
            _sb.Append(")");
        }

        public override string ToString() => _sb.ToString();
    }

    public class ExpressionCalculator : IExpressionVisitor
    {
        public double Result;

        public void Visit(DoubleExpression de)
        {
            Result = de.Value;
        }

        public void Visit(AdditionExpression ae)
        {
            ae.Left.Accept(this);
            var a = Result;
            ae.Right.Accept(this);
            var b = Result;
            Result = a + b;
        }
    }
}