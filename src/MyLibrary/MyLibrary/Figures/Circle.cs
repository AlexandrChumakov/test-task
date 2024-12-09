using MyLibrary.Interfaces;

namespace MyLibrary.Figures;

public class Circle : IFigure
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius can`t be zero or below zero");

        _radius = radius;
    }

    public double GetSquare() => Math.PI * Math.Pow(_radius, 2);
}