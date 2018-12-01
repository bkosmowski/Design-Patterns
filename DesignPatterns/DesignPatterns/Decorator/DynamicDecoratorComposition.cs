namespace DesignPatterns.Decorator
{
    public interface IShape
    {
        string AsString();
    }

    public class Square : IShape
    {
        private readonly float _side;

        public Square(float side)
        {
            _side = side;
        }

        public string AsString() => $"A square with side {_side}";
    }

    public class Color: IShape
    {
        private readonly IShape _shape;
        private readonly string _color;

        public Color(IShape shape, string color)
        {
            _shape = shape;
            _color = color;
        }

        public string AsString() => $"{_shape.AsString()} with color {_color}";
    }

    public class Transparency : IShape
    {
        private readonly IShape _shape;
        private readonly float _transparency;

        public Transparency(IShape shape, float transparency)
        {
            _shape = shape;
            _transparency = transparency;
        }

        public string AsString() => $"{_shape.AsString()} with transparency {_transparency * 100.0f}%";
    }
}
