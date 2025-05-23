using System;
class Program
{
    static void Main()
    {
        Func<double, double, double> sum = (a, b) => a + b;
        Func<double, double, double> dif = (a, b) => a - b;
        Func<double, double, double> mul = (a, b) => a * b;
        Func<double, double, double?> div = (a, b) => 
        {
            if (b == 0)
            {
                Console.WriteLine("на ноль делить нельзя");
                return null;
            }
            else return a / b;
        };
        double x = 10;
        double y = 2;
        Console.WriteLine($"{x} + {y} = {sum(x, y)}");
        Console.WriteLine($"{x} - {y} = {dif(x, y)}");
        Console.WriteLine($"{x} * {y} = {mul(x, y)}");
        if (div(x, y).HasValue) Console.WriteLine($"{x} / {y} = {div(x, y)}");
    }
}
