/*
 * File: 78.cs
 * Project: BacktrackingTests
 * Created Date: Sunday, 20th September 2020 4:38:51 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Sunday, 20th September 2020 5:11:49 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using Subsets;
using System;

namespace BacktrackingTests
{
    public class SubsetsTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var nums = new int[] { 1, 2, 3 };
            var expected = new int[][]
            {
                Array.Empty<int>(),
                new int[] { 1 },
                new int[] { 2 },
                new int[] { 3 },
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 1, 3 },
                new int[] { 1, 2, 3}
            };
            var actual = sln.Subsets(nums);
            foreach (var x in actual)
            {
                Assert.Contains(x, expected);
            }
        }
    }
}