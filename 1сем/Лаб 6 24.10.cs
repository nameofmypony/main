using System;
class Q
{
    static void Main()
    {
        //задание массива
        int m, n, sum1, sum2, z, y, s = 0, summ1, summ2, pro1, pro2, zer1, zer2, w = 0;
        m = Convert.ToInt32(Console.ReadLine());
        n = Convert.ToInt32(Console.ReadLine());
        int[,] a = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                a[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        //вывод исходного массива
        Console.WriteLine("исходный массив:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(a[i, j] + "\t");
            }
            Console.WriteLine();
        }
        //сортировка столбцов по возрастанию их суммы
        int[,] b = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                b[i, j] = a[i, j];
            }
        }
        for (int q = 0; q < n - 1; q++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                sum1 = 0;
                sum2 = 0;
                for (int i = 0; i < m; i++)
                {
                    sum1 += b[i, j];
                    sum2 += b[i, j + 1];
                }
                if (sum1 > sum2)
                {
                    for (int i = 0; i < m; i++)
                    {
                        z = b[i, j];
                        b[i, j] = b[i, j + 1];
                        b[i, j + 1] = z;
                    }
                }
            }
        }
        //вывод отсортированного массива
        Console.WriteLine("отсортированный массив:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(b[i, j] + "\t");
            }
            Console.WriteLine();
        }
        //определение пар строк, состоящих из одинаковых элементов(1 1 2 и 1 2 1 считается)
        Console.WriteLine("пары строк из одинаковых элементов:");
        for (int i = 0; i < m; i++)//произвольная строка
        {
            for (int q = i + 1; q < m; q++)//другая произвольная строка
            {
                summ1 = 0;
                summ2 = 0;
                pro1 = 1;
                pro2 = 1;
                zer1 = 0;
                zer2 = 0;
                for (int j = 0; j < n; j++)
                {
                    summ1 += a[i, j];
                    summ2 += a[q, j];
                    pro1 *= a[i, j];
                    pro2 *= a[q, j];
                    if (a[i, j] == 0) { zer1++; }
                    if (a[q, j] == 0) { zer2++; }
                }
                if ((summ1 == summ2) && (pro1 == pro2) && (zer1 == zer2))
                {
                    Console.WriteLine(i + 1 + " и " + (q + 1));
                    w++;
                }
            }
        }
        if (w == 0) { Console.WriteLine("не существует"); }
        //определение элементов минимакса
        Console.WriteLine("положение элементов минимакса исходного массива:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                y = 1;
                for (int q = 0; q < m; q++)
                {
                    if (a[i, j] > a[q, j])
                    {
                        y *= 0;
                    }
                }
                for (int q = 0; q < n; q++)
                {
                    if (a[i, j] < a[i, q])
                    {
                        y *= 0;
                    }
                }
                if (y == 1)
                {
                    Console.WriteLine(i + 1 + " строка " + (j + 1) + " столбец");
                    s++;
                }
                y = 1;
                for (int q = 0; q < m; q++)
                {
                    if (a[i, j] < a[q, j])
                    {
                        y *= 0;
                    }
                }
                for (int q = 0; q < n; q++)
                {
                    if (a[i, j] > a[i, q])
                    {
                        y *= 0;
                    }
                }
                if (y == 1)
                {
                    Console.WriteLine(i + 1 + " строка " + (j + 1) + " столбец");
                    s++;
                }
            }
        }
        if (s == 0)
        {
            Console.WriteLine("не существует");
        }
    }
}
