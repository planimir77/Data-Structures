using System;

public class ArrayList<T>
{
    private T[] items;

    public int Count { get; set; }
    public int Capacity { get; set; }

    public ArrayList(int initialCapacity = 2)
    {
        this.Capacity = initialCapacity;
        this.items = new T[this.Capacity];
    }

    public T this[int index]
    {
        get
        {
            return this.items[index];
        }

        set
        {
            this.ValidateIndex(index);

            this.items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count >= this.Capacity)
        {
            this.Grow();
        }

        this.items[this.Count] = item;
        this.Count++;
    }

    public T RemoveAt(int index)
    {
        this.ValidateIndex(index);

        var removedItem = this.items[index];
        for (int i = index; i < this.Count - 1; i++)
        {
            this.items[i] = this.items[i + 1];
        }

        this.Count--;

        return removedItem;
    }

    private void Grow()
    {
        var newSize = this.Capacity * 2;
        Array.Resize(ref this.items, newSize);
        this.Capacity = newSize;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index > this.Capacity - 1)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
