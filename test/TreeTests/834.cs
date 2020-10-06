/*
 * File: 834.cs
 * Project: TreeTests
 * Created Date: Tuesday, 6th October 2020 6:48:28 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Tuesday, 6th October 2020 6:50:53 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using SumOfDistancesInTree;

namespace TreeTests
{
    public class SumOfDistancesInTreeTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var N = 6;
            var edges = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 2, 3 },
                new int[] { 2, 4 },
                new int[] { 2, 5 },
            };
            var expected = new int[] { 8, 12, 6, 10, 10, 10 };
            var actual = sln.SumOfDistancesInTree(N, edges);
            Assert.Equal(expected, actual);
        }
    }
}