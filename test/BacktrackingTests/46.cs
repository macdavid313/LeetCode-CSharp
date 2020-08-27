/*
 * File: 46.cs
 * Project: BacktrackingTests
 * Created Date: Thursday, 27th August 2020 2:43:44 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using Permutations;

namespace BacktrackingTests
{
    public class PermutationsTest
    {
        readonly Solution sln = new Solution();

#pragma warning disable
        [Fact]
        public void TestBase()
        {
            var nums = new int[3] { 1, 2, 3 };
            var expected = new int[6][] {
                new int[] {1, 2, 3},
                new int[] {1, 3, 2},
                new int[] {2, 1, 3},
                new int[] {2, 3, 1},
                new int[] {3, 1, 2},
                new int[] {3, 2, 1}
            };
            var actual = sln.Permute(nums);
            Assert.True(true);
        }
    }
}