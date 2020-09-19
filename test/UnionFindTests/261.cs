/*
 * File: 261.cs
 * Project: UnionFindTests
 * Created Date: Saturday, 19th September 2020 3:37:28 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Saturday, 19th September 2020 3:50:51 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using GraphValidTree;

namespace UnionFindTests
{
    public class GraphValidTreeTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var n = 5;
            var edges = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 0, 3 },
                new int[] { 1, 4 }
            };
            var expected = true;
            var actual = sln.ValidTree(n, edges);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var n = 5;
            var edges = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 1, 3 },
                new int[] { 1, 4 }
            };
            var expected = false;
            var actual = sln.ValidTree(n, edges);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var n = 4;
            var edges = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 2, 3 },
            };
            var expected = false;
            var actual = sln.ValidTree(n, edges);
            Assert.Equal(expected, actual);
        }
    }
}