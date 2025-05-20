using System;
using System.Collections.Generic;
public class Phone
{
    public string Name { get; set; }
    public string Number { get; set; }
    public string Provider { get; set; }
    public int Year { get; set; }
    public string City { get; set; }
    public Phone(string name, string number, string provider, int year, string city)
    {
        Name = name;
        Number = number;
        Provider = provider;
        Year = year;
        City = city;
    }
}
class Program
{
    static List<Phone> info = [];
    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. добавить нового абонента");
            Console.WriteLine("2. поиск по оператору");
            Console.WriteLine("3. поиск по году");
            Console.WriteLine("4. поиск по номеру");
            Console.WriteLine("5. выход");
            Console.Write("выберите действие (1-5): ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddPhone();
                    break;
                case "2":
                    SearchByProvider();
                    break;
                case "3":
                    SearchByYear();
                    break;
                case "4":
                    SearchByNumber();
                    break;
                case "5":
                    exit = true;
                    Console.WriteLine("выход");
                    break;
                default:
                    Console.WriteLine("ошибка выбора");
                    break;
            }
        }
    }
    static void AddPhone()
    {
        Console.WriteLine("добавление абонента");
        Console.Write("фио: ");
        string name = Console.ReadLine();
        Console.Write("номер: ");
        string number = Console.ReadLine();
        Console.Write("оператор: ");
        string provider = Console.ReadLine();
        int year;
        while (true)
        {
            Console.Write("год: ");
            if (int.TryParse(Console.ReadLine(), out year))
                break;
            Console.WriteLine("ошибка ввода года");
        }
        Console.Write("город: ");
        string city = Console.ReadLine();
        info.Add(new Phone(name, number, provider, year, city));
        Console.WriteLine("абонент добавлен");
    }
    static void SearchByProvider()
    {
        Console.WriteLine("поиск по оператору");
        Console.Write("оператор: ");
        string provider = Console.ReadLine();
        List<Phone> results = [];
        foreach (var s in info)
        {
            if (s.Provider == provider) results.Add(s);
        }
        if (results.Count > 0)
        {
            Console.WriteLine($"абоненты с оператором {provider}:");
            foreach (var Phone in results)
            {
                PrintPhone(Phone);
            }
        }
        else Console.WriteLine("таких нет");
    }
    static void SearchByYear()
    {
        Console.WriteLine("поиск по году");
        int year;
        while (true)
        {
            Console.Write("год: ");
            if (int.TryParse(Console.ReadLine(), out year))
                break;
            Console.WriteLine("ошибка ввода года");
        }
        List<Phone> results = [];
        foreach (var s in info)
        {
            if (s.Year == year) results.Add(s);
        }
        if (results.Count > 0)
        {
            Console.WriteLine($"абоненты, подключившие номер в {year} году:");
            foreach (var Phone in results)
            {
                PrintPhone(Phone);
            }
        }
        else Console.WriteLine("таких нет");
    }
    static void SearchByNumber()
    {
        Console.WriteLine("поиск по номеру");
        Console.Write("номер: ");
        string number = Console.ReadLine();
        List<Phone> results = [];
        foreach (var s in info)
        {
            if (s.Number == number) results.Add(s);
        }
        if (results.Count > 0)
        {
            Console.WriteLine($"абоненты с номером '{number}':");
            foreach (var Phone in results)
            {
                PrintPhone(Phone);
            }
        }
        else Console.WriteLine("таких нет");
    }
    static void PrintPhone(Phone s)
    {
        Console.WriteLine($"фио: {s.Name}, номер: {s.Number}, оператор: {s.Provider}, год: {s.Year}, город: {s.City}");
    }
}
