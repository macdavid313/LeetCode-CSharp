/*
 * File: MySort.cs
 * Project: Sort
 * Created Date: Friday, 28th August 2020 12:50:03 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace MySort
{
    public static class MySort<T> where T : IComparable<T>
    {
        /*  https://oeis.org/A033622 */
        readonly static int[] gapSequence = new int[] { 3905, 2161, 929, 505, 209, 109, 41, 19, 5, 1 };

        public static void MySelectionSort(IList<T> lst)
        {
            if (lst is null) throw new ArgumentNullException(nameof(lst));
            if (lst.Count <= 1) return;

            for (var i = 0; i < lst.Count; i++)
            {
                var jMin = i;
                for (var j = i + 1; j < lst.Count; j++)
                {
                    if (Less(lst[j], lst[jMin]))
                        jMin = j;
                }
                if (jMin != i)
                    Swap(lst, i, jMin);
            }
        }

        public static void MyInsertionSort(IList<T> lst)
        {
            if (lst is null) throw new ArgumentNullException(nameof(lst));
            if (lst.Count <= 1) return;

            for (var i = 1; i < lst.Count; i++)
            {
                for (var j = i; j > 0 && Less(lst[j], lst[j - 1]); j--)
                {
                    Swap(lst, j, j - 1);
                }
            }
        }

        public static void MyShellSort(IList<T> lst)
        {
            if (lst is null) throw new ArgumentNullException(nameof(lst));
            if (lst.Count <= 1) return;

            foreach (var gap in gapSequence)
            {
                for (var i = gap; i < lst.Count; i++)
                {
                    for (var j = i; j >= gap && Less(lst[j], lst[j - gap]); j -= gap)
                    {
                        Swap(lst, j, j - gap);
                    }
                }
            }
        }

        public static void MyBubbleSort(IList<T> lst)
        {
            if (lst is null) throw new ArgumentNullException(nameof(lst));
            if (lst.Count <= 1) return;

            var n = lst.Count;
            while (true)
            {
                var swapped = false;
                for (var i = 1; i < n; i++)
                {
                    if (Less(lst[i], lst[i - 1]))
                    {
                        Swap(lst, i, i - 1);
                        if (!swapped) swapped = true;
                    }
                }
                if (!swapped) break;
                else n -= 1;
            }
        }

        static bool Less(T a, T b) => a.CompareTo(b) == -1;

        static void Swap(IList<T> lst, int i, int j)
        {
            T tmp = lst[i];
            lst[i] = lst[j];
            lst[j] = tmp;
        }
    }
}