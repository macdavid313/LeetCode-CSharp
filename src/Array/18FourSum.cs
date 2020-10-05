/*
 * File: 18FourSum.cs
 * Project: Array
 * Created Date: Monday, 5th October 2020 3:15:54 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 336 ms, faster than 33.95% of C# online submissions for 4Sum.
 * Memory Usage: 33.4 MB, less than 7.75% of C# online submissions for 4Sum.
 * -----
 * Last Modified: Monday, 5th October 2020 3:22:35 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace FourSum
{
    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            var res = new List<IList<int>>();
            var i = 0;
            while (i <= nums.Length - 3)
            {
                var a = nums[i];
                foreach (var (b, c, d) in ThreeSum(nums[(i + 1)..], target - a))
                    res.Add(new int[] { a, b, c, d });
                while (i <= nums.Length - 3 && nums[i] == a) i += 1;
            }
            return res;
        }

        IEnumerable<ValueTuple<int, int, int>> ThreeSum(int[] nums, int target)
        {
            var i = 0;
            while (i <= nums.Length - 2)
            {
                var a = nums[i];
                foreach (var (b, c) in TwoSum(nums[(i + 1)..], target - a))
                    yield return (a, b, c);
                while (i <= nums.Length - 2 && nums[i] == a) i += 1;
            }
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