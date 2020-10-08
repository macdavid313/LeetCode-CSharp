/*
 * File: 259ThreeSumSmaller.cs
 * Project: Array
 * Created Date: Friday, 9th October 2020 9:11:13 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Friday, 9th October 2020 9:35:18 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;

namespace ThreeSumSmaller
{
    public class Solution
    {
        public int ThreeSumSmaller(int[] nums, int target)
        {
            Array.Sort(nums);
            var count = 0;
            for (var i = 0; i <= nums.Length - 3; i++)
            {
                var (j, k) = (i + 1, nums.Length - 1);
                while (j < k)
                {
                    if (nums[j] + nums[k] < target - nums[i])
                    {
                        count += k - j;
                        j += 1;
                    }
                    else k -= 1;
                }
            }
            return count;
        }
    }
}