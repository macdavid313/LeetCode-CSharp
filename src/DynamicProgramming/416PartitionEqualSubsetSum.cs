/*
 * File: 416PartitionEqualSubsetSum.cs
 * Project: DynamicProgramming
 * Created Date: Sunday, 11th October 2020 12:23:52 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 212 ms, faster than 28.38% of C# online submissions for Partition Equal Subset Sum.
 * Memory Usage: 37.3 MB, less than 7.09% of C# online submissions for Partition Equal Subset Sum.
 * -----
 * Last Modified: Sunday, 11th October 2020 12:43:20 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


namespace PartitionEqualSubsetSum
{
    public class Solution
    {
        public bool CanPartition(int[] nums)
        {
            if (nums.Length < 2) return false;

            var (sum, maxElement) = (0, int.MinValue);
            foreach (var n in nums)
            {
                sum += n;
                maxElement = maxElement < n ? n : maxElement;
            }
            if (sum % 2 == 1) return false;
            if (maxElement > sum / 2) return false;

            var target = sum / 2;
            var dp = new bool[nums.Length, target + 1];
            for (var i = 0; i < nums.Length; i++) dp[i, 0] = true;
            dp[0, nums[0]] = true;
            for (var i = 1; i < nums.Length; i++)
            {
                for (var j = 1; j <= target; j++)
                {
                    if (j >= nums[i])
                    {
                        dp[i, j] = dp[i - 1, j] | dp[i - 1, j - nums[i]];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }
            return dp[nums.Length - 1, target];
        }
    }
}