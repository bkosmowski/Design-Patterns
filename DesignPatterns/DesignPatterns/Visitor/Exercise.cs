using System.Text;

namespace DesignPatterns.Visitor
{
    public class Exercise
    {
        public abstract class ExpressionVisitor
        {
            public abstract void Visit(Value value);
            public abstract void Visit(AdditionExpression additionExpression);
            public abstract void Visit(MultiplicationExpression multiplicationExpression);
        }

        public abstract class Expression
        {
            public abstract void Accept(ExpressionVisitor ev);
        }

        public class Value : Expression
        {
            public readonly int TheValue;

            public Value(int value)
            {
                TheValue = value;
            }

            public override void Accept(ExpressionVisitor ev)
            {
                ev.Visit(this);
            }
        }

        public class AdditionExpression : Expression
        {
            public readonly Expression LHS, RHS;

            public AdditionExpression(Expression lhs, Expression rhs)
            {
                LHS = lhs;
                RHS = rhs;
            }

            // todo
            public override void Accept(ExpressionVisitor ev)
            {
                ev.Visit(this);
            }
        }

        public class MultiplicationExpression : Expression
        {
            public readonly Expression LHS, RHS;

            public MultiplicationExpression(Expression lhs, Expression rhs)
            {
                LHS = lhs;
                RHS = rhs;
            }

            public override void Accept(ExpressionVisitor ev)
            {
                ev.Visit(this);
            }
        }

        public class ExpressionPrinter : ExpressionVisitor
        {
            private readonly StringBuilder _stringBuilder = new StringBuilder();
            public override void Visit(Value value)
            {
                _stringBuilder.Append(value.TheValue);
            }

            public override void Visit(AdditionExpression additionExpression)
            {
                _stringBuilder.Append("(");
                additionExpression.LHS.Accept(this);
                _stringBuilder.Append("+");
                additionExpression.RHS.Accept(this);
                _stringBuilder.Append(")");
            }
            
            public override void Visit(MultiplicationExpression multiplicationExpression)
            {
                multiplicationExpression.LHS.Accept(this);
                _stringBuilder.Append("*");
                multiplicationExpression.RHS.Accept(this);
            }

            public override string ToString()
            {
                return _stringBuilder.ToString();
            }
        }
    }
}
