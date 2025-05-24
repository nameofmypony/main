using System;
using System.Collections.Generic;
using System.Linq;
class Laptop
{
    public int Id;
    public string Brand;
    public string Model;
}
class OS
{
    public int Id;
    public string Name;
}
class User
{
    public int Id;
    public string Name;
    public bool HasLaptop;
    public int? LaptopId;
    public int? OSId;
}
class Program
{
    static List<Laptop> laptops =
    [
        new Laptop { Id = 1, Brand = "Lenovo", Model = "ThinkPad X1" },
        new Laptop { Id = 2, Brand = "Dell", Model = "XPS 15" },
        new Laptop { Id = 3, Brand = "Apple", Model = "MacBook Pro" }
    ];
    static List<OS> OSs =
    [
        new OS { Id = 1, Name = "Windows 10" },
        new OS { Id = 2, Name = "Windows 11" },
        new OS { Id = 3, Name = "macOS" },
        new OS { Id = 4, Name = "Ubuntu" }
    ];
    static List<User> users =
    [
        new User { Id = 1, Name = "Иванов И.И.", HasLaptop = true, LaptopId = 1, OSId = 1 },
        new User { Id = 2, Name = "Петров П.П.", HasLaptop = false, LaptopId = null, OSId = null },
        new User { Id = 3, Name = "Сидоров С.С.", HasLaptop = true, LaptopId = 2, OSId = 2 },
        new User { Id = 4, Name = "Кузнецов К.К.", HasLaptop = true, LaptopId = 3, OSId = 3 },
        new User { Id = 5, Name = "Смирнова А.А.", HasLaptop = false, LaptopId = null, OSId = null }
    ];
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. пользователи по наличию компьютера");
            Console.WriteLine("2. пользователи по марке ноутбука");
            Console.WriteLine("3. пользователи по операционной системе");
            Console.WriteLine("4. полные данные пользователей");
            Console.WriteLine("5. выход");
            Console.Write("выберите действие: ");
            switch (Console.ReadLine())
            {
                case "1": UsersWithLaptop(); break;
                case "2": UsersByBrand(); break;
                case "3": UsersByOS(); break;
                case "4": All(); break;
                case "5": return;
            }
        }
    }
    static void UsersWithLaptop()
    {
        Console.WriteLine("\nпользователи по наличию компьютера:");
        var groupedUsers = users.GroupBy(u => u.HasLaptop ? "есть ноутбук" : "нет ноутбука");
        foreach (var group in groupedUsers)
        {
            Console.WriteLine($"\n{group.Key}:");
            foreach (var user in group)
            {
                Console.WriteLine($"- {user.Name}");
            }
        }
    }
    static void UsersByBrand()
    {
        Console.WriteLine("\nпользователи по марке ноутбука:");
        var usersWithlaptops = users.Where(u => u.HasLaptop);
        var groupedUsers = users
            .Where(u => u.HasLaptop)
            .GroupBy(u => laptops.First(c => c.Id == u.LaptopId).Brand);
        foreach (var group in groupedUsers)
        {
            Console.WriteLine($"\nмарка: {group.Key}");
            foreach (var user in group)
            {
                Console.WriteLine($"- {user.Name}");
            }
        }
    }
    static void UsersByOS()
    {
        Console.WriteLine("\nпользователи по ОС:");
        var usersWithOS = users.Where(u => u.HasLaptop);
        var groupedUsers = users
            .Where(u => u.OSId != null)
            .GroupBy(u => OSs.First(os => os.Id == u.OSId).Name);
        foreach (var group in groupedUsers)
        {
            Console.WriteLine($"\nОС: {group.Key}");
            foreach (var user in group)
            {
                Console.WriteLine($"- {user.Name}");
            }
        }
    }
    static void All()
    {
        Console.WriteLine("\nполные данные пользователей:");
        foreach (var user in users)
        {
            var hasLaptop = user.HasLaptop ? "да" : "нет";
            var brand = user.HasLaptop
                ? laptops.First(c => c.Id == user.LaptopId).Brand 
                : "-";
            var model = user.HasLaptop 
                ? laptops.First(c => c.Id == user.LaptopId).Model 
                : "-";
            var OS = user.HasLaptop
                ? OSs.First(OS => OS.Id == user.OSId).Name 
                : "-";
            Console.WriteLine($"{user.Name}: есть ноутбук? {hasLaptop}, марка: {brand}, модель: {model}, ОС: {OS} ");
        }
    }
}
