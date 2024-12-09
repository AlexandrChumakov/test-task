using MyLibrary.Interfaces;

namespace MyLibrary.Figures;

public class Triangle : IFigure
{
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;
    private const double Epsilon = 1e-10;


    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Side lengths must be positive");
        }

        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
        {
            throw new ArgumentException("The sides do not form triangle");
        }

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public double GetSquare()
    {
        if (IsRightTriangle())
        {
            var sides = GetLegs();
            return 0.5 * sides[0] * sides[1];
        }

        var semiperimeter = (_sideA + _sideB + _sideC) / 2;

        return Math.Sqrt(semiperimeter
                         * (semiperimeter - _sideA)
                         * (semiperimeter - _sideB)
                         * (semiperimeter - _sideC));
    }

    private bool IsRightTriangle()
    {
        return Math.Abs(Math.Pow(_sideA, 2) + Math.Pow(_sideB, 2) - Math.Pow(_sideC, 2)) < Epsilon ||
               Math.Abs(Math.Pow(_sideA, 2) + Math.Pow(_sideC, 2) - Math.Pow(_sideB, 2)) < Epsilon ||
               Math.Abs(Math.Pow(_sideB, 2) + Math.Pow(_sideC, 2) - Math.Pow(_sideA, 2)) < Epsilon;
    }

    private double[] GetLegs()
    {
        var sides = new[] { _sideA, _sideB, _sideC };
        Array.Sort(sides);
        return [sides[0], sides[1]];
    }
}