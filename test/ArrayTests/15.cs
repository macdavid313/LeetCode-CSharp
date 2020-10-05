/*
 * File: 15.cs
 * Project: ArrayTests
 * Created Date: Monday, 5th October 2020 2:52:31 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Monday, 5th October 2020 3:03:17 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using ThreeSum;
using System;

namespace ArrayTests
{
    public class ThreeSumTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };
            var expected = new int[][]
            {
                new int[] { -1, -1, 2 },
                new int[] { -1, 0, 1 }
            };
            var actual = sln.ThreeSum(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var nums = Array.Empty<int>();
            var expected = Array.Empty<int[]>();
            var actual = sln.ThreeSum(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var nums = new int[] { 0 };
            var expected = Array.Empty<int[]>();
            var actual = sln.ThreeSum(nums);
            Assert.Equal(expected, actual);
        }
    }
}