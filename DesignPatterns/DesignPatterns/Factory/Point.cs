using System;

namespace DesignPatterns.Factory
{
    public class Point
    {
        private readonly double _x;
        private readonly double _y;

        private Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"{nameof(_x)}: {_x}, {nameof(_y)}: {_y}";
        }

        public static class FactoryPoint
        {
            public static Point CartesianPoint(double x, double y) => new Point(x, y);

            public static Point PolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
}
