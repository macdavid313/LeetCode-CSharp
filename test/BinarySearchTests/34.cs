/*
 * File: 34.cs
 * Project: BinarySearchTests
 * Created Date: Wednesday, 9th September 2020 3:15:15 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using FindFirstAndLastPositionOfElementInSortedArray;

namespace BinarySearchTests
{
    public class FindFirstAndLastPositionOfElementInSortedArrayTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var nums = new int[] { 5, 7, 7, 8, 8, 10 };
            var target = 8;
            var expected = new int[] { 3, 4 };
            var actual = sln.SearchRange(nums, target);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var nums = new int[] { 5, 7, 7, 8, 8, 10 };
            var target = 6;
            var expected = new int[] { -1, -1 };
            var actual = sln.SearchRange(nums, target);
            Assert.Equal(expected, actual);
        }
    }
}