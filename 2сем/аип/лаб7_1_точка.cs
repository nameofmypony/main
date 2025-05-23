using System;
public class Point
{
    public int X;
    public int Y;
    public event Action<Point, string> OutOfBounds;
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public void Move(int dx, int dy, Field field)
    {
        int newX = X + dx;
        int newY = Y + dy;
        string boundary = "";
        if (newX < field.Left) boundary = "левую";
        else if (newX > field.Right) boundary = "правую";
        else if (newY < field.Bottom) boundary = "нижнюю";
        else if (newY > field.Top) boundary = "верхнюю";
        if (!string.IsNullOrEmpty(boundary))
        {
            OutOfBounds?.Invoke(this, $"точка вышла за {boundary} границу");
            return;
        }
        X = newX;
        Y = newY;
        Console.WriteLine($"точка переместилась в ({X}, {Y})");
    }
}
public class Field
{
    public int Left;
    public int Right;
    public int Bottom;
    public int Top;
    public Field(int left, int right, int bottom, int top)
    {
        Left = left;
        Right = right;
        Bottom = bottom;
        Top = top;
    }
}
class Program
{
    static Random random = new();
    static void Main()
    {
        Field field = new(0, 32, 0, 32);
        Point point = new(16, 16);
        Console.WriteLine($"границы поля по x: ({field.Left}, {field.Right})");
        Console.WriteLine($"границы поля по y: ({field.Bottom}, {field.Top})");
        Console.WriteLine($"точка находится на ({point.X}, {point.Y})");
        point.OutOfBounds += (p, message) => 
        {
            Console.WriteLine(message);
            Console.WriteLine($"точка находится на ({p.X}, {p.Y})");
        };
        for (int i = 0; i < 10; i++)
        {
            int dx = random.Next(-16, 16);
            int dy = random.Next(-16, 16);
            Console.WriteLine($"\nпопытка перемещения на {dx} по x, {dy} по y:");
            point.Move(dx, dy, field);
        }
    }
}
