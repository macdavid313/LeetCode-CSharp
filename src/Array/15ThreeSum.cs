/*
 * File: 15ThreeSum.cs
 * Project: Array
 * Created Date: Monday, 5th October 2020 2:43:45 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 316 ms, faster than 50.62% of C# online submissions for 3Sum.
 * Memory Usage: 47.4 MB, less than 8.35% of C# online submissions for 3Sum.
 * -----
 * Last Modified: Monday, 5th October 2020 3:06:03 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace ThreeSum
{
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            var i = 0;
            while (i <= nums.Length - 2)
            {
                var a = nums[i];
                foreach (var (b, c) in TwoSum(nums[(i + 1)..], 0 - a))
                    res.Add(new int[] { a, b, c });
                while (i <= nums.Length - 2 && nums[i] == a) i += 1;
            }
            return res;
        }

        IEnumerable<ValueTuple<int, int>> TwoSum(int[] nums, int target)
        {
            var (lo, hi) = (0, nums.Length - 1);
            while (lo < hi)
            {
                var (left, right) = (nums[lo], nums[hi]);
                var sum = left + right;
                if (sum < target)
                    while (lo < hi && nums[lo] == left) lo += 1;
                else if (sum > target)
                    while (lo < hi && nums[hi] == right) hi -= 1;
                else
                {
                    yield return (left, right);
                    while (lo < hi && nums[lo] == left) lo += 1;
                    while (lo < hi && nums[hi] == right) hi -= 1;
                }
            }
        }
    }
}