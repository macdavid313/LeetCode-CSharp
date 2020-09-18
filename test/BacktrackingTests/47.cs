/*
 * File: 47.cs
 * Project: BacktrackingTests
 * Created Date: Friday, 18th September 2020 4:22:50 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Friday, 18th September 2020 4:26:30 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using PermutationsII;
using Xunit.Abstractions;

namespace BacktrackingTests
{
    public class PermutationsIITest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var nums = new int[] { 1, 1, 2 };
            var expected = new int[][]
            {
                new int[] { 1, 1, 2},
                new int[] { 1, 2, 1 },
                new int[] { 2, 1, 1 }
            };
            var actual = sln.PermuteUnique(nums);
            foreach (var x in actual)
            {
                Assert.Contains(x, expected);
            }
        }
    }
}