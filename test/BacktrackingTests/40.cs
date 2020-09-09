/*
 * File: 40.cs
 * Project: BacktrackingTests
 * Created Date: Wednesday, 9th September 2020 10:31:41 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 248 ms, faster than 76.92% of C# online submissions for Combination Sum II.
 * Memory Usage: 30.8 MB, less than 81.12% of C# online submissions for Combination Sum II.
 * Copyright (c) David Gu 2020
 */


using Xunit;
using CombinationSumII;

namespace BacktrackingTests
{
    public class CombinationSumIITest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var candidates = new int[] { 10, 1, 2, 7, 6, 1, 5 };
            var target = 8;
            var expected = new int[][]
            {
                new int[] {1, 7},
                new int[] {1, 2, 5},
                new int[] {2, 6},
                new int[] {1, 1, 6}
            };
            var actual = sln.CombinationSum2(candidates, target);
            foreach (var x in actual)
            {
                Assert.Contains(x, expected);
            }
        }

        [Fact]
        public void TestCase2()
        {
            var candidates = new int[] { 2, 5, 2, 1, 2 };
            var target = 5;
            var expected = new int[][]
            {
                new int[] {1, 2, 2},
                new int[] {5},
            };
            var actual = sln.CombinationSum2(candidates, target);
            foreach (var x in actual)
            {
                Assert.Contains(x, expected);
            }
        }
    }
}