using System;
using System.Text.RegularExpressions;
class Q
{
	static void Main()
	{
	    //удаление лишних пробелов
	    string a=Console.ReadLine();
	    Console.WriteLine(a);
	    a=Regex.Replace(a, "[ ]+", " ");
	    Console.WriteLine(a);
	    //поиск палиндромов
	    int q=0,f;
	    string[] words = a.Split(' ');
        foreach (string s in words) 
        {
            f=1;
            char[]x=s.ToCharArray();
            char[]y=s.ToCharArray();
            Array.Reverse(y);
            for(int i=0;i<x.Length;i++)
            {
                if(x[i]!=y[i])
                {
                    f*=0;
                }
            }
            if(f==1)
            {
                Console.Write(s);
                Console.Write(" ");
                q++;
            }
        }
        if(q==0) Console.WriteLine("нет палиндромов");
        //определить, является ли строка палиндромом
        
        //найти строки, в которых гласных букв больше, чем согласных
        
	}
}
