using System;
class Q {
  static void Main() {
    int n,a,b,c,min=0,chet=1,max1,max2;
    Console.WriteLine("введите кол-во чисел >= 3");
    n=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("введите числа");
    a=Convert.ToInt32(Console.ReadLine());
    b=Convert.ToInt32(Console.ReadLine());
    c=Convert.ToInt32(Console.ReadLine());
    if ((a%2==1)||(b%2==1)||(c%2==1))
    {
        chet*=0;
    }
    if ((b<a)&&(b<c))
        {
            min++;
        }
    max1=Math.Max(a,Math.Max(b,c));
    max2=a+b+c-max1-Math.Min(a,Math.Min(b,c));
    
    while (n>3)
    {
        n--;
        a=b;
        b=c;
        c=Convert.ToInt32(Console.ReadLine());
        if ((b<a)&&(b<c))
        {
            min++;
        }
        if(b%2==1)
        {
            chet*=0;
        }
        if(c>=max1)
        {
            max2=max1;
            max1=c;
        }
        else if(c>=max2)max2=c;
    }
    if (c%2==1)
    {
        chet*=0;
    }
    Console.WriteLine("кол-во лок. минимумов: "+min);
    if (chet==1)
    {
        Console.WriteLine("все элементы четные");
    }
    else
    {
        Console.WriteLine("не все элементы четные");
    }
    Console.WriteLine("max1 = "+max1);
    Console.WriteLine("max2 = "+max2);
  }
}
