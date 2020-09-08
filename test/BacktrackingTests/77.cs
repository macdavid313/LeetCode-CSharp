/*
 * File: 77.cs
 * Project: BacktrackingTests
 * Created Date: Tuesday, 8th September 2020 7:27:27 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using Combinations;

namespace BacktrackingTests
{
    public class CombinationsTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var n = 1;
            var k = 1;
            var expected = new int[1][] { new int[1] { 1 } };
            var actual = sln.Combine(n, k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var n = 4;
            var k = 2;
            var expected = new int[6][]
            {
                new int[] { 1, 2 } ,
                new int[] { 1, 3 } ,
                new int[] { 1, 4 } ,
                new int[] { 2, 3 } ,
                new int[] { 2, 4 } ,
                new int[] { 3, 4 } ,
            };
            var actual = sln.Combine(n, k);
            foreach (var combination in actual)
            {
                Assert.Contains(combination, expected);
            }
        }

        [Fact]
        public void TestCase3()
        {
            var n = 4;
            var k = 3;
            var expected = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 1, 3, 4 },
                new int[] { 2, 3, 4 },
                new int[] { 1, 2, 4 },
            };
            var actual = sln.Combine(n, k);
            foreach (var combination in actual)
            {
                Assert.Contains(combination, expected);
            }
        }
    }
}