/*
 * File: 37.cs
 * Project: BacktrackingTests
 * Created Date: Tuesday, 15th September 2020 8:18:04 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System.Linq;
using Xunit;
using SudokuSolver;

namespace BacktrackingTests
{
    public class SudokuSolverTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var board = new char[][]
            {
                "53..7....".ToArray(),
                "6..195...".ToArray(),
                ".98....6.".ToArray(),
                "8...6...3".ToArray(),
                "4..8.3..1".ToArray(),
                "7...2...6".ToArray(),
                ".6....28.".ToArray(),
                "...419..5".ToArray(),
                "....8..79".ToArray()
            };
            var expected = new char[][]
            {
                "534678912".ToArray(),
                "672195348".ToArray(),
                "198342567".ToArray(),
                "859761423".ToArray(),
                "426853791".ToArray(),
                "713924856".ToArray(),
                "961537284".ToArray(),
                "287419635".ToArray(),
                "345286179".ToArray(),
            };
            sln.SolveSudoku(board);
            Assert.Equal(expected, board);
        }
    }
}