using System;
public class Q
{
    public int A;
    public int B;
    public Q(int a, int b)
    {
        A = a;
        B = b;
    }
    public int Sum()
    {
        A += B;
        return A;
    }
    public int Dif()
    {
        A -= B;
        return A;
    }
    public int Mul()
    {
        A *= B;
        return A;
    }
    public int Div()
    {
        if (B == 0)
        {
            Console.WriteLine("делить на 0 нельзя");
            A = 0;
        }
        else A /= B;
        return A;
    }
}
class Program
{
    delegate int Operation();
    static void Main()
    {
        Q obj1 = new(10, 2);
        Q obj2 = new(20, 4);
        Operation op1 = () =>
        {
            obj1.A = obj1.Sum();
            obj1.A = obj1.Mul();
            obj1.A = obj1.Div();
            return obj1.A;
        };
        Operation op2 = () =>
        {
            obj2.A = obj2.Div();
            obj2.A = obj2.Dif();
            obj2.A = obj2.Mul();
            return obj2.A;
        };
        Console.WriteLine("результат первого делегата: " + op1());
        Console.WriteLine("результат второго делегата: " + op2());
    }
}
