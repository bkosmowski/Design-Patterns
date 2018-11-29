namespace DesignPatterns.Bridge
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "Drawing {0} as lines";
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "Drawing {0} as pixels";
    }

    public abstract class Shape
    {
        protected readonly IRenderer Renderer;

        protected Shape(IRenderer renderer, string name)
        {
            Renderer = renderer;
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return string.Format(Renderer.WhatToRenderAs, Name);
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer, nameof(Triangle))
        {
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer, nameof(Square))
        {
        }
    }
}
