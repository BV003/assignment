using System;
using System.Collections.Generic;

// 定义一个抽象形状类
public abstract class Shape
{
    // 计算面积的抽象方法
    public abstract double CalculateArea();
}

// 定义长方形类
public class Rectangle : Shape
{
    private double length;
    private double width;

    // 长度属性
    public double Length
    {
        get { return length; }
        set { length = value; }
    }

    // 宽度属性
    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    // 实现计算面积的方法
    public override double CalculateArea()
    {
        return Length * Width;
    }
}

// 定义正方形类，继承自长方形类
public class Square : Rectangle
{
    // 边长属性
    public double Side
    {
        get { return Length; }
        set { Length = Width = value; }
    }
}

// 定义三角形类
public class Triangle : Shape
{
    private double triangleBase;
    private double height;

    // 底边长属性
    public double Base
    {
        get { return triangleBase; }
        set { triangleBase = value; }
    }

    // 高度属性
    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    // 实现计算面积的方法
    public override double CalculateArea()
    {
        return 0.5 * Base * Height;
    }
}

// 形状类型枚举
public enum ShapeType
{
    Rectangle,
    Square,
    Triangle
}

// 形状工厂类
public static class ShapeFactory
{
    public static Shape CreateShape(ShapeType shapeType)
    {
        Random random = new Random();

        switch (shapeType)
        {
            case ShapeType.Rectangle:
                double length = random.NextDouble() * (10 - 1) + 1; // 生成1到10之间的随机长度
                double width = random.NextDouble() * (10 - 1) + 1; // 生成1到10之间的随机宽度
                return new Rectangle { Length = length, Width = width };

            case ShapeType.Square:
                double side = random.NextDouble() * (10 - 1) + 1; // 生成1到10之间的随机边长
                return new Square { Side = side };

            case ShapeType.Triangle:
                double triangleBase = random.NextDouble() * (10 - 1) + 1; // 生成1到10之间的随机底边长
                double height = random.NextDouble() * (10 - 1) + 1; // 生成1到10之间的随机高度
                return new Triangle { Base = triangleBase, Height = height };

            default:
                throw new ArgumentException("Invalid shape type");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        double totalArea = 0;

        for (int i = 0; i < 10; i++)
        {
            ShapeType shapeType = (ShapeType)new Random().Next(0, 3);
            Shape shape = ShapeFactory.CreateShape(shapeType);
            shapes.Add(shape);
            totalArea += shape.CalculateArea();
        }

        // 输出每个形状对象的面积
        for (int i = 0; i < shapes.Count; i++)
        {
            Console.WriteLine($"Shape {i + 1}: {shapes[i].GetType().Name}, Area: {shapes[i].CalculateArea()}");
        }

        // 输出所有形状对象的面积之和
        Console.WriteLine("Total Area: " + totalArea);
    }
}