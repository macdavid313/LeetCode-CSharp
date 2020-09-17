/*
 * File: 685.cs
 * Project: UnionFindTests
 * Created Date: Thursday, 17th September 2020 9:29:43 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Thursday, 17th September 2020 9:30:05 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using RedundantConnectionII;

namespace UnionFindTests
{
    public class RedundantConnectionIITest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var edges = new int[][]
            {
                new int[] {1, 2},
                new int[] {1, 3},
                new int[] {2, 3}
            };
            var expected = new int[] { 2, 3 };
            var actual = sln.FindRedundantDirectedConnection(edges);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var edges = new int[][]
            {
                new int[] {1, 2},
                new int[] {2, 3},
                new int[] {3, 4},
                new int[] {4, 1},
                new int[] {1, 5}
            };
            var expected = new int[] { 4, 1 };
            var actual = sln.FindRedundantDirectedConnection(edges);
            Assert.Equal(expected, actual);
        }
    }
}