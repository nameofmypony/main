using System;
class Q
{
    static void Main()
    {
        int MaxN = int.Parse(Console.ReadLine()), count = 0;
        for (int N = 1; N <= MaxN; N++)
        {
            for (int K = N + 1; K <= MaxN * 2; K++)
            {
                int t = N;
                while (t >= 0)
                {
                    t = t * 2 - K;
                    if (t == 0)
                    {
                        count++;
                        break;
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
}
