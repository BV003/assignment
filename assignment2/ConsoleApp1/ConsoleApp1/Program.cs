
using System;

class ConsoleApp1
{
    static void Main(string[] args)
    {
        Console.Write("请输入一个整数：");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine($"输入的整数 {number} 的素数因子为：");
        PrintPrimeFactors(number);
    }

    static void PrintPrimeFactors(int number)
    {
        // 从2开始逐个判断是否为number的因子
        for (int factor = 2; factor <= number; factor++)
        {
            // 判断是否为质数
            if (IsPrime(factor))
            {
                // 判断是否为number的因子
                while (number % factor == 0)
                {
                    Console.WriteLine(factor);
                    number /= factor;
                }
            }
        }
    }

    static bool IsPrime(int number)
    {
        // 判断是否为质数
        if (number < 2)
            return false;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}
