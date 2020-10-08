/*
 * File: 980UniquePathsIII.cs
 * Project: Backtracking
 * Created Date: Friday, 9th October 2020 10:16:25 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 92 ms, faster than 72.30% of C# online submissions for Unique Paths III.
 * Memory Usage: 27 MB, less than 27.45% of C# online submissions for Unique Paths III.
 * -----
 * Last Modified: Friday, 9th October 2020 10:52:28 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace UniquePathsIII
{
    public class Solution
    {
        static int[][] _grid;
        static int m;
        static int n;
        static bool[] marked;

        public int UniquePathsIII(int[][] grid)
        {
            _grid = grid;
            (m, n) = (grid.Length, grid[0].Length);
            marked = new bool[m * n];
            var count = 0;
            var (i, j) = FindStartAndMarkObstacles();
            Backtrack(ref count, i, j);
            return count;
        }

        void Backtrack(ref int count, int i, int j)
        {
            marked[i * n + j] = true;
            if (_grid[i][j] == 2 && marked.All(m => m))
            {
                count += 1;
                marked[i * n + j] = false;
                return;
            }
            foreach (var (p, q) in NextStep(i, j))
            {
                Backtrack(ref count, p, q);
            }
            marked[i * n + j] = false;
        }

        ValueTuple<int, int> FindStartAndMarkObstacles()
        {
            var start = (-1, -1);
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (_grid[i][j] == 1) start = (i, j);
                    else if (_grid[i][j] == -1) marked[i * n + j] = true;
                }
            }
            return start;
        }

        IEnumerable<ValueTuple<int, int>> NextStep(int i, int j)
        {
            if (IsValidStep(i - 1, j) && !Visited(i - 1, j)) yield return (i - 1, j);
            if (IsValidStep(i + 1, j) && !Visited(i + 1, j)) yield return (i + 1, j);
            if (IsValidStep(i, j - 1) && !Visited(i, j - 1)) yield return (i, j - 1);
            if (IsValidStep(i, j + 1) && !Visited(i, j + 1)) yield return (i, j + 1);
        }

        bool IsValidStep(int i, int j) => i >= 0 && i < m && j >= 0 && j < n;

        bool Visited(int i, int j) => marked[i * n + j];
    }
}