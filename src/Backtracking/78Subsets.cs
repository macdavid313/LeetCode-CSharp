/*
 * File: 78Subsets.cs
 * Project: Backtracking
 * Created Date: Sunday, 20th September 2020 4:27:47 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 240 ms, faster than 83.01% of C# online submissions for Subsets.
 * Memory Usage: 30.1 MB, less than 96.66% of C# online submissions for Subsets.
 * -----
 * Last Modified: Sunday, 20th September 2020 5:24:20 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace Subsets
{
    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var subsets = new List<int[]>
            {
                Array.Empty<int>()
            };
            var combination = new List<int>(nums.Length);
            for (var i = 0; i < nums.Length; i++)
            {
                // fill in the first number
                // start backtracking from the consequent numbers
                combination.Add(nums[i]);
                subsets.Add(combination.ToArray());
                Backtrack(nums, i + 1, subsets, combination);
                // recover
                combination.RemoveAt(combination.Count - 1);
            }
            return subsets.ToArray();
        }

        void Backtrack(int[] nums, int i, List<int[]> subsets, List<int> combination)
        {
            if (i == nums.Length) return;
            // enumerate the next number
            for (var j = i; j < nums.Length; j++)
            {
                combination.Add(nums[j]);
                subsets.Add(combination.ToArray());
                Backtrack(nums, j + 1, subsets, combination);
                combination.RemoveAt(combination.Count - 1);
            }
        }
    }
}