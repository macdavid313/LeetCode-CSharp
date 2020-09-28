/*
 * File: MySortTest.cs
 * Project: SortTests
 * Created Date: Friday, 28th August 2020 2:47:53 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;
using Xunit;
using MySort;
using System.Linq;
using System.Collections.Generic;

namespace SortTests
{
    public static class SampleArray<T>
    {
        const int _defaultLen = 10000;

        public static void Get(out T[] arr, out T[] arrCopy, Func<T> generator, int len = _defaultLen)
        {
            arr = new T[len];
            arrCopy = new T[len];
            foreach (var i in Enumerable.Range(0, len))
                arr[i] = generator();
            Array.Copy(arr, arrCopy, len);
        }
    }

    public class SelectionSortTest
    {
        static readonly Random _random = new Random();

        [Fact]
        public void TestCaseAscending()
        {
            SampleArray<int>.Get(out int[] arr, out int[] arrCopy, () => _random.Next(0, 100));
            Array.Sort(arrCopy);
            var sort = new SelectionSort<int>();
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }

        [Fact]
        public void TestCaseDescending()
        {
            SampleArray<int>.Get(out int[] arr, out int[] arrCopy, () => _random.Next(0, 100));
            Array.Sort(arrCopy, new Comparison<int>((x, y) => y.CompareTo(x)));
            var sort = new SelectionSort<int>(Comparer<int>.Create(new Comparison<int>((x, y) => y.CompareTo(x))));
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }
    }

    public class InsertionSortTest
    {
        static readonly Random _random = new Random();

        [Fact]
        public void TestCaseAscending()
        {
            SampleArray<char>.Get(out char[] arr, out char[] arrCopy, () => Convert.ToChar(_random.Next(65, 91)));
            Array.Sort(arrCopy);
            var sort = new InsertionSort<char>();
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }

        [Fact]
        public void TestCaseDescending()
        {
            SampleArray<char>.Get(out char[] arr, out char[] arrCopy, () => Convert.ToChar(_random.Next(65, 91)));
            Array.Sort(arrCopy, new Comparison<char>((x, y) => y.CompareTo(x)));
            var sort = new InsertionSort<char>(Comparer<char>.Create(new Comparison<char>((x, y) => y.CompareTo(x))));
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }
    }

    public class ShellSortTest
    {
        static readonly Random _random = new Random();

        [Fact]
        public void TestCaseAscending()
        {
            SampleArray<int>.Get(out int[] arr, out int[] arrCopy, () => _random.Next(0, 100));
            Array.Sort(arrCopy);
            var sort = new ShellSort<int>();
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }

        [Fact]
        public void TestCaseDescending()
        {
            SampleArray<int>.Get(out int[] arr, out int[] arrCopy, () => _random.Next(0, 100));
            Array.Sort(arrCopy, new Comparison<int>((x, y) => y.CompareTo(x)));
            var sort = new ShellSort<int>(Comparer<int>.Create(new Comparison<int>((x, y) => y.CompareTo(x))));
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }
    }

    public class BubbleSortTest
    {
        static readonly Random _random = new Random();

        [Fact]
        public void TestCaseAscending()
        {
            SampleArray<char>.Get(out char[] arr, out char[] arrCopy, () => Convert.ToChar(_random.Next(65, 91)));
            Array.Sort(arrCopy);
            var sort = new BubbleSort<char>();
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }

        [Fact]
        public void TestCaseDescending()
        {
            SampleArray<char>.Get(out char[] arr, out char[] arrCopy, () => Convert.ToChar(_random.Next(65, 91)));
            Array.Sort(arrCopy, new Comparison<char>((x, y) => y.CompareTo(x)));
            var sort = new BubbleSort<char>(Comparer<char>.Create(new Comparison<char>((x, y) => y.CompareTo(x))));
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }
    }

    public class MergeSortTest
    {
        static readonly Random _random = new Random();

        [Fact]
        public void TestCaseAscending()
        {
            SampleArray<int>.Get(out int[] arr, out int[] arrCopy, () => _random.Next(0, 100));
            Array.Sort(arrCopy);
            var sort = new MergeSort<int>();
            var actual = sort.MSort(arr);
            Assert.Equal(arrCopy, actual);
        }

        [Fact]
        public void TestCaseDescending()
        {
            SampleArray<int>.Get(out int[] arr, out int[] arrCopy, () => _random.Next(0, 100));
            Array.Sort(arrCopy, new Comparison<int>((x, y) => y.CompareTo(x)));
            var sort = new MergeSort<int>(Comparer<int>.Create(new Comparison<int>((x, y) => y.CompareTo(x))));
            var actual = sort.MSort(arr);
            Assert.Equal(arrCopy, actual);
        }
    }

    public class QuickSortTest
    {
        static readonly Random _random = new Random();

        [Fact]
        public void TestCaseAscending()
        {
            SampleArray<char>.Get(out char[] arr, out char[] arrCopy, () => Convert.ToChar(_random.Next(65, 91)));
            Array.Sort(arrCopy);
            var sort = new QuickSort<char>();
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }

        [Fact]
        public void TestCaseDescending()
        {
            SampleArray<char>.Get(out char[] arr, out char[] arrCopy, () => Convert.ToChar(_random.Next(65, 91)));
            Array.Sort(arrCopy, new Comparison<char>((x, y) => y.CompareTo(x)));
            var sort = new QuickSort<char>(Comparer<char>.Create(new Comparison<char>((x, y) => y.CompareTo(x))));
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }
    }

    public class Quick3WaySortTest
    {
        static readonly Random _random = new Random();

        [Fact]
        public void TestCaseAscending()
        {
            SampleArray<int>.Get(out int[] arr, out int[] arrCopy, () => _random.Next(0, 100));
            Array.Sort(arrCopy);
            var sort = new Quick3WaySort<int>();
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }

        [Fact]
        public void TestCaseDescending()
        {
            SampleArray<int>.Get(out int[] arr, out int[] arrCopy, () => _random.Next(0, 100));
            Array.Sort(arrCopy, new Comparison<int>((x, y) => y.CompareTo(x)));
            var sort = new Quick3WaySort<int>(Comparer<int>.Create(new Comparison<int>((x, y) => y.CompareTo(x))));
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }
    }

    public class HeapSortTest
    {
        static readonly Random _random = new Random();

        [Fact]
        public void TestCaseAscending()
        {
            SampleArray<char>.Get(out char[] arr, out char[] arrCopy, () => Convert.ToChar(_random.Next(65, 91)));
            Array.Sort(arrCopy);
            var sort = new HeapSort<char>();
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }

        [Fact]
        public void TestCaseDescending()
        {
            SampleArray<char>.Get(out char[] arr, out char[] arrCopy, () => Convert.ToChar(_random.Next(65, 91)));
            Array.Sort(arrCopy, new Comparison<char>((x, y) => y.CompareTo(x)));
            var sort = new HeapSort<char>(Comparer<char>.Create(new Comparison<char>((x, y) => y.CompareTo(x))));
            sort.Sort(arr);
            Assert.Equal(arr, arrCopy);
        }
    }

    public class StringLSDTest
    {
        readonly static StringLSD lsd = new StringLSD();
        readonly static Random random = new Random();

        static string GetRandomString(int len)
        {
            var chars = new char[len];
            foreach (var i in Enumerable.Range(0, len))
            {
                var c = Convert.ToChar(random.Next(65, 91));
                chars[i] = c;
            }
            return new string(chars);
        }

        [Fact]
        public void TestCase1()
        {
            var strings = new string[10000];
            foreach (var i in Enumerable.Range(0, strings.Length))
                strings[i] = GetRandomString(10);
            var stringsCopy = new string[10000];
            Array.Copy(strings, stringsCopy, strings.Length);
            Array.Sort(stringsCopy);
            lsd.Sort(strings, 10);
            Assert.Equal(stringsCopy, strings);
        }
    }

    public class StringMSDTest
    {
        readonly static StringMSD msd = new StringMSD();
        readonly static Random random = new Random();

        static string GetRandomString(int maxLen)
        {
            var chars = new char[random.Next(1, maxLen + 1)];
            foreach (var i in Enumerable.Range(0, chars.Length))
            {
                var c = Convert.ToChar(random.Next(65, 91));
                chars[i] = c;
            }
            return new string(chars);
        }

        [Fact]
        public void TestCase1()
        {
            var strings = new string[10];
            foreach (var i in Enumerable.Range(0, strings.Length))
                strings[i] = GetRandomString(10);
            var stringsCopy = new string[10];
            Array.Copy(strings, stringsCopy, strings.Length);
            Array.Sort(stringsCopy);
            msd.Sort(strings);
            Assert.Equal(stringsCopy, strings);
        }

        [Fact]
        public void TestCase2()
        {
            var strings = new string[10000];
            foreach (var i in Enumerable.Range(0, strings.Length))
                strings[i] = GetRandomString(10);
            var stringsCopy = new string[10000];
            Array.Copy(strings, stringsCopy, strings.Length);
            Array.Sort(stringsCopy);
            msd.Sort(strings);
            Assert.Equal(stringsCopy, strings);
        }
    }
}