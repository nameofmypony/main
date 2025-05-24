using System;
class Figure
{
    public string name;
}
interface IFigure
{
    double P();
    double S();
}
class Circle : Figure, IFigure
{
    public double r;
    public double P()
    {
        return 2 * Math.PI * r;
    }
    public double S()
    {
        return Math.PI * r * r;
    }
}
class Square : Figure, IFigure
{
    public double a;
    public double P()
    {
        return 4 * a;
    }
    public double S()
    {
        return a * a;
    }
}
class Triangle : Figure, IFigure
{
    public double a;
    public double P()
    {
        return 3 * a;
    }
    public double S()
    {
        return Math.Sqrt(3) / 4 * a * a;
    }
}
class Program
{
    static void Main()
    {
        Circle circle = new Circle { name = "circle", r = 7 };
        Square square = new Square { name = "square", a = 8 };
        Triangle triangle = new Triangle { name = "triangle", a = 9 };
        Console.WriteLine($"{circle.name}: P = {circle.P()}, S = {circle.S()}");
        Console.WriteLine($"{square.name}: P = {square.P()}, S = {square.S()}");
        Console.WriteLine($"{triangle.name}: P = {triangle.P()}, S = {triangle.S()}");
    }
}
