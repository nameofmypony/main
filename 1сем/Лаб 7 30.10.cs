using System;
class Q
{
    static void Main()
    {
        //задание массива
        int z,chet,nechet,m,w=0;
        int[][]a=new int[4][];
        for(int i=0;i<4;i++)
        {
            Console.WriteLine("задайте размерность "+(i+1)+" массива");
            z=Convert.ToInt32(Console.ReadLine());
            a[i]=new int[z];
            Console.WriteLine("задайте элементы "+(i+1)+" массива");
            for(int j=0;j<z;j++)
            {
                a[i][j]=Convert.ToInt32(Console.ReadLine());
            }
        }
        //вывод массива
        Console.WriteLine("массив:");
        for(int i=0;i<4;i++)
        {
            for(int j=0;j<a[i].Length;j++)
            {
                Console.Write(a[i][j]+" ");
            }
            Console.WriteLine("");
        }
        //кол-во четных и нечетных элементов строк
        for(int i=0;i<4;i++)
        {
            chet=0;
            nechet=0;
            for(int j=0;j<a[i].Length;j++)
            {
                if(a[i][j]%2==0)
                {
                    chet+=1;
                }
                else nechet+=1;
            }
            Console.WriteLine(i+1+" строка: четных "+chet+" нечетных "+nechet);
        }
        //положение элементов строк, значение которых больше суммы остальных
        for(int i=0;i<4;i++)
        {
            Console.Write("положение элемента "+(i+1)+" строки, значение которого больше суммы остальных: ");
            w=0;
            for(int j=0;j<a[i].Length;j++)
            {
                m=0;
                for(int q=0;q<a[i].Length;q++)
                {
                    m+=a[i][q];
                }
                if((a[i].Length!=1)&&(2*a[i][j]>m))
                {
                    Console.Write((j+1)+" ");
                    w++;
                }
                
            }
            if((w==0)||(a[i].Length==1))
            {
                Console.Write("не существует");
            }
            Console.WriteLine();
        }
    }
}
