/*
 * File: 486PredictTheWinner.cs
 * Project: DynamicProgramming
 * Created Date: Tuesday, 1st September 2020 1:32:00 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 88 ms, faster than 97.62% of C# online submissions for Predict the Winner.
 * Memory Usage: 23.4 MB, less than 97.62% of C# online submissions for Predict the Winner.
 * Copyright (c) David Gu 2020
 */


using System;

namespace PredictTheWinner
{
    public class Solution
    {
        readonly static int[,] dp = new int[20, 20];

        public bool PredictTheWinner(int[] nums)
        {
            if (nums.Length % 2 == 0) return true;

            for (var i = 0; i < 20; i++)
                for (var j = 0; j < 20; j++)
                    dp[i, j] = 0;

            var n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = nums[i];
            }
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    dp[i, j] = Math.Max(nums[i] - dp[i + 1, j], nums[j] - dp[i, j - 1]);
                }
            }
            return dp[0, n - 1] >= 0;
        }
    }
}