/*
 * File: 40CombinationSumII.cs
 * Project: Backtracking
 * Created Date: Wednesday, 9th September 2020 10:31:09 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace CombinationSumII
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var solutions = new List<int[]>();
            var combination = new List<int>(candidates.Length);
            Array.Sort(candidates);
            Backtrack(solutions, combination, candidates, 0, target);
            return solutions.ToArray();
        }

        void Backtrack(List<int[]> solutions, List<int> combination, int[] candidates, int start, int target)
        {
            if (target == 0)
            {
                solutions.Add(combination.ToArray());
                return;
            }
            if (start == candidates.Length || target < 0) return;
            for (var i = start; i < candidates.Length; i++)
            {
                if (target - candidates[i] < 0) break;
                if (i > start && candidates[i] == candidates[i - 1]) continue;
                combination.Add(candidates[i]);
                Backtrack(solutions, combination, candidates, i + 1, target - candidates[i]);
                combination.RemoveAt(combination.Count - 1);
            }
        }
    }
}