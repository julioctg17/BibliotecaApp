using System;
using System.Collections.Generic;
using BibliotecaApp.DataStructures;

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

        public IEnumerable<T> Traverse()
        {
            var current = top;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

