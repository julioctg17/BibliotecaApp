using System;

namespace BibliotecaApp.Utils
{
    public class SimpleStack<T>
    {
        private DNode<T> top;
        public int Count { get; private set; }

        public void Push(T item)
        {
            var node = new DNode<T>(item);
            node.Next = top;
            if (top != null) top.Prev = node;
            top = node;
            Count++;
        }

        public T Pop()
        {
            if (top == null) throw new InvalidOperationException("Pila vacía");
            var value = top.Data;
            top = top.Next;
            if (top != null) top.Prev = null;
            Count--;
            return value;
        }

        public bool IsEmpty() => Count == 0;
    }
}
