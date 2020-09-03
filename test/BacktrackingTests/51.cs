/*
 * File: 51.cs
 * Project: BacktrackingTests
 * Created Date: Thursday, 3rd September 2020 8:18:50 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;
using Xunit;
using NQueens;

namespace BacktrackingTests
{
    public class NQueensTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var n = 4;
            var expected = new string[2][]
            {
                new string[] {".Q..", "...Q", "Q...", "..Q."},
                new string[] {"..Q.", "Q...","...Q",".Q.."}
            };
            var actual = sln.SolveNQueens(n);
            Assert.Equal(expected, actual);
        }
    }
}