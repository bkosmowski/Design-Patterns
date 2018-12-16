using System;
using System.Text;

namespace DesignPatterns.Visitor
{
    public interface IVisitor<TVisitable>
    {
        void Visit(TVisitable obj);
    }

    public interface IVisitor { }

    public class AcyclicVisitor
    {
        public abstract class Expression
        {
            public virtual void Accept(IVisitor visitor)
            {
                if (visitor is IVisitor<Expression> typed)
                {
                    typed.Visit(this);
                }
            }
        }

        public class DoubleExpression : Expression
        {
            public double Value { get; }
            public DoubleExpression(double value)
            {
                Value = value;
            }

            public override void Accept(IVisitor visitor)
            {
                if (visitor is IVisitor<DoubleExpression> typed)
                {
                    typed.Visit(this);
                }
            }
        }

        public class AdditionExpression : Expression
        {
            public Expression Left { get; }

            public Expression Right { get; }

            public AdditionExpression(Expression left, Expression right)
            {
                Left = left;
                Right = right;
            }

            public override void Accept(IVisitor visitor)
            {
                if (visitor is IVisitor<AdditionExpression> typed)
                {
                    typed.Visit(this);
                }
            }
        }

        public class ExpressionPrinter : IVisitor,
            IVisitor<Expression>,
            IVisitor<DoubleExpression>,
            IVisitor<AdditionExpression>
        {
            private readonly StringBuilder _stringBuilder = new StringBuilder();

            public void Visit(Expression obj)
            {

            }

            public void Visit(DoubleExpression obj)
            {
                _stringBuilder.Append(obj.Value);
            }

            public void Visit(AdditionExpression obj)
            {
                _stringBuilder.Append("(");
                obj.Left.Accept(this);
                _stringBuilder.Append("+");
                obj.Right.Accept(this);
                _stringBuilder.Append(")");
            }

            public override string ToString() => _stringBuilder.ToString();
        }

        public void Demo()
        {
            var expression = new AdditionExpression(new AdditionExpression(new DoubleExpression(1), new DoubleExpression(2)), new DoubleExpression(3));
            var expressionPrinter = new ExpressionPrinter();
            expressionPrinter.Visit(expression);
            Console.WriteLine(expressionPrinter);
        }
    }
}
