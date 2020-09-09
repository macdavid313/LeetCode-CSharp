/*
 * File: 39.cs
 * Project: BacktrackingTests
 * Created Date: Wednesday, 9th September 2020 9:05:01 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using CombinationSum;

namespace BacktrackingTests
{
    public class CombinationSumTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var candidates = new int[] { 2, 3, 6, 7 };
            var target = 7;
            var expected = new int[][]
            {
                new int[] {7},
                new int[] {2, 2, 3}
            };
            var actual = sln.CombinationSum(candidates, target);
            foreach (var x in actual)
            {
                Assert.Contains(x, expected);
            }
        }

        [Fact]
        public void TestCase2()
        {
            var candidates = new int[] { 2, 3, 5 };
            var target = 8;
            var expected = new int[][]
            {
                new int[] {2, 2, 2, 2},
                new int[] {2, 3, 3},
                new int[] {3, 5}
            };
            var actual = sln.CombinationSum(candidates, target);
            foreach (var x in actual)
            {
                Assert.Contains(x, expected);
            }
        }
    }
}