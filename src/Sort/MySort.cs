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
    public abstract class Sorting<T>
    {
        readonly IComparer<T> _comparer;
        readonly static Random random = new Random();

        protected Sorting(IComparer<T> comparer = null)
        {
            _comparer = comparer is null ? Comparer<T>.Default : comparer;
        }

        public abstract void Sort(T[] arr);

        protected static void Shuffle(T[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                var idx = random.Next(0, i + 1);
                Swap(arr, i, idx);
            }
        }

        protected bool Less(T a, T b) => _comparer.Compare(a, b) < 0;

        protected int Compare(T a, T b) => _comparer.Compare(a, b);

        protected static void Swap(T[] arr, int i, int j)
        {
            T tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }

    public class SelectionSort<T> : Sorting<T>
    {
        public SelectionSort(IComparer<T> comparer = null) : base(comparer) { }

        public override void Sort(T[] arr)
        {
            if (arr is null) throw new ArgumentNullException(nameof(arr));
            if (arr.Length <= 1) return;

            for (var i = 0; i < arr.Length; i++)
            {
                var jMin = i;
                for (var j = i + 1; j < arr.Length; j++)
                {
                    if (Less(arr[j], arr[jMin]))
                        jMin = j;
                }
                if (jMin != i)
                    Swap(arr, i, jMin);
            }
        }
    }

    public class InsertionSort<T> : Sorting<T>
    {
        public InsertionSort(IComparer<T> comparer = null) : base(comparer) { }

        public override void Sort(T[] arr)
        {
            if (arr is null) throw new ArgumentNullException(nameof(arr));
            if (arr.Length <= 1) return;

            for (var i = 1; i < arr.Length; i++)
            {
                for (var j = i; j > 0 && Less(arr[j], arr[j - 1]); j--)
                {
                    Swap(arr, j, j - 1);
                }
            }
        }
    }

    public class ShellSort<T> : Sorting<T>
    {
        /*  https://oeis.org/A033622 */
        readonly static int[] gapSequence = new int[] { 3905, 2161, 929, 505, 209, 109, 41, 19, 5, 1 };

        public ShellSort(IComparer<T> comparer = null) : base(comparer) { }

        public override void Sort(T[] arr)
        {
            if (arr is null) throw new ArgumentNullException(nameof(arr));
            if (arr.Length <= 1) return;

            foreach (var gap in gapSequence)
            {
                for (var i = gap; i < arr.Length; i++)
                {
                    for (var j = i; j >= gap && Less(arr[j], arr[j - gap]); j -= gap)
                    {
                        Swap(arr, j, j - gap);
                    }
                }
            }
        }
    }

    public class BubbleSort<T> : Sorting<T>
    {
        public BubbleSort(IComparer<T> comparer = null) : base(comparer) { }

        public override void Sort(T[] arr)
        {
            if (arr is null) throw new ArgumentNullException(nameof(arr));
            if (arr.Length <= 1) return;

            var n = arr.Length;
            while (true)
            {
                var swapped = false;
                for (var i = 1; i < n; i++)
                {
                    if (Less(arr[i], arr[i - 1]))
                    {
                        Swap(arr, i, i - 1);
                        if (!swapped) swapped = true;
                    }
                }
                if (!swapped) break;
                else n -= 1;
            }
        }
    }

    public class MergeSort<T> : Sorting<T>
    {
        public MergeSort(IComparer<T> comparer = null) : base(comparer) { }

        public T[] MSort(T[] lst)
        {
            if (lst is null) throw new ArgumentNullException(nameof(lst));
            if (lst.Length <= 1) return lst;

            var mid = lst.Length / 2;
            var left = MSort(lst[0..mid]);
            var right = MSort(lst[mid..lst.Length]);
            return MyMergeSortMerge(left, right);
        }

        public override void Sort(T[] arr) => throw new NotImplementedException();

        T[] MyMergeSortMerge(T[] left, T[] right)
        {
            var aux = new T[left.Length + right.Length];
            var mid = left.Length;
            var pLeft = 0;
            var pRight = 0;
            for (var i = 0; i < aux.Length; i++)
            {
                if (pLeft == mid)
                {
                    aux[i] = right[pRight];
                    pRight += 1;
                }
                else if (pRight == right.Length)
                {
                    aux[i] = left[pLeft];
                    pLeft += 1;
                }
                else if (Less(left[pLeft], right[pRight]))
                {
                    aux[i] = left[pLeft];
                    pLeft += 1;
                }
                else
                {
                    aux[i] = right[pRight];
                    pRight += 1;
                }
            }
            return aux;
        }
    }

    public class QuickSort<T> : Sorting<T>
    {
        public QuickSort(IComparer<T> comparer = null) : base(comparer) { }

        public override void Sort(T[] arr)
        {
            if (arr is null) throw new ArgumentNullException(nameof(arr));
            if (arr.Length <= 1) return;

            Shuffle(arr);
            Sort(arr, 0, arr.Length - 1);
        }

        void Sort(T[] arr, int lo, int hi)
        {
            if (lo < hi)
            {
                var p = Partition(arr, lo, hi);
                Sort(arr, lo, p);
                Sort(arr, p + 1, hi);
            }
        }

        int Partition(T[] lst, int lo, int hi)
        {
            var pivot = lst[(lo + hi) / 2];
            var i = lo - 1;
            var j = hi + 1;
            while (true)
            {
                do i += 1; while (Less(lst[i], pivot));
                do j -= 1; while (Less(pivot, lst[j]));
                if (i >= j) return j;
                Swap(lst, i, j);
            }
        }
    }

    public class Quick3WaySort<T> : Sorting<T>
    {
        public Quick3WaySort(IComparer<T> comparer = null) : base(comparer) { }

        public override void Sort(T[] lst)
        {
            if (lst is null) throw new ArgumentNullException(nameof(lst));
            if (lst.Length <= 1) return;
            Shuffle(lst);
            Sort(lst, 0, lst.Length - 1);
        }

        void Sort(T[] lst, int lo, int hi)
        {
            if (lo < hi)
            {
                Partition(lst, lo, hi, out int left, out int right);
                Sort(lst, lo, left - 1);
                Sort(lst, right + 1, hi);
            }
        }

        void Partition(T[] lst, int lo, int hi, out int left, out int right)
        {
            var pivot = lst[(lo + hi) / 2];
            var i = lo;
            left = lo;
            right = hi;
            while (i <= right)
            {
                var cmp = Compare(lst[i], pivot);
                if (cmp < 0)
                {
                    Swap(lst, i, left);
                    i += 1;
                    left += 1;
                }
                else if (cmp > 0)
                {
                    Swap(lst, i, right);
                    right -= 1;
                }
                else i += 1;
            }
        }
    }

    public class HeapSort<T> : Sorting<T>
    {
        public HeapSort(IComparer<T> comparer = null) : base(comparer) { }

        public override void Sort(T[] lst)
        {
            if (lst is null) throw new ArgumentNullException(nameof(lst));
            if (lst.Length <= 1) return;

            for (var k = lst.Length / 2 - 1; k >= 0; k--)
            {
                Heapify(lst, lst.Length, k);
            }

            for (var i = lst.Length - 1; i > 0; i--)
            {
                Swap(lst, 0, i);
                Heapify(lst, i, 0);
            }
        }

        void Heapify(T[] lst, int len, int k)
        {
            while (2 * k + 1 < len)
            {
                var j = 2 * k + 1;
                // choose the bigger child
                if (j + 1 < len && Less(lst[j], lst[j + 1])) j += 1;
                if (!Less(lst[k], lst[j])) return;
                Swap(lst, k, j);
                k = j;
            }
        }
    }

    public class StringLSD
    {
        const int _radix = 256;

        public void Sort(string[] strings, int w)
        {
            var aux = new string[strings.Length];
            var count = new int[_radix + 1];
            for (var d = w - 1; d >= 0; d--)
            {
                Array.Fill(count, 0);
                for (var i = 0; i < strings.Length; i++)
                    count[strings[i][d] + 1] += 1;
                for (var i = 0; i < _radix; i++)
                    count[i + 1] += count[i];
                for (var i = 0; i < aux.Length; i++)
                    aux[count[strings[i][d]]++] = strings[i];
                Array.Copy(aux, strings, aux.Length);
            }
        }
    }

    public class StringMSD
    {
        const int _radix = 256;
        // const int _m = 15;
        static string[] _aux;

        public void Sort(string[] strings)
        {
            _aux = new string[strings.Length];
            Sort(strings, 0, strings.Length - 1, 0);
        }

        void Sort(string[] strings, int lo, int hi, int d)
        {
            /* if (hi <= lo + _m)
            {
                var comparer = Comparer<string>.Create(new Comparison<string>((x, y) => CharAt(x, d).CompareTo(CharAt(y, d))));
                var insertionSort = new InsertionSort<string>(comparer);
                insertionSort.Sort(strings[lo..(hi + 1)]);
                return;
            } */
            if (hi <= lo) return;
            var count = new int[_radix + 2];
            for (var i = lo; i <= hi; i++)
                count[CharAt(strings[i], d) + 2] += 1;
            for (var i = 0; i < _radix + 1; i++)
                count[i + 1] += count[i];
            for (var i = lo; i <= hi; i++)
                _aux[count[CharAt(strings[i], d) + 1]++] = strings[i];
            Array.Copy(_aux, 0, strings, lo, hi - lo + 1);
            for (var r = 0; r < _radix; r++)
                Sort(strings, lo + count[r], lo + count[r + 1] - 1, d + 1);
        }

        int CharAt(string str, int i) => i < str.Length ? Convert.ToInt32(str[i]) : -1;
    }
}