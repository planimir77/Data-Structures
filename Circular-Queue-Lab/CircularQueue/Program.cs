using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 4;

    private T[] elements;

    private int startIndex;

    private int endIndex;

    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.elements = new T[capacity];
        this.Count = 0;
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            this.Resize();
        }

        if (this.Count != 0)
        {
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
        }
        this.elements[this.endIndex] = element;


        this.Count++;
    }

    private void Resize()
    {
        var newArray = new T[this.elements.Length * 2];
        this.CopyAllElements(newArray);
        this.elements = newArray;
    }

    private void CopyAllElements(T[] newArray)
    {
        for (int i = 0; i < this.Count; i++)
        {
            int index = (i + this.startIndex) % this.elements.Length;
            newArray[i] = this.elements[index];
        }
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        var item = this.elements[this.startIndex];
        //this.elements[this.startIndex] = default;
        this.Count--;
        if (this.Count > 0)
        {
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
        }

        return item;
    }

    public T[] ToArray()
    {
        var newArray = new T[this.Count];
        this.CopyAllElements(newArray);

        return newArray;
    }
}


public class Program
{
    public static void Main()
    {
        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);

        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
