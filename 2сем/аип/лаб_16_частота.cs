using System;
unsafe class Program
{
    static void Main()
    {
        int* freq = stackalloc int[256];
        for (int i = 0; i < 256; i++)
        {
            freq[i] = 0;
        }
        Console.WriteLine("введите текст (конец ввода - пустая строка):");
        string input;
        while ((input = Console.ReadLine()) != "")
        {
            fixed (char* charAddress = input)
            {
                char* current = charAddress;
                while (*current != '\0')
                {
                    if (*current <= 255)
                    {
                        byte code = (byte)*current;
                        freq[code]++;
                    }
                    current++;
                }
            }
        }
        int min = int.MaxValue;
        int max = int.MinValue;
        for (int i = 0; i < 256; i++)
        {
            if (freq[i] > 0)
            {
                if (freq[i] < min) min = freq[i];
                if (freq[i] > max) max = freq[i];
            }
        }
        Console.Write("\nсамые редкие символы: ");
        for (int i = 0; i < 256; i++)
        {
            if (freq[i] == min && min > 0) Console.Write($"'{(char)i}' ");
        }
        Console.Write("\nсамые частые символы: ");
        for (int i = 0; i < 256; i++)
        {
            if (freq[i] == max && max > 0) Console.Write($"'{(char)i}' ");
        }
    }
}
