using System;
using System.Text.RegularExpressions;
class Q
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("введите строку");
        string a = Console.ReadLine();
        //удаление лишних пробелов
        Console.WriteLine("исходная строка:");
        Console.WriteLine(a);
        a = Regex.Replace(a, "[ ]+", " ");
        Console.WriteLine("строка без лишних пробелов:");
        Console.WriteLine(a);
        //поиск палиндромов
        Console.WriteLine("палиндромы в строке:");
        int q = 0, f;
        string[] words = a.Split(' ');
        foreach (string s in words)
        {
            f = 1;
            char[] x = s.ToCharArray();
            char[] y = s.ToCharArray();
            Array.Reverse(y);
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i]) f *= 0;
            }
            if (f == 1)
            {
                Console.Write(s);
                Console.Write(" ");
                q++;
            }
        }
        if (q == 0) Console.WriteLine("нет");
        else Console.WriteLine();
        //определить, является ли строка палиндромом
        f = 1;
        char[] m = a.ToCharArray();
        char[] n = a.ToCharArray();
        Array.Reverse(n);
        for (int i = 0; i < a.Length; i++)
        {
            if (m[i] != n[i]) f *= 0;
        }
        if (f == 1) Console.WriteLine("строка является палиндромом");
        else Console.WriteLine("строка не является палиндромом");
        //найти строки, в которых гласных букв больше, чем согласных
        int glnum, sonum, g = 0;
        string answer = "";
        string glas = "аеёиоуыэюя";
        char[] gl = glas.ToCharArray();
        string sogl = "бвгджзйклмнпрстфхцчшщьъ";
        char[] so = sogl.ToCharArray();
        Console.WriteLine("введите несколько строк (конец ввода - пустая строка)");
        while (true)
        {
            glnum = 0;
            sonum = 0;
            string l = Console.ReadLine();
            if (l == "") break;
            char[] letters = l.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = 0; j < gl.Length; j++)
                {
                    if (letters[i] == gl[j]) glnum++;
                }
                for (int j = 0; j < so.Length; j++)
                {
                    if (letters[i] == so[j]) sonum++;
                }
            }
            if (glnum > sonum)
            {
                answer = string.Concat(answer, "\n", l);
                g++;
            }
        }
        if (g == 0) answer = string.Concat(answer, "нет");
        Console.Write("строки, в которых гласных букв больше, чем согласных:");
        Console.WriteLine(answer);
    }
}
