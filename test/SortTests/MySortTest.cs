/*
 * File: MySortTest.cs
 * Project: SortTests
 * Created Date: Friday, 28th August 2020 2:47:53 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using MySort;
using System.Collections.Generic;

namespace SortTests
{
    public class MySortTest
    {
        [Fact]
        public void MySelectionSortTest()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            MySort<int>.MySelectionSort(actual);
            Assert.Equal(expected, actual);
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
        public void ShellSortTest()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            MySort<int>.MyShellSort(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BubbleSortTest()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            MySort<int>.MyBubbleSort(actual);
            Assert.Equal(expected, actual);
        }
    }
}