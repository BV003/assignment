using System;

// 定义形状接口
public interface IShape
{
    double CalculateArea(); // 计算面积
    bool IsValid(); // 判断形状是否合法
}

// 抽象类 Shape，实现 IShape 接口的一些通用功能
public abstract class Shape : IShape
{
    public abstract double CalculateArea(); // 计算面积，由子类实现
    public abstract bool IsValid(); // 判断形状是否合法，由子类实现
}

// 长方形类
public class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public double Length
    {
        get { return length; }
        set { length = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public override double CalculateArea()
    {
        return length * width;
    }

    public override bool IsValid()
    {
        return length > 0 && width > 0;
    }
}

// 正方形类
public class Square : Rectangle
{
    public Square(double side) : base(side, side)
    {
    }
}

// 三角形类
public class Triangle : Shape
{
    private double side1;
    private double side2;
    private double side3;

    public Triangle(double side1, double side2, double side3)
    {
        this.side1 = side1;
        this.side2 = side2;
        this.side3 = side3;
    }

    public override double CalculateArea()
    {
        // 海伦公式计算三角形面积
        double s = (side1 + side2 + side3) / 2;
        return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
    }

    public override bool IsValid()
    {
        // 三角形合法性判断：任意两边之和大于第三边
        return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle(5, 4);
        Console.WriteLine("Rectangle Area: " + rectangle.CalculateArea());
        Console.WriteLine("Rectangle Is Valid: " + rectangle.IsValid());

        Square square = new Square(5);
        Console.WriteLine("Square Area: " + square.CalculateArea());
        Console.WriteLine("Square Is Valid: " + square.IsValid());

        Triangle triangle = new Triangle(3, 4, 5);
        Console.WriteLine("Triangle Area: " + triangle.CalculateArea());
        Console.WriteLine("Triangle Is Valid: " + triangle.IsValid());
    }
}

