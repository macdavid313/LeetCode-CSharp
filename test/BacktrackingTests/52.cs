/*
 * File: 52.cs
 * Project: BacktrackingTests
 * Created Date: Sunday, 6th September 2020 10:02:26 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using NQueensII;

namespace BacktrackingTests
{
    public class NQueensIITest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var n = 4;
            var expected = 2;
            var actual = sln.TotalNQueens(n);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var n = 5;
            var expected = 10;
            var actual = sln.TotalNQueens(n);
            Assert.Equal(expected, actual);
        }
    }
}