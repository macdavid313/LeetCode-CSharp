/*
 * File: 53MaximumSubarray.cs
 * Project: DynamicProgramming
 * Created Date: Sunday, 6th September 2020 7:35:17 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 96 ms, faster than 81.81% of C# online submissions for Maximum Subarray.
 * Memory Usage: 25 MB, less than 90.36% of C# online submissions for Maximum Subarray.
 * Copyright (c) David Gu 2020
 */


using System;

namespace MaximumSubarray
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            Span<int> dp = stackalloc int[nums.Length];
            for (var i = 0; i < dp.Length; i++)
            {
                if (i == 0)
                {
                    dp[i] = nums[i];
                    continue;
                }
                dp[i] = Math.Max(nums[i], dp[i - 1] + nums[i]);
            }
            var max = int.MinValue;
            foreach (var x in dp)
            {
                if (x > max) max = x;
            }
            return max;
        }
    }
}