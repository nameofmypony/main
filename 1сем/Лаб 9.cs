using System;
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
            //определить количество строк, в которых присутствуют сочетания a*b, где * - любой символ
            for (int i = 0; i < l.Length - 2; i++)
            {
                if ((l[i] == 'a') && (l[i + 2] == 'b'))
                {
                    s++;
                    break;
                }
            }
            //определить максимальную длину подстроки в каждой строке, состоящей из сочетания abc, при этом необязательно присутствуют все три символа
            //например, подстроки abcabcabc и abca тоже считаются.
            for (int i = 0; i < l.Length; i++)
            {
                for (int j = i; j < l.Length; j += 3)
                {
                    if (l[j] == 'a') dlina++;
                    else break;
                    if (j + 1 < l.Length)
                    {
                        if (l[j + 1] == 'b') dlina++;
                        else break;
                    }
                    if (j + 2 < l.Length)
                    {
                        if (l[j + 2] == 'c') dlina++;
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
