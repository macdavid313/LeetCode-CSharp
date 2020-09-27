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

namespace SortTests
{
    public class MySortTest
    {
        readonly static int _randomSize = 10000;
        readonly Random _random = new Random();

        void GetSampleArrayData(out int[] arr, out int[] expected)
        {
            arr = new int[_randomSize];
            for (var i = 0; i < _randomSize; i++)
            {
                arr[i] = _random.Next(0, _randomSize);
            }
            var arrCopy = new int[_randomSize];
            Array.Copy(arr, arrCopy, _randomSize);
            Array.Sort(arrCopy);
            expected = arrCopy;
        }

        [Fact]
        public void MySelectionSortTest()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            MySort<int>.MySelectionSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MySelectionSortRandomTest()
        {
            GetSampleArrayData(out int[] arr, out int[] expected);
            MySort<int>.MySelectionSort(arr);
            Assert.Equal(expected, arr);
        }

        [Fact]
        public void InsertionSortTest()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            MySort<int>.MyInsertionSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MyInsertionSortRandomTest()
        {
            GetSampleArrayData(out int[] arr, out int[] expected);
            MySort<int>.MyInsertionSort(arr);
            Assert.Equal(expected, arr);
        }

        [Fact]
        public void ShellSortTest()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            MySort<int>.MyShellSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MyShellSortRandomTest()
        {
            GetSampleArrayData(out int[] arr, out int[] expected);
            MySort<int>.MyShellSort(arr);
            Assert.Equal(expected, arr);
        }

        [Fact]
        public void BubbleSortTest()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            MySort<int>.MyBubbleSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MyBubbleSortRandomTest()
        {
            GetSampleArrayData(out int[] arr, out int[] expected);
            MySort<int>.MyBubbleSort(arr);
            Assert.Equal(expected, arr);
        }

        [Fact]
        public void MergeSortTestCase1()
        {
            var lst = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = MySort<int>.MyMergeSort(lst);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MergeSortTestCase2()
        {
            var lst = new int[] { 10, 10, 9, 9, 8, 8, 7, 7 };
            var expected = new int[] { 7, 7, 8, 8, 9, 9, 10, 10 };
            var actual = MySort<int>.MyMergeSort(lst);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MyMergeSortRandomTest()
        {
            GetSampleArrayData(out int[] arr, out int[] expected);
            var actual = MySort<int>.MyMergeSort(arr);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QuickSortTestCase1()
        {
            var actual = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySort<int>.MyQuickSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QuickSortTestCase2()
        {
            var actual = new int[] { 10, 10, 9, 9, 8, 8, 7, 7 };
            var expected = new int[] { 7, 7, 8, 8, 9, 9, 10, 10 };
            MySort<int>.MyQuickSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MyQuickSortRandomTest()
        {
            GetSampleArrayData(out int[] arr, out int[] expected);
            MySort<int>.MyQuickSort(arr);
            Assert.Equal(expected, arr);
        }

        [Fact]
        public void Quick3WaySortTestCase1()
        {
            var actual = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySort<int>.MyQuickSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Quick3WaySortTestCase2()
        {
            var actual = new int[] { 10, 10, 9, 9, 8, 8, 7, 7 };
            var expected = new int[] { 7, 7, 8, 8, 9, 9, 10, 10 };
            MySort<int>.MyQuick3WaySort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MyQuick3WaySortRandomTest()
        {
            GetSampleArrayData(out int[] arr, out int[] expected);
            MySort<int>.MyQuick3WaySort(arr);
            Assert.Equal(expected, arr);
        }

        [Fact]
        public void HeapSortTestCase1()
        {
            var actual = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            var expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            MySort<int>.MyHeapSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HeapSortTestCase2()
        {
            var actual = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MySort<int>.MyHeapSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HeapSortTestCase3()
        {
            var actual = new int[] { 10, 10, 9, 9, 8, 8, 7, 7 };
            var expected = new int[] { 7, 7, 8, 8, 9, 9, 10, 10 };
            MySort<int>.MyHeapSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MyHeapSortRandomTest()
        {
            GetSampleArrayData(out int[] arr, out int[] expected);
            MySort<int>.MyHeapSort(arr);
            Assert.Equal(expected, arr);
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