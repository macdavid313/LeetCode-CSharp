/*
 * File: 47PermutationsII.cs
 * Project: Backtracking
 * Created Date: Friday, 18th September 2020 4:21:55 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 260 ms, faster than 54.35% of C# online submissions for Permutations II.
 * Memory Usage: 32.6 MB, less than 89.79% of C# online submissions for Permutations II.
 * -----
 * Last Modified: Friday, 18th September 2020 6:37:49 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace PermutationsII
{
    public class Solution
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            if (nums is null) throw new ArgumentNullException(nameof(nums));
            if (nums.Length == 0) return Array.Empty<int[]>();
            if (nums.Length == 1) return new int[][] { nums };

            Array.Sort(nums);
            var permutations = new List<int[]>();
            List<int> perm = new List<int>(nums.Length);
            Span<bool> marked = stackalloc bool[nums.Length];
            Backtrack(permutations, nums, 0, marked, perm);
            return permutations.ToArray();
        }

        void Backtrack(List<int[]> permutations, int[] nums, int fill, Span<bool> marked, List<int> perm)
        {
            if (fill == nums.Length)
            {
                permutations.Add(perm.ToArray());
                return;
            }
            foreach (var i in Enumerable.Range(0, nums.Length))
            {
                if (marked[i] || (i - 1 >= 0 && nums[i - 1] == nums[i] && !marked[i - 1])) continue;
                perm.Add(nums[i]);
                marked[i] = true;
                Backtrack(permutations, nums, fill + 1, marked, perm);
                marked[i] = false;
                perm.RemoveAt(fill);
            }
        }
    }
}