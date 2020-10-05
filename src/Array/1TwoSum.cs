/*
 * File: 1TwoSum.cs
 * Project: Array
 * Created Date: Monday, 5th October 2020 2:31:54 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 232 ms, faster than 98.41% of C# online submissions for Two Sum.
 * Memory Usage: 31.7 MB, less than 9.48% of C# online submissions for Two Sum.
 * -----
 * Last Modified: Monday, 5th October 2020 2:56:59 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var d = new Dictionary<int, int>(nums.Length);
            foreach (var i in Enumerable.Range(0, nums.Length))
            {
                var a = nums[i];
                var b = target - a;
                if (d.ContainsKey(b)) return new int[] { d[b], i };
                else d[a] = i;
            }
            return Array.Empty<int>();
        }
    }
}