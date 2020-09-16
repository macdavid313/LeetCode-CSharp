/*
 * File: 216CombinationSumIII.cs
 * Project: Backtracking
 * Created Date: Friday, 11th September 2020 8:13:31 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 200 ms, faster than 97.67% of C# online submissions for Combination Sum III.
 * Memory Usage: 25.5 MB, less than 58.91% of C# online submissions for Combination Sum III.
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace CombinationSumIII
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            if (n < 1) throw new ArgumentException(null, nameof(n));
            if (k < 1) throw new ArgumentException(null, nameof(k));

            var combinations = new List<int[]>();
            Span<int> buffer = stackalloc int[k];
            for (var i = 1; i <= 9; i++)
            {
                buffer[0] = i;
                Backtrack(combinations, buffer, 1, k, n - i);
            }
            return combinations.ToArray();
        }

        void Backtrack(List<int[]> combinations, Span<int> buffer, int fill, int k, int target)
        {
            if (target == 0 && fill == k)
            {
                combinations.Add(buffer.ToArray());
                return;
            }
            if (fill == k || target < 0) return;
            for (var i = buffer[fill - 1] + 1; i <= 9; i++)
            {
                buffer[fill] = i;
                Backtrack(combinations, buffer, fill + 1, k, target - i);
            }
        }
    }
}