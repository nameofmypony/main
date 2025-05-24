using System;
using System.IO;
class Program
{
    static void Main()
    {
        string input = "input.txt";
        string output = "output.txt";
        string[] lines = File.ReadAllLines(input);
        using StreamWriter writer = new(output);
        foreach (string line in lines)
        {
            if (HasEven(line)) writer.WriteLine(line);
        }
    }
    static bool HasEven(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]) && line[i] != 0 && (i == 0 || !char.IsDigit(line[i - 1]) || line[i-1] == '-'))
            {
                int start = i;
                while (i < line.Length && char.IsDigit(line[i]))
                {
                    i++;
                }
                if (i == line.Length || !char.IsDigit(line[i]))
                {
                    string numberStr = line.Substring(start, i - start);
                    if (int.TryParse(numberStr, out int number) && number % 2 == 0) return true;
                }
            }
        }
        return false;
    }
}
