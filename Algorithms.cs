using System;
using System.Collections.Generic;
using BibliotecaApp.DataStructures;
using BibliotecaApp.Models;

namespace BibliotecaApp.Utils
{
    /// <summary>
    /// Clase que contiene los algoritmos de ordenamiento y búsqueda.
    /// </summary>
    public static class Algorithms
    {
        public static void BubbleSort<T>(DoublyLinkedList<T> list, Comparison<T> cmp)
        {
            if (list == null || list.Count < 2) return;

            bool swapped;
            do
            {
                swapped = false;
                var node = list.First;
                while (node != null && node.Next != null)
                {
                    if (cmp(node.Data, node.Next.Data) > 0)
                    {
                        list.SwapNodesData(node, node.Next);
                        swapped = true;
                    }
                    node = node.Next;
                }
            } while (swapped);
        }

        public static List<T> LinearSearch<T>(DoublyLinkedList<T> list, Predicate<T> predicate)
        {
            var results = new List<T>();
            foreach (var item in list.TraverseForward())
            {
                if (predicate(item))
                    results.Add(item);
            }
            return results;
        }

        public static int CompareByTitle(Book a, Book b)
            => string.Compare(a.Title, b.Title, StringComparison.CurrentCultureIgnoreCase);

        public static int CompareByYear(Book a, Book b)
            => a.Year.CompareTo(b.Year);
    }
}