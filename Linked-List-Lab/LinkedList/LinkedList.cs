using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node head;

    private Node tail;

    public int Count { get; private set; }

    public LinkedList()
    {
        this.head = null;
        this.tail = null;
        this.Count = 0;
    }

    public void AddFirst(T item)
    {
        Node newNode = new Node(item);
        if (this.Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.Next = head;
            this.head = newNode;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node newNode = new Node(item);
        if (this.Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            this.tail.Next = newNode;
            this.tail = newNode;    
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException();
        }

        var item = this.head.Value;

        this.head = this.head.Next;
        this.Count--;

        return item;
    }

    private bool IsEmpty()
    {
        return this.Count == 0;
    }

    public T RemoveLast()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException();
        }

        var item = tail.Value;

        var current = this.head;
        while (current.Next != null)
        {
            if (current.Next == this.tail)
            {
                this.tail = current;
                break;
            }
            current = current.Next;
        }

        
        this.Count--;

        return item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.head;
        while (current.Next != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public Node Next { get; set; }
    }
}
