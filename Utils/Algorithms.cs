using System;
using System.Collections.Generic;
using BibliotecaApp.DataStructures;
using BibliotecaApp.Models;

namespace BibliotecaApp.Utils
{
    public static class Algorithms
    {
        // ============================================================
        // 🔹 QUICK SORT
        // ============================================================
        public static void QuickSort<T>(DoublyLinkedList<T> list, Comparison<T> comparison)
        {
            if (list == null || list.Count <= 1)
                return;

            T[] array = new T[list.Count];
            int index = 0;

            foreach (var item in list.TraverseForward())
                array[index++] = item;

            QuickSortArray(array, 0, array.Length - 1, comparison);

            list.Clear();
            foreach (var item in array)
                list.AddLast(item);
        }

        private static void QuickSortArray<T>(T[] array, int low, int high, Comparison<T> comparison)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high, comparison);
                QuickSortArray(array, low, pivotIndex - 1, comparison);
                QuickSortArray(array, pivotIndex + 1, high, comparison);
            }
        }

        private static int Partition<T>(T[] array, int low, int high, Comparison<T> comparison)
        {
            T pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (comparison(array[j], pivot) <= 0)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }

            (array[i + 1], array[high]) = (array[high], array[i + 1]);
            return i + 1;
        }

        // ============================================================
        // 🔹 BUBBLE SORT
        // ============================================================
        public static void BubbleSort<T>(DoublyLinkedList<T> list, Comparison<T> comparison)
        {
            if (list == null || list.Count <= 1)
                return;

            bool swapped;
            do
            {
                swapped = false;
                var current = list.First;

                while (current != null && current.Next != null)
                {
                    if (comparison(current.Data, current.Next.Data) > 0)
                    {
                        list.SwapNodesData(current, current.Next);
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }

        // ============================================================
        // 🔹 INSERTION SORT
        // ============================================================
        public static void InsertionSort<T>(DoublyLinkedList<T> list, Comparison<T> comparison)
        {
            if (list == null || list.Count <= 1)
                return;

            T[] array = new T[list.Count];
            int index = 0;

            foreach (var item in list.TraverseForward())
                array[index++] = item;

            for (int i = 1; i < array.Length; i++)
            {
                T key = array[i];
                int j = i - 1;

                while (j >= 0 && comparison(array[j], key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }

            list.Clear();
            foreach (var item in array)
                list.AddLast(item);
        }

        // ============================================================
        // 🔹 COMPARADORES PARA LIBROS
        // ============================================================
        public static int CompareByTitle(Book a, Book b)
            => string.Compare(a.Title, b.Title, StringComparison.CurrentCultureIgnoreCase);

        public static int CompareByYear(Book a, Book b)
            => a.Year.CompareTo(b.Year);

        // ============================================================
        // 🔹 BÚSQUEDA LINEAL (para btnBuscar)
        // ============================================================
        public static List<T> LinearSearch<T>(DoublyLinkedList<T> list, Func<T, bool> condition)
        {
            var result = new List<T>();
            foreach (var item in list.TraverseForward())
            {
                if (condition(item))
                    result.Add(item);
            }
            return result;
        }
    }
}