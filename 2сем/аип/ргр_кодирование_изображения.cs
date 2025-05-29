using System;
using System.IO;
using System.Collections.Generic;
class Program
{
    static int[,] image;
    static string output;
    static Queue<string> regionsQueue;
    struct Region { public int x, y, w, h; }
    static void Main()
    {
        {
            string text = File.ReadAllText("input.txt");
            string[] lines = text.Split("\n");
            string[] wh = lines[0].Split(' ');
            int w = int.Parse(wh[0]);
            int h = int.Parse(wh[1]);

            image = new int[h, w];
            for (int i = 0; i < h; i++)
            {
                string[] line = lines[i + 1].Split(' ');
                for (int j = 0; j < w; j++)
                    image[i, j] = int.Parse(line[j]);
            }
            output = "";
            regionsQueue = new Queue<string>();
            output += $"{w} {h}\n";

            if (IsSameColor(0, 0, w, h))
                output += image[0, 0].ToString() + "\n";
            else
            {
                output += "Z\n";
                EncodeRegion(0, 0, w, h);
            }

            while (regionsQueue.Count > 0)
                output += regionsQueue.Dequeue() + "\n";

            File.WriteAllText("output.txt", output);
        }
    }

    static bool IsSameColor(int x, int y, int w, int h)
    {
        if (w == 0 || h == 0)
            return true;
        int color = image[y, x];
        for (int i = y; i < y + h; i++)
            for (int j = x; j < x + w; j++)
                if (image[i, j] != color) return false;
        return true;
    }

    static void EncodeRegion(int X, int Y, int W, int H)
    {
        Queue<Region> queue = new();
        queue.Enqueue(new Region { x = X, y = Y, w = W, h = H });
        while (queue.Count > 0)
        {
            Region current = queue.Dequeue();

            int w1 = (current.w + 1) / 2;
            int w2 = current.w / 2;
            int h1 = (current.h + 1) / 2;
            int h2 = current.h / 2;

            string lt = RegionCode(current.x, current.y, w1, h1);
            string rt = RegionCode(current.x + w1, current.y, w2, h1);
            string lb = RegionCode(current.x, current.y + h1, w1, h2);
            string rb = RegionCode(current.x + w1, current.y + h1, w2, h2);

            regionsQueue.Enqueue($"{lt} {rt} {lb} {rb}");

            if (lt == "Z") queue.Enqueue(new Region { x = current.x, y = current.y, w = w1, h = h1 });
            if (rt == "Z") queue.Enqueue(new Region { x = current.x + w1, y = current.y, w = w2, h = h1 });
            if (lb == "Z") queue.Enqueue(new Region { x = current.x, y = current.y + h1, w = w1, h = h2 });
            if (rb == "Z") queue.Enqueue(new Region { x = current.x + w1, y = current.y + h1, w = w2, h = h2 });
        }
    }

    static string RegionCode(int x, int y, int w, int h)
    {
        if (w == 0 || h == 0)
            return "-";
        else if (IsSameColor(x, y, w, h))
            return image[y, x].ToString();
        else return "Z";
    }
}
