using System;
using System.Collections.Generic;
public class Phone
{
    public string Number;
    public string Name;
    public string Provider;
    public Phone(string number, string name, string provider)
    {
        Number = number;
        Name = name;
        Provider = provider;
    }
}
class Program
{
    static void Main()
    {
        List<Phone> phones =
        [
            new Phone("1111111111", "Иванов И. И.", "МТС"),
            new Phone("2222222222", "Петров П. П.", "Билайн"),
            new Phone("3333333333", "Сидоров С. С.", "МТС"),
            new Phone("4444444444", "Козлов К. К.", "МТС"),
            new Phone("5555555555", "Лебедев Л. Л.", "Мегафон"),
            new Phone("6666666666", "Кузнецова К. К.", "Билайн"),
            new Phone("7777777777", "Петров П. П.", "Билайн"),
        ];
        Dictionary<string, int> freq = [];
        foreach (var phone in phones)
        {
            if (freq.ContainsKey(phone.Provider)) freq[phone.Provider]++;
            else freq[phone.Provider] = 1;
        }
        int max = 0;
        foreach (var x in freq)
        {
            if (x.Value > max) max = x.Value;
        }
        List<string> answer = [];
        foreach (var x in freq)
        {
            if (x.Value == max) answer.Add(x.Key);
        }
        Console.WriteLine($"Самый(ые) популярный(ые) оператор(ы) ({max} абонента):");
        foreach (var x in answer)
        {
            Console.WriteLine(x);
        }
    }
}
