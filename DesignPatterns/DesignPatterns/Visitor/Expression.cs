using System.Text;

namespace DesignPatterns.Visitor
{
    public abstract class Expression
    {
        public abstract void Print(StringBuilder stringBuilder);
    }

    public class DoubleExpression : Expression
    {
        private readonly double _value;

        public DoubleExpression(double value)
        {
            _value = value;
        }

        public override void Print(StringBuilder stringBuilder)
        {
            stringBuilder.Append(_value);
        }
    }

    public class AdditionExpression : Expression
    {
        private readonly Expression _left;
        private readonly Expression _right;

        public AdditionExpression(Expression left, Expression right)
        {
            _left = left;
            _right = right;
        }

        public override void Print(StringBuilder stringBuilder)
        {
            stringBuilder.Append("(");
            _left.Print(stringBuilder);
            stringBuilder.Append("+");
            _right.Print(stringBuilder);
            stringBuilder.Append(")");
        }
    }
}
