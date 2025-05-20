using System;
using System.Collections.Generic;
public class Phone
{
    public string Number { get; set; }
    public string Name { get; set; }
    public string Provider { get; set; }

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
            new Phone("1234567890", "Ivanov I.I.", "MTS"),
            new Phone("0987654321", "Petrov P.P.", "Beeline"),
            new Phone("5555555555", "Sidorov S.S.", "MTS"),
            new Phone("4444444444", "Kozlov K.K.", "MTS"),
            new Phone("3333333333", "Lebedev L.L.", "MegaFon"),
            new Phone("2222222222", "Kuznetsova K.K.", "Beeline"),
            new Phone("1111111111", "Petrov P.P.", "Beeline"),
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
        Console.WriteLine($"the most popular operators (used {max} times):");
        foreach (var x in answer)
        {
            Console.WriteLine(x);
        }
    }
}
