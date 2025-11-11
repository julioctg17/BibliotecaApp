using System;

namespace BibliotecaApp.DataStructures
{
    public class SimpleQueue<T>
    {
        private DNode<T> head;
        private DNode<T> tail;
        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var node = new DNode<T>(item);
            if (tail == null)
                head = tail = node;
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            Count++;
        }

        public T Dequeue()
        {
            if (head == null) throw new InvalidOperationException("Cola vacía");
            var value = head.Data;
            head = head.Next;
            if (head == null) tail = null;
            else head.Prev = null;
            Count--;
            return value;
        }

        public bool IsEmpty() => Count == 0;
    }

}
