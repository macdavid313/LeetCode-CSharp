/*
 * File: 63UniquePathsII.cs
 * Project: DynamicProgramming
 * Created Date: Thursday, 8th October 2020 10:04:03 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 88 ms, faster than 91.36% of C# online submissions for Unique Paths II.
 * Memory Usage: 25.2 MB, less than 7.72% of C# online submissions for Unique Paths II.
 * -----
 * Last Modified: Thursday, 8th October 2020 10:04:22 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


namespace UniquePathsII
{
    public class Solution
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var m = obstacleGrid.Length;
            var n = obstacleGrid[0].Length;
            var dp = new int[m, n];
            dp[0, 0] = 1;

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        dp[i, j] = 0;
                        continue;
                    }
                    if (i == 0 && j > 0) dp[i, j] = dp[i, j - 1] == 0 ? 0 : 1;
                    else if (j == 0 && i > 0) dp[i, j] = dp[i - 1, j] == 0 ? 0 : 1;
                    else if (i > 0 && j > 0) dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];
        }
    }
}