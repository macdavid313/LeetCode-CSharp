/*
 * File: 16ThreeSumClosest.cs
 * Project: Array
 * Created Date: Friday, 9th October 2020 8:02:18 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 96 ms, faster than 87.50% of C# online submissions for 3Sum Closest.
 * Memory Usage: 25.4 MB, less than 19.76% of C# online submissions for 3Sum Closest.
 * -----
 * Last Modified: Friday, 9th October 2020 8:31:59 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;

namespace ThreeSumClosest
{
    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            var best = 0;
            var bestDiff = int.MaxValue;
            var i = 0;
            while (i <= nums.Length - 3)
            {
                var a = nums[i];
                var (j, k) = (i + 1, nums.Length - 1);
                while (j < k)
                {
                    var (b, c) = (nums[j], nums[k]);
                    var (sum, diff) = (a + b + c, Math.Abs(target - a - b - c));
                    if (diff == 0) return target;
                    else if (sum < target)
                    {
                        Update(sum, diff, ref best, ref bestDiff);
                        while (j < k && nums[j] == b) j += 1;
                    }
                    else
                    {
                        Update(sum, diff, ref best, ref bestDiff);
                        while (j < k && nums[k] == c) k -= 1;
                    }
                }
                while (i <= nums.Length - 3 && nums[i] == a) i += 1;
            }
            return best;
        }

        void Update(int sum, int diff, ref int best, ref int bestDiff)
        {
            if (diff < bestDiff)
            {
                best = sum;
                bestDiff = diff;
            }
        }
    }
}