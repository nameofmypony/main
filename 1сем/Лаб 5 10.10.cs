using System;
class Q
{
    static void Main()
	{
	    int n,q,z,m=0,l=0;
	    Console.WriteLine("введите кол-во элементов массива");
	    n=Convert.ToInt32(Console.ReadLine());
		int[] a=new int[n];
		int[] b=new int[n];
		Console.WriteLine("введите элементы массива");
		for(int i=0;i<n;i++)
		{
		    z=1;
		    a[i]=Convert.ToInt32(Console.ReadLine());
		    q=a[i];
		    while(q>0)
		    {
		        if((q%10)%2==1)
		        {
		            z*=0;
		        }
		        q=q/10;
		    }
		    if(z==1)
		    {
		        m++;
		    }
		}
		for(int i=0;i<n;i++)
		{
		    Console.Write(a[i]+" ");
		}
		Console.WriteLine();
		Console.WriteLine("кол-во элементов, все цифры которых четные = "+m);
		
		
		for(int i=0;i<n;i++)
		{
		    if (a[i]%2==0)
		    {
		        b[l]=a[i];
		        l++;
		    }
		}
		for(int i=0;i<n;i++)
		{
		    if (a[i]%2==1)
		    {
		        b[l]=a[i];
		        l++;
		    }
		}
		
		
		for(int i=0;i<n;i++)
		{
		    if (a[i]%2==0)
		    {
		        a[i]=0;
		    }
		    else a[i]=1;
		}
		
		
		for(int i=0;i<n;i++)
		{
		    Console.Write(a[i]+" ");
		}
		Console.WriteLine();
		for(int i=0;i<n;i++)
		{
		    Console.Write(b[i]+" ");
		}
	}
}
