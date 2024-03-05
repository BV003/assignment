using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("欢迎使用控制台计算器程序！");
        Console.WriteLine("请输入第一个数字：");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("请输入第二个数字：");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("请输入运算符（+、-、*、/）：");
        char op = Convert.ToChar(Console.ReadLine());

        double result = 0;

        switch (op)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    Console.WriteLine("错误：除数不能为零！");
                    return;
                }
                break;
            default:
                Console.WriteLine("错误：无效的运算符！");
                return;
        }

        Console.WriteLine("计算结果为：" + result);
       
    }
}