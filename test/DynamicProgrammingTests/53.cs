/*
 * File: 53.cs
 * Project: DynamicProgrammingTests
 * Created Date: Sunday, 6th September 2020 7:36:02 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using MaximumSubarray;

namespace DynamicProgrammingTests
{
    public class MaximumSubarrayTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var expected = 6;
            var actual = sln.MaxSubArray(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var nums = new int[] { 1 };
            var expected = 1;
            var actual = sln.MaxSubArray(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var nums = new int[] { 0 };
            var expected = 0;
            var actual = sln.MaxSubArray(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase4()
        {
            var nums = new int[] { -1 };
            var expected = -1;
            var actual = sln.MaxSubArray(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase5()
        {
            var nums = new int[] { int.MinValue };
            var expected = int.MinValue;
            var actual = sln.MaxSubArray(nums);
            Assert.Equal(expected, actual);
        }
    }
}