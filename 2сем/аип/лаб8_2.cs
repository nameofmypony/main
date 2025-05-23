using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
class Program
{
    delegate bool Filter(string item);
    static void Main()
    {
        List<string> words =
        [
            "машина", "дом", "молоко", "кот", "Москва", "медведь", "окно"
        ];
        Filter firstM = word =>
        {
            if (!string.IsNullOrEmpty(word) && word[0].ToString().Equals("м", StringComparison.OrdinalIgnoreCase))
                return true;
            else return false;
        };
        List<string> filtered = Filtered(words, firstM);
        Console.WriteLine("cлова на 'м':");
        foreach (var word in filtered)
        {
            Console.WriteLine(word);
        }
    }
    static List<string> Filtered(List<string> words, Filter rule)
    {
        List<string> result = [];
        foreach (string item in words)
        {
            if (rule(item)) result.Add(item);
        }
        return result;
    }
}
