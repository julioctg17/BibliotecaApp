using System;
using System.Collections.Generic;

namespace BibliotecaApp.DataStructures
{
    public class DoublyLinkedList<T>
    {
        private DNode<T> head;
        private DNode<T> tail;
        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            head = tail = null;
            Count = 0;
        }

        public void AddLast(T item)
        {
            var node = new DNode<T>(item);
            if (head == null) head = tail = node;
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            Count++;
        }

        public IEnumerable<T> TraverseForward()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void SwapNodesData(DNode<T> a, DNode<T> b)
        {
            var temp = a.Data;
            a.Data = b.Data;
            b.Data = temp;
        }

        public DNode<T> First => head;
        public DNode<T> Last => tail;
    }
}
