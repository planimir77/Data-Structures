namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                CheckIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                Grow();
            }
            this.items[this.Count] = item;
            this.Count++;
        }

        private void Grow()
        {
            var length = this.items.Length;
            var newArray = new T[length * 2];
            Array.Copy(this.items, newArray, length);
            this.items = newArray;
        }

        public bool Contains(T item)
        {
            return this.items.Any(x => x.Equals(item));
        }

        public int IndexOf(T item)
        {
            var reversedArray = this.items.Take(this.Count).Reverse().ToArray();

            for (int index = 0; index < reversedArray.Length; index++)
            {
                if (reversedArray[index].Equals(item))
                {
                    return index;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            CheckIndex(index);

            if (this.Count == this.items.Length)
            {
                Grow();
            }

            for (int i = this.Count; i >= this.Count - index; i--)
            {
                if (i == this.Count - index)
                {
                    this.items[i] = item;
                    this.Count++;
                }
                else
                {
                    this.items[i] = this.items[i - 1];
                }
            }

        }

        public bool Remove(T item)
        {
            var index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }
            else
            {
                RemoveAt(index);
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            for (int i = this.Count - index -1; i <= this.Count - 1; i++)
            {
                if (i == this.Count - 1)
                {
                    this.items[i] = default;
                    this.Count--;

                }
                else
                {
                    this.items[i] = this.items[i + 1];
                }

            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i <= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}