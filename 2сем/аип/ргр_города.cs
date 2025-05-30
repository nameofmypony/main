using System;
using System.IO;
class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        string[] firstLine = lines[0].Split();
        int n = int.Parse(firstLine[0]);
        int m = int.Parse(firstLine[1]);
        const int INF = 10000000;
        int[,] d = new int[n+1, n+1];
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == j) d[i, j] = 0;
                else d[i, j] = INF;
            }
        }
        for (int i = 1; i <= m; i++)
        {
            string[] line = lines[i].Split(' ');
            int u = int.Parse(line[0]);
            int v = int.Parse(line[1]);
            int weight = int.Parse(line[2]);
            if (weight < d[u, v])
            {
                d[u, v] = weight;
                d[v, u] = weight;
            }
        }
        for (int k = 1; k <= n; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                if (d[i, k] == INF) continue;
                for (int j = 1; j <= n; j++)
                {
                    if (d[i, j] > d[i, k] + d[k, j]) d[i, j] = d[i, k] + d[k, j];
                }
            }
        }
        int max = 0;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (d[i, j] < INF && d[i, j] > max) max = d[i, j];
            }
        }
        File.WriteAllText("output.txt", max.ToString());
    }
}
