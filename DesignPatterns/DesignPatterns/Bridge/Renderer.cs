using System;

namespace DesignPatterns.Bridge
{
    public interface IShapeRenderer
    {
        void RenderCircle(float radius);
    }

    public class RasterShapeRenderer : IShapeRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle of radius {radius}");
        }
    }

    public class VectorShapeRenderer : IShapeRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public abstract class RendererShape
    {
        protected readonly IShapeRenderer Renderer;

        protected RendererShape(IShapeRenderer renderer)
        {
            Renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : RendererShape
    {
        private float _radius;

        public Circle(IShapeRenderer renderer, float radius) : base(renderer)
        {
            _radius = radius;
        }

        public override void Draw()
        {
            Renderer.RenderCircle(_radius);
        }

        public override void Resize(float factor)
        {
            _radius *= factor;
        }
    }

    public class Renderer
    {
        public void Demo()
        {
            Console.WriteLine("Vector");
            var vector = new VectorShapeRenderer();
            var circle = new Circle(vector, 5);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();

            Console.WriteLine("Raster");
            var raster = new RasterShapeRenderer();
            circle = new Circle(raster, 5);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();
        }
    }
}
