using System;
using System.Collections.Generic;
public struct Info
{
    public DateTime Take;
    public DateTime? Give;
    public Info(DateTime take, DateTime? give)
    {
        Take = take;
        Give = give;
    }
}
public class Book
{
    public string Author;
    public string Title;
    public int Year;
    public string Publisher;
    public List<Info> Taken;
    public Book(string author, string title, int year, string publisher)
    {
        Author = author;
        Title = title;
        Year = year;
        Publisher = publisher;
        Taken = [];
    }
    public Book(string author, string title, int year, string publisher, Info taken)
        : this(author, title, year, publisher)
    {
        Taken.Add(taken);
    }
}
class Program
{
    static void Main()
    {
        List<Book> library =
        [
            new Book("Толстой", "Война и мир", 1869, "Русский вестник"),
            new Book("Достоевский", "Преступление и наказание", 1866, "Русский вестник",
                new Info(new DateTime(2025, 1, 10), new DateTime(2025, 2, 1))),
            new Book("Гоголь", "Мертвые души", 1842, "Современник",
                new Info(new DateTime(2025, 3, 15), null)),
            new Book("Пушкин", "Евгений Онегин", 1833, "Литературная газета")
        ];
        Console.WriteLine("книги, которые ни разу не выдавались:");
        foreach (Book book in library)
        {
            if (book.Taken.Count == 0) Console.WriteLine($"{book.Author} - {book.Title} ({book.Year}, {book.Publisher})");
        }
        Console.WriteLine("\nкниги, которые не возвращены обратно:");
        foreach (Book book in library)
        {
            foreach (Info info in book.Taken)
            {
                if (info.Give == null)
                {
                    Console.WriteLine($"{book.Author} - {book.Title} ({book.Year}, {book.Publisher}), дата выдачи: {info.Take:dd.MM.yyyy}");
                    break;
                }
            }
        }
    }
}
