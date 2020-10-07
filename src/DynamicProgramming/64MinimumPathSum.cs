/*
 * File: 64MinimumPathSum.cs
 * Project: DynamicProgramming
 * Created Date: Thursday, 8th October 2020 10:09:06 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 104 ms, faster than 45.92% of C# online submissions for Minimum Path Sum.
 * Memory Usage: 27 MB, less than 9.32% of C# online submissions for Minimum Path Sum.
 * -----
 * Last Modified: Thursday, 8th October 2020 10:15:50 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;

namespace MinimumPathSum
{
    public class Solution
    {
        public int MinPathSum(int[][] grid)
        {
            var (m, n) = (grid.Length, grid[0].Length);
            var dp = new int[m, n];
            dp[0, 0] = grid[0][0];
            for (var i = 1; i < m; i++) dp[i, 0] = grid[i][0] + dp[i - 1, 0];
            for (var j = 1; j < n; j++) dp[0, j] = grid[0][j] + dp[0, j - 1];
            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j] + grid[i][j], dp[i, j - 1] + grid[i][j]);
                }
            }
            return dp[m - 1, n - 1];
        }
    }
}