using System;
class Class
{
    //поля
    private int x;
    private int y;
    //конструкторы в зависимости от принимаемых значений
    public Class()
    {
        x = 0;
        y = 0;
    }
    public Class(int x)
    {
        this.x = x;
        y = 0;
    }
    public Class(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    //методы
    public int Summa()
    {
        return x + y;
    }
    public int Proizvedenie()
    {
        return x * y;
    }
    public int Raznost()
    {
        return x - y;
    }
    public double Delenie()
    {
        if (y == 0)
        {
            Console.Write("нельзя делить на ");
            return 0;
        }
        else
        {
            return x / y;
        }
    }
}
class Q
{
    static void Main()
    {
        //объекты
        Class a = new Class();
        Class b = new Class(13);
        Class c = new Class(12, 4);
        //вывод
        Console.WriteLine("первый объект");
        Console.WriteLine(a.Summa());
        Console.WriteLine(a.Proizvedenie());
        Console.WriteLine(a.Raznost());
        Console.WriteLine(a.Delenie());
        Console.WriteLine();
        Console.WriteLine("второй объект");
        Console.WriteLine(b.Summa());
        Console.WriteLine(b.Proizvedenie());
        Console.WriteLine(b.Raznost());
        Console.WriteLine(b.Delenie());
        Console.WriteLine();
        Console.WriteLine("третий объект");
        Console.WriteLine(c.Summa());
        Console.WriteLine(c.Proizvedenie());
        Console.WriteLine(c.Raznost());
        Console.WriteLine(c.Delenie());
    }
}
