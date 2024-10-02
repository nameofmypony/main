using System;
class Q
{
	static void Main()
	{
	    int a,b,n,q=1,z=1,w=0,y=0,e=999,r=0,t=0;
	    Console.WriteLine("введите кол-во чисел > 1");
	    n=Convert.ToInt32(Console.ReadLine());
	    Console.WriteLine("введите числа");
	    a=Convert.ToInt32(Console.ReadLine());
	    b=Convert.ToInt32(Console.ReadLine());
	    
	    if(a%2==0)
	    {
	        w++;
	    }
	    
	    if(a%2==0)
	    {
    	    r=a;
	    }
	    
	    
	    
	    do
	    {
	        if(a==b)    //макс. размер подпоследовательности одинаковых элементов
	        {
                q++;
            }
            if(q>z)
            {
                z=q;
            }
            if(a!=b)
            {
                q=1;
            }
            
            if(b%2==0)    //мин. размер подпоследовательности четных
	        {
                w++;
	        }
            if(w>y)
            {
                y=w;
            }
            if(b%2==1)
            {
                if(y<e)
                {
                    e=y;
                }
                w=0;
                y=0;
            }
            
            if(b%2==0)    //макс. сумма подпоследовательности четных
	        {
                r+=b;
            }
            if(r>t)
            {
                t=r;
            }
            if(b%2==1)
            {
                r=0;
            }
            
            if(y<e)
            {
                e=y;
            }
            
	        n--;
	        a=b;
	        b=Convert.ToInt32(Console.ReadLine());
	    }
	    while(n>1);
	    
	    Console.WriteLine("макс. размер подпоследовательности, состоящей из одинаковых элементов = "+z);
	    Console.WriteLine("мин. размер подпоследовательности, состоящей из четных элементов = "+e);
	    Console.WriteLine("макс. сумма подпоследовательности, состоящей из четных элементов = "+t);
	}
}
