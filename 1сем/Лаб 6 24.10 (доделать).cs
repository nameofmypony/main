using System;
class Q
{
	static void Main()
	{
	  //задание массива
	  int m,n,sum1,sum2,z;
	  m=Convert.ToInt32(Console.ReadLine());
	  n=Convert.ToInt32(Console.ReadLine());
		int[,]a=new int[m,n];
		for(int i=0;i<m;i++)
		{
		  for(int j=0;j<n;j++)
		  {
		    a[i,j]=Convert.ToInt32(Console.ReadLine());
		  }
		}
		//вывод исходного массива
		Console.WriteLine("исходный массив:");
		for(int i=0;i<m;i++)
    {
      for(int j=0;j<n;j++)
      {
        Console.Write(a[i,j] + "\t");
      }
      Console.WriteLine();
    }
		//сортировка столбцов по возрастанию их суммы
		int[,]b=a;
		for(int q=0;q<n-1;q++)
		{
		  for(int j=0;j<n-1;j++)
		  {
		    sum1=0;
		    sum2=0;
		    for(int i=0;i<m;i++)
		    {
		      sum1+=b[i,j];
		      sum2+=b[i,j+1];
		    }
		    if(sum1>sum2)
		    {
		      for(int i=0;i<m;i++)
		      {
		        z=b[i,j];
		        b[i,j]=b[i,j+1];
		        b[i,j+1]=z;
		      }
		    }
		  }
		}
		//вывод отсортированного массива
		Console.WriteLine("отсортированный массив:");
		for(int i=0;i<m;i++)
    {
      for(int j=0;j<n;j++)
      {
        Console.Write(b[i,j] + "\t");
      }
      Console.WriteLine();
    }
    //определение пар строк, состоящих из одинаковых элементов(1 1 2 и 1 2 1 считается)
    
    //определение элементов минимакса
    
	}
}
