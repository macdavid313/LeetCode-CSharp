/*
 * File: 684.cs
 * Project: test
 * Created Date: Sunday, 23rd August 2020 7:59:05 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using RedundantConnection;

namespace UnionFindTests
{
    public class RedundantConnectionTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestSingleEdge()
        {
            var edges = new int[1][] { new int[] { 1, 2 } };
            var expected = System.Array.Empty<int>();
            var actual = sln.FindRedundantConnection(edges);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase1()
        {
            var edges = new int[3][] {
                new int[] { 1, 2 },
                new int[] { 1, 3 },
                new int[] { 2, 3 }
            };
            var expected = new int[2] { 2, 3 };
            var actual = sln.FindRedundantConnection(edges);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var edges = new int[5][] {
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 1, 4 },
                new int[] { 1, 5 }
        };
            var expected = new int[2] { 1, 4 };
            var actual = sln.FindRedundantConnection(edges);
            Assert.Equal(expected, actual);
        }
    }
}