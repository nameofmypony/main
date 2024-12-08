using System;
class Q
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine()), a = 1, b = 0;
        string q;
        for (int i = 0; i < n; i++)
        {
            q = Console.ReadLine();
            string[] qq = q.Split(' ');
            if (qq[0] == "*")
            {
                a *= Convert.ToInt32(qq[1]);
                b *= Convert.ToInt32(qq[1]);
            }
            else if (qq[0] == "+")
            {
                if (qq[1] == "x") a += 1;
                else b += Convert.ToInt32(qq[1]);
            }
            else
            {
                if (qq[1] == "x") a -= 1;
                else b -= Convert.ToInt32(qq[1]);
            }
        }
        Console.WriteLine((Convert.ToInt32(Console.ReadLine()) - b) / a);
    }
}
