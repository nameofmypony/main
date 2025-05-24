using System;
public class GenericClass<Type>
{
    public Type[] elements;
    public int count;
    public GenericClass(int size)
    {
        elements = new Type[size];
        count = 0;
    }
    public void Add(Type element)
    {
        if (count >= elements.Length)
        {
            Console.WriteLine("нет места в массиве");
            return;
        }
        elements[count] = element;
        count++;
    }
    public void Del(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("неправильный индекс");
            return;
        }
        for (int i = index; i < count - 1; i++)
        {
            elements[i] = elements[i + 1];
        }
        count--;
    }
    public Type Get(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Неверный индекс!");
            return default;
        }
        return elements[index];
    }
}
class Program
{
    static void Main()
    {
        var numbers = new GenericClass<int>(3);
        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);
        Console.WriteLine((numbers.Get(2) - numbers.Get(1)) / numbers.Get(0));
        var words = new GenericClass<string>(4);
        words.Add("Hello");
        words.Add(" ");
        words.Add("World");
        words.Add("!");
        Console.WriteLine(words.Get(0) + words.Get(1) + words.Get(2) + words.Get(3));
    }
}
