using System;
class Q
{
    static void Main()
    {
        int a, b, n, q = 1, z = 1, w = 0, y = 0, e = 999999999, r = 0, t = -999999999;
        Console.WriteLine("введите кол-во чисел > 1");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("введите числа");
        b = Convert.ToInt32(Console.ReadLine());
        a = b;
        if (b % 2 == 0) w++;
        if (b % 2 == 0) r += b;
        while (n > 1)
        {
            a = b;
            b = Convert.ToInt32(Console.ReadLine());
            //макс. размер подпоследовательности одинаковых элементов
            if (a == b) q++;
            else q = 1;
            if (q > z) z = q;
            //мин. размер подпоследовательности четных
            if (b % 2 == 0) w++;
            if (w > y) y = w;
            if (b % 2 != 0)
            {
                if ((y < e) && (y != 0)) e = y;
                w = 0;
                y = 0;
            }
            //макс. сумма подпоследовательности четных
            if (b % 2 == 0) r += b;
            if (b % 2 != 0)
            {
                if ((r > t) && (a % 2 == 0)) t = r;
                r = 0;
            }
            n--;
        }
        if ((y < e) && (y != 0)) e = y;
        if ((r > t) && (b % 2 == 0)) t = r;
        Console.WriteLine("макс. размер подпоследовательности, состоящей из одинаковых элементов: " + z);
        if ((e == 999999999) || (t == -999999999)) Console.WriteLine("нет четных элементов");
        else
        {
            Console.WriteLine("мин. размер подпоследовательности, состоящей из четных элементов: " + e);
            Console.WriteLine("макс. сумма подпоследовательности, состоящей из четных элементов: " + t);
        }
    }
}
