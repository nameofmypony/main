using System;
using System.Runtime.InteropServices;
class Q
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int s = 0, dlina = 0, maxdlina;
        Console.WriteLine("введите несколько строк (конец ввода - пустая строка)");
        while (true)
        {
            maxdlina = 0;
            string l = Console.ReadLine();
            if (l == "") break;
            char[] letters = l.ToCharArray();
            //определить количество строк, в которых присутствуют сочетания a*b, где * - любой символ
            for (int i = 0; i < letters.Length - 2; i++)
            {
                if ((letters[i] == 'a') && (letters[i + 2] == 'b'))
                {
                    s++;
                    break;
                }
            }
            //определить максимальную длину подстроки в каждой строке, состоящей из сочетания abc, при этом необязательно присутствуют все три символа
            //например, подстроки abcabcabc и abca тоже считаются.
            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = i; j < letters.Length; j += 3)
                {
                    if (letters[j] == 'a') dlina++;
                    else break;
                    if (j + 1 < letters.Length)
                    {
                        if (letters[j + 1] == 'b') dlina++;
                        else break;
                    }
                    if (j + 2 < letters.Length)
                    {
                        if (letters[j + 2] == 'c') dlina++;
                        else break;
                    }
                }
                if (dlina > maxdlina) maxdlina = dlina;
                dlina = 0;
            }
            Console.WriteLine("максимальная длина подстроки, состоящей из сочетания abc: " + maxdlina);
        }
        Console.WriteLine("количество строк, в которых присутствуют сочетания a*b: " + s);
    }
}
