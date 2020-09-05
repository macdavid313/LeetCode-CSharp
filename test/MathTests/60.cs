/*
 * File: 60.cs
 * Project: MathTests
 * Created Date: Saturday, 5th September 2020 3:31:29 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using PermutationSequence;

namespace BacktrackingTests
{
    public class PermutationSequenceTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var n = 3;
            var k = 3;
            var expected = "213";
            var actual = sln.GetPermutation(n, k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var n = 4;
            var k = 9;
            var expected = "2314";
            var actual = sln.GetPermutation(n, k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var n = 9;
            var k = 1024;
            var expected = "124678593";
            var actual = sln.GetPermutation(n, k);
            Assert.Equal(expected, actual);
        }
    }
}