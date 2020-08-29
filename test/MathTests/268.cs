/*
 * File: 268.cs
 * Project: MathTests
 * Created Date: Saturday, 29th August 2020 12:15:08 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using MissingNumber;

namespace MathTests
{
    public class MissingNumbersTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var nums = new int[] { 3, 0, 1 };
            var expected = 2;
            var actual = sln.MissingNumber(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var nums = new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
            var expected = 8;
            var actual = sln.MissingNumber(nums);
            Assert.Equal(expected, actual);
        }
    }
}