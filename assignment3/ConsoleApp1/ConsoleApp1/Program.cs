using System;

// 定义一个抽象形状类
public abstract class Shape
{
    // 计算面积的抽象方法
    public abstract double CalculateArea();

    // 判断形状是否合法的虚方法
    public virtual bool IsValidShape()
    {
        return true;
    }
}

// 定义长方形类
public class Rectangle : Shape
{
    // 长度属性
    public double Length { get; set; }

    // 宽度属性
    public double Width { get; set; }

    // 实现计算面积的方法
    public override double CalculateArea()
    {
        return Length * Width;
    }

    // 重写判断形状是否合法的方法
    public override bool IsValidShape()
    {
        return Length > 0 && Width > 0;
    }
}

// 定义正方形类，继承自长方形类
public class Square : Rectangle
{
    // 边长属性
    public double Side
    {
        get { return Length; }
        set
        {
            Length = value;
            Width = value;
        }
    }
}

// 定义三角形类
public class Triangle : Shape
{
    // 边长属性
    public double Side1 { get; set; }
    public double Side2 { get; set; }
    public double Side3 { get; set; }

    // 实现计算面积的方法（使用海伦公式）
    public override double CalculateArea()
    {
        double p = (Side1 + Side2 + Side3) / 2;
        return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
    }

    // 重写判断形状是否合法的方法
    public override bool IsValidShape()
    {
        return (Side1 + Side2 > Side3) && (Side2 + Side3 > Side1) && (Side3 + Side1 > Side2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 创建一个长方形对象
        Rectangle rectangle = new Rectangle();
        rectangle.Length = 5;
        rectangle.Width = 3;
        Console.WriteLine("长方形的面积：" + rectangle.CalculateArea());
        Console.WriteLine("长方形是否合法：" + rectangle.IsValidShape());

        // 创建一个正方形对象
        Square square = new Square();
        square.Side = 4;
        Console.WriteLine("正方形的面积：" + square.CalculateArea());
        Console.WriteLine("正方形是否合法：" + square.IsValidShape());

        // 创建一个三角形对象
        Triangle triangle = new Triangle();
        triangle.Side1 = 3;
        triangle.Side2 = 4;
        triangle.Side3 = 5;
        Console.WriteLine("三角形的面积：" + triangle.CalculateArea());
        Console.WriteLine("三角形是否合法：" + triangle.IsValidShape());

        Console.ReadLine();
    }
}