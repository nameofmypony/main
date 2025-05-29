using System;
using System.IO;
using System.Collections.Generic;
class Program
{
    static int[,] image;
    static Queue<Region> regionsQueue;
    static int lineIndex;
    static string[] lines;
    struct Region { public int x, y, w, h; }
    static void Main()
    {
        string text = File.ReadAllText("input.txt");
        lines = text.Split("\n");
        string[] wh = lines[0].Split(" ");
        int w = int.Parse(wh[0]);
        int h = int.Parse(wh[1]);

        image = new int[h, w];
        regionsQueue = new Queue<Region>();
        lineIndex = 2;

        string secondLine = lines[1].Trim();
        if (secondLine == "Z")
        {
            regionsQueue.Enqueue(new Region { x = 0, y = 0, w = w, h = h });
            DecodeRegion();
        }
        else
        {
            int color = int.Parse(secondLine);
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    image[i, j] = color;
        }

        using StreamWriter sw = new("output.txt");
        for (int i = 0; i < h; i++)
        {
            string line = "";
            for (int j = 0; j < w; j++)
            {
                if (j > 0)
                    line += " ";
                line += image[i, j];
            }
            sw.WriteLine(line);
        }
    }

    static void DecodeRegion()
    {
        while (regionsQueue.Count > 0)
        {
            Region current = regionsQueue.Dequeue();
            
            string[] parts = lines[lineIndex].Split(' ');
            lineIndex++;

            int w1 = (current.w + 1) / 2;
            int w2 = current.w / 2;
            int h1 = (current.h + 1) / 2;
            int h2 = current.h / 2;

            ProcessPart(parts[0], current.x, current.y, w1, h1);
            ProcessPart(parts[1], current.x + w1, current.y, w2, h1);
            ProcessPart(parts[2], current.x, current.y + h1, w1, h2);
            ProcessPart(parts[3], current.x + w1, current.y + h1, w2, h2);
        }
    }

    static void ProcessPart(string part, int x, int y, int w, int h)
    {
        part = part.Trim();
        
        if (part == "-" || w == 0 || h == 0)
            return;
        else if (part == "Z")
            regionsQueue.Enqueue(new Region { x = x, y = y, w = w, h = h });
        else
        {
            int color = int.Parse(part);
            for (int i = y; i < y + h; i++)
                for (int j = x; j < x + w; j++)
                    image[i, j] = color;
        }
    }
}
