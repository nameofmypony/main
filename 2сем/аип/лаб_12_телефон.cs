using System;
using System.Collections.Generic;
using System.Linq;
class Phone
{
    public string Brand;
    public int Year;
    public string Country;
    public override string ToString()
    {
        return $"{Brand} ({Year}), {Country}";
    }
}
class Program
{
    static List<Phone> Phones = [];
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. добавить телефон");
            Console.WriteLine("2. сгруппировать по стране");
            Console.WriteLine("3. выдать телефоны с заданным годом выпуска");
            Console.WriteLine("4. сгруппировать по марке");
            Console.WriteLine("5. выход");
            Console.Write("выберите действие: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddPhone();
                    break;
                case "2":
                    GroupByCountry();
                    break;
                case "3":
                    FindByYear();
                    break;
                case "4":
                    GroupByBrand();
                    break;
                case "5":
                    Console.WriteLine("выход");
                    return;
                default:
                    Console.WriteLine("ошибка");
                    break;
            }
        }
    }
    static void AddPhone()
    {
        Console.Write("введите марку телефона: ");
        string brand = Console.ReadLine();

        Console.Write("введите год выпуска: ");
        int year;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                year = number;
                break;
            }
            else Console.WriteLine("ошибка");
        }

        Console.Write("введите страну: ");
        string country = Console.ReadLine();

        Phones.Add(new Phone { Brand = brand, Year = year, Country = country });
        Console.WriteLine("телефон добавлен успешно");
    }
    static void GroupByCountry()
    {
        var grouped = Phones.GroupBy(phone => phone.Country);
        Console.WriteLine("\nтелефоны сгруппированы по стране:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"\nстрана: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"- {phone}");
            }
        }
    }
    static void FindByYear()
    {
        Console.Write("введите год: ");
        int year;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                year = number;
                break;
            }
            else Console.WriteLine("ошибка");
        }
        var phones = Phones.Where(phone => phone.Year == year);
        Console.WriteLine($"\nтелефоны {year} года выпуска:");
        int count = 0;
        foreach (var phone in phones)
        {
            Console.WriteLine(phone);
            count++;
        }
        if (count == 0) Console.WriteLine("таких нет");
    }
    static void GroupByBrand()
    {
        var grouped = Phones.GroupBy(p => p.Brand);
        Console.WriteLine("\nтелефоны сгруппированы по марке:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"\nмарка: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"- {phone.Year}, {phone.Country}");
            }
        }
    }
}
