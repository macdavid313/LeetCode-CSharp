/*
 * File: 39CombinationSum.cs
 * Project: Backtracking
 * Created Date: Wednesday, 9th September 2020 9:04:15 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 220 ms, faster than 100.00% of C# online submissions for Combination Sum.
 * Memory Usage: 31.2 MB, less than 99.47% of C# online submissions for Combination Sum.
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;

namespace CombinationSum
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var solutions = new List<int[]>();
            Backtrack(solutions, new List<int>(), 0, candidates, 0, target);
            return solutions.ToArray();
        }

        void Backtrack(List<int[]> solutions, List<int> combination, int currentSum, int[] candidates, int ptr, int target)
        {
            if (currentSum == target)
            {
                solutions.Add(combination.ToArray());
                return;
            }
            if (ptr == candidates.Length || currentSum > target) return;

            // Skip the current one directly
            Backtrack(solutions, combination, currentSum, candidates, ptr + 1, target);

            // Use the current one
            var n = candidates[ptr];
            if (currentSum + n <= target)
            {
                combination.Add(n);
                Backtrack(solutions, combination, currentSum + n, candidates, ptr, target);
                combination.RemoveAt(combination.Count - 1);
            }
        }
    }
}