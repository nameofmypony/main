using System;
class Animals
{
    public string name;
}
class Birds : Animals
{
    public string home;
    public string winter;
}
class Mammals : Animals
{
    public string home;
    public int weight;
}
class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Birds[] birds = new Birds[3];
        birds[0] = new Birds { name = "утка", home = "лес", winter = "Средиземноморье" };
        birds[1] = new Birds { name = "ласточка", home = "реки", winter = "Африка" };
        birds[2] = new Birds { name = "орел", home = "горы", winter = "Индия" };
        Mammals[] mammals = new Mammals[3];
        mammals[0] = new Mammals { name = "олень", home = "горы", weight = 100 };
        mammals[1] = new Mammals { name = "медведь", home = "лес", weight = 500 };
        mammals[2] = new Mammals { name = "волк", home = "лес", weight = 80 };
        Console.WriteLine("птицы, обитающие в лесу:");
        foreach (var bird in birds)
        {
            if (bird.home == "лес")
            {
                Console.WriteLine(bird.name);
            }
        }
        Console.WriteLine("млекопитащие, обитающие в лесу:");
        foreach (var mammal in mammals)
        {
            if (mammal.home == "лес")
            {
                Console.WriteLine(mammal.name);
            }
        }
        Console.WriteLine("птицы, зимующие в Африке:");
        foreach (var bird in birds)
        {
            if (bird.winter == "Африка")
            {
                Console.WriteLine(bird.name);
            }
        }
        Console.WriteLine("млекопитающие с весом больше 90 кг:");
        foreach (var mammal in mammals)
        {
            if (mammal.weight > 90)
            {
                Console.WriteLine(mammal.name);
            }
        }
    }
}
