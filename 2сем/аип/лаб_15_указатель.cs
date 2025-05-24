using System;
class Program
{
    unsafe static void Main()
    {
        Console.WriteLine("введите кол-во элементов массива:");
        int count = int.Parse(Console.ReadLine());
        int* array = stackalloc int[count];
        Console.WriteLine("введите числа:");
        for (int i = 0; i < count; i++)
        {
            Console.Write($"элемент {i + 1}: ");
            *(array + i) = int.Parse(Console.ReadLine());
        }
        int evenCount = 0;
        for (int i = 0; i < count; i++)
        {
            if (*(array + i) % 2 == 0) evenCount++;
        }
        Console.WriteLine($"кол-во четных: {evenCount}");
    }
}
