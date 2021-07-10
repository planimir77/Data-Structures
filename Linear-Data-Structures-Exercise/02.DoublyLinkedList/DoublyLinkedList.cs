namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> first;
        private Node<T> last;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>();
            newNode.Item = item;

            if (this.Count == 0)
            {
                this.first = this.last = newNode;
                this.Count++;
                return;
            }
            var tempNode = this.first;

            this.first = newNode;
            this.first.Next = tempNode;
            this.first.Next.Previous = this.first;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>();
            newNode.Item = item;

            if (this.Count == 0)
            {
                this.first = this.last = newNode;
                this.Count++;
                return;
            }
            this.last.Next = newNode;
            this.last.Next.Previous = this.last;
            this.last = this.last.Next;
            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();
            return this.first.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();
            return this.last.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            var node = this.first;
            this.first = node.Next;
            this.Count--;
            return node.Item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            var itemToRemove = this.last.Item;

            if (this.first == this.last)
            {
                this.first = null;
                this.last = null;
            }
            else
            {
                this.last = this.last.Previous;
                this.last.Next = null;
            }

            this.Count--;

            return itemToRemove;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.first;
            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}