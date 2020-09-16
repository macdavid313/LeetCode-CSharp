/*
 * File: 547.cs
 * Project: UnionFindTests
 * Created Date: Sunday, 23rd August 2020 7:27:23 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using FriendCircles;

namespace UnionFindTests
{
    public class FriendCirclesTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestZeroElement()
        {
            var M = System.Array.Empty<int[]>();
            var expected = 0;
            var actual = sln.FindCircleNum(M);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void TestSingleElement()
        {
            var M = new int[1][] { new int[1] { 1 } };
            var expected = 1;
            var actual = sln.FindCircleNum(M);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase1()
        {
            var M = new int[3][] {
                new int[3] {1, 1, 0},
                new int[3] {1, 1, 0},
                new int[3] {0, 0, 1}
            };
            var expected = 2;
            var actual = sln.FindCircleNum(M);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var M = new int[3][] {
                new int[3] {1, 1, 0},
                new int[3] {1, 1, 1},
                new int[3] {0, 1, 1}
            };
            var expected = 1;
            var actual = sln.FindCircleNum(M);
            Assert.Equal(expected, actual);
        }
    }

}