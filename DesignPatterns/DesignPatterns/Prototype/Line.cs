using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Prototype
{
    public class Point
    {
        public int X, Y;

        public Point DeepCopy()
        {
            return new Point { X = X, Y = Y };
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            return new Line { Start = Start.DeepCopy(), End = End.DeepCopy() };
        }
    }
}
