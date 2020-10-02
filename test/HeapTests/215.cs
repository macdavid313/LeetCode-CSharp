/*
 * File: 215.cs
 * Project: HeapTests
 * Created Date: Saturday, 3rd October 2020 9:28:45 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Saturday, 3rd October 2020 9:31:21 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using KthLargestElementInAnArray;

namespace HeapTests
{
    public class KthLargestElementInAnArrayTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var nums = new int[] { 3, 2, 1, 5, 6, 4 };
            var k = 2;
            var expected = 5;
            var actual = sln.FindKthLargest(nums, k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var nums = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            var k = 4;
            var expected = 4;
            var actual = sln.FindKthLargest(nums, k);
            Assert.Equal(expected, actual);
        }
    }
}