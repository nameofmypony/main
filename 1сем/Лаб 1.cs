using System;
class Q
{
    static void Main()
    {
        int a,b;
        a=Convert.ToInt32(Console.ReadLine());
        b=Convert.ToInt32(Console.ReadLine());
        a=a+b;
        b=a-b;
        a=a-b;
        Console.WriteLine("a = "+a);
        Console.WriteLine("b = "+b);
        
        a=(a+b+Math.Abs(a-b))/2;
        Console.WriteLine("max = "+a);
        
        int p,l,m,n,q;
        p=Convert.ToInt32(Console.ReadLine());
        l=Convert.ToInt32(Console.ReadLine());
        m=Convert.ToInt32(Console.ReadLine());
        n=Convert.ToInt32(Console.ReadLine());
        q=n*(2*(p+l+m)+l*(n-1));
        Console.WriteLine("distanse = "+q);
    }
}
