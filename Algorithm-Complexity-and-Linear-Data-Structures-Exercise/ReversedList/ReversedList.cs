using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private readonly int initialSize = 2;
    private T[] reversedList;

    public ReversedList()
    {
        this.reversedList = new T[initialSize];
        this.Count = 0;
        this.Capacity = initialSize;
    }

    public int Count { get; private set; }

    public int Capacity { get; set; }

    public T this[int index]
    {
        get
        {
            ValidateIndex(index);
            return this.reversedList[index];
        }
        set
        {
            ValidateIndex(index);
            this.reversedList[index] = value;
            this.Count++;
        }
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void Add(T item)
    {
        if (this.Count >= this.Capacity)
        {
            Array.Resize(ref this.reversedList, this.Capacity * 2);
            this.Capacity *= 2;
        }
        this[this.Count] = item;
    }

    public T RemoveAt(int index)
    {
        ValidateIndex(index);
        var removedItem = this.reversedList[index];
        for (int i = index; i < this.Count - 1; i++)
        {
            this.reversedList[i] = this.reversedList[index + 1];
        }
        this.Count--;
        return removedItem;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int index = this.Count - 1; index >= 0; index--)
        {
            yield return this.reversedList[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
