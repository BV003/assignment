using System.Collections.Generic;

class 

public class Node<T> { 
    public Node<T> Next { get; set; }
    public T Data { get; set; }

    public Node(T t) {
        Next = null;
        Data = t;
    }
}



 class GenericList<T>
{
    private Node<T>? head;
    private Node<T> tail;

    public GenericList()
    {
        tail = head = null;
    }
    public Node<T> Head
    {
        get => head;
    }

    public void Add(T t) {
        Node<T> n = new Node<T>(t);
        if(tail==null)
        {
            head=tail = n;
        }
        else
        {
            tail.Next = n;
            tail = n;
        }
    }

    delegate void Action<T>(T element);

    public void ForEach(Action<T> action)
    {
        Node<T> p = head;
        while(p!=null)
        {
            action(p.Data);
            p= p.Next;
        }
    }


}


