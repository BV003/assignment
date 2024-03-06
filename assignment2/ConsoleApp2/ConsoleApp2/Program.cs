using System;

class ConsoleApp2
{
    static void Main(string[] args)
    {
        Console.Write("请输入整数数组（用空格分隔）：");
        string input = Console.ReadLine();
        string[] numberStrings = input.Split(' ');

        int[] numbers = new int[numberStrings.Length];
        for (int i = 0; i < numberStrings.Length; i++)
        {
            numbers[i] = int.Parse(numberStrings[i]);
        }

        int max = FindMax(numbers);
        int min = FindMin(numbers);
        double average = CalculateAverage(numbers);
        int sum = CalculateSum(numbers);

        Console.WriteLine($"数组的最大值：{max}");
        Console.WriteLine($"数组的最小值：{min}");
        Console.WriteLine($"数组的平均值：{average}");
        Console.WriteLine($"数组的和：{sum}");
    }

    static int FindMax(int[] numbers)
    {
        int max = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
                max = numbers[i];
        }

        return max;
    }

    static int FindMin(int[] numbers)
    {
        int min = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
                min = numbers[i];
        }

        return min;
    }

    static double CalculateAverage(int[] numbers)
    {
        int sum = CalculateSum(numbers);
        double average = (double)sum / numbers.Length;
        return average;
    }

    static int CalculateSum(int[] numbers)
    {
        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }
}
