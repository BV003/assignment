using System;

public class ConsoleApp1
{
    public static void Main(string[] args)
    {
        GenericLinkedList<int> intList = new GenericLinkedList<int>();
        for (int x = 0; x < 10; x++)
        {
            intList.Add(x);
        }

        intList.ForEach(item => Console.WriteLine(item)); // 打印链表中的每个元素
        int max = intList.Max((a, b) => a > b ? a : b); // 求最大值
        int min = intList.Min((a, b) => a < b ? a : b); // 求最小值
        int sum = intList.Sum((a, b) => a + b); // 求和

        Console.WriteLine($"Max: {max}, Min: {min}, Sum: {sum}");
    }
}

public class GenericLinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public void ForEach(Action<T> action)
    {
        Node<T> current = head;
        while (current != null)
        {
            action(current.Data);
            current = current.Next;
        }
    }

    public T Min(Func<T, T, T> compare)
    {
        Node<T> current = head;
        T min = current.Data;
        while (current != null)
        {
            min = compare(min, current.Data);
            current = current.Next;
        }
        return min;
    }

    public T Max(Func<T, T, T> compare)
    {
        Node<T> current = head;
        T max = current.Data;
        while (current != null)
        {
            max = compare(max, current.Data);
            current = current.Next;
        }
        return max;
    }

    public T Sum(Func<T, T, T> add)
    {
        Node<T> current = head;
        T sum = add(default(T), current.Data); // 使用默认值进行初始化
        while (current != null)
        {
            sum = add(sum, current.Data);
            current = current.Next;
        }
        return sum;
    }
}

