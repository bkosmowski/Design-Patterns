using System;
using System.Numerics;

namespace DesignPatterns.Strategy
{
    public class Exercise
    { 
        public interface IDiscriminantStrategy
        {
            double CalculateDiscriminant(double a, double b, double c);
        }

        public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
        {
            public double CalculateDiscriminant(double a, double b, double c)
            {
                return  b * b - 4 * a * c;
            }
        }

        public class RealDiscriminantStrategy : IDiscriminantStrategy
        {
            public double CalculateDiscriminant(double a, double b, double c)
            {
                var result = b * b - 4 * a * c;
                return result < 0 ? Double.NaN : result;
            }
        }

        public class QuadraticEquationSolver
        {
            private readonly IDiscriminantStrategy _strategy;

            public QuadraticEquationSolver(IDiscriminantStrategy strategy)
            {
                _strategy = strategy;
            }

            public Tuple<Complex, Complex> Solve(double a, double b, double c)
            {
                var discriminant = _strategy.CalculateDiscriminant(a, b, c);

                var sqrt = Complex.Sqrt(discriminant);

                return new Tuple<Complex, Complex>(
                    (-b + sqrt) / (2 * a),
                    (-b - sqrt) / (2 * a));
            }
        }
    }
}
