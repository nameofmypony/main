using System;
using System.Collections.Generic;
public class Horse
{
    public string Name;
    public int Pos;
    private static Random random = new();
    public event Action<Horse> RaceWon;
    public Horse(string name)
    {
        Name = name;
        Pos = 0;
    }
    public void Move(int finish)
    {
        Pos += random.Next(1, 4);
        Console.WriteLine($"{Name} на позиции {Pos}");
        if (Pos >= finish)
        {
            if (RaceWon != null) RaceWon(this);
        }
    }
}
class Program
{
    static void Main()
    {
        const int finish = 16;
        bool raceFinished = false;
        var horses = new List<Horse>
        {
            new Horse("Молния"),
            new Horse("Ветер"),
            new Horse("Ракета")
        };
        foreach (var horse in horses)
        {
            horse.RaceWon += winner =>
            {
                if (!raceFinished)
                {
                    raceFinished = true;
                    Console.WriteLine($"\nпобедитель: {winner.Name}");
                }
            };
        }
        Console.WriteLine($"начало гонки, участники на позиции 0, финиш на позиции {finish}\n");
        while (!raceFinished)
        {
            foreach (var horse in horses)
            {
                if (!raceFinished) horse.Move(finish);
            }
            Console.WriteLine();
        }
    }
}
