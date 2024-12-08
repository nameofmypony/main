using System;
class Q
{
    static void Main()
    {
        int MaxN = int.Parse(Console.ReadLine()), count = 0;
        for (int N = 1; N <= MaxN; N++)
        {
            for (int K = 2; K <= MaxN * 2; K++)
            {
                int t = N;
                while (N < K)
                {
                    t = t * 2 - K;
                    if (t == 0)
                    {
                        count++;
                        break;
                    }
                    else if (t < 0) break;
                }
            }
        }
        Console.WriteLine(count);
    }
}
