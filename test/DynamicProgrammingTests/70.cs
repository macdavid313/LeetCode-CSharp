/*
 * File: 70.cs
 * Project: DynamicProgrammingTests
 * Created Date: Tuesday, 1st September 2020 11:04:03 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using ClimbingStairs;

namespace DynamicProgrammingTests
{
    public class ClimbingStairsTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var n = 2;
            var expected = 2;
            var actual = sln.ClimbStairs(n);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var n = 3;
            var expected = 3;
            var actual = sln.ClimbStairs(n);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var n = 10;
            var expected = 89;
            var actual = sln.ClimbStairs(n);
            Assert.Equal(expected, actual);
        }
    }
}