using System;
// See https://aka.ms/new-console-template for more information
class ConsoleApp3
{
    static void Main(string[] args)
    {
        int[] a = new int[101];//数组用于标记是否被筛过，0代表为素数，1代表为合数
       
       for(int i=2;i<=10;i++)
        {
            if (a[i]==0)
            {
                for(int j=i;i*j<=100;j++)
                {
                    a[i * j] = 1;
                }
            }
        }
        for(int i = 2; i <= 100; i++) if (a[i]==0)
        {
                Console.WriteLine(i);
        }
       
    }
   

}
