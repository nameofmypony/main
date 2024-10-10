using System;
class Q
{
    static void Main()
	{
		int a,b=0;
		a=Convert.ToInt32(Console.ReadLine());
		while (a>0)
		{
		    while (a>0)
		    {
		        if ((a%10)%2==1)
		        {
		            b=b*10+a%10;
		        }
		        a=a/10;
		    }
		    if (b==0)
		    {
		        Console.WriteLine("нет нечетных цифр");
		    }
		    else Console.WriteLine(b);
		    a=Convert.ToInt32(Console.ReadLine());
		    b=0;
		}
	}
}
