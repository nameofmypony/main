using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("enter numbers separated by spaces");
        var dictionary = new Dictionary<int, int>();
        string input = Console.ReadLine();
        string[] words = input.Split(' ');
        foreach (string word in words)
        {
            if (int.TryParse(word, out int number))
            {
                if (dictionary.ContainsKey(number)) dictionary[number]++;
                else dictionary.Add(number, 1);
            }
            else
            {
                Console.WriteLine("input error");
                return;
            }
        }
        Console.WriteLine("number\tcount");
        foreach (var element in dictionary)
        {
            Console.WriteLine(element.Key + "\t" + element.Value);
        }
    }
}
