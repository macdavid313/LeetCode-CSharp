/*
 * File: 77Combinations.cs
 * Project: Backtracking
 * Created Date: Tuesday, 8th September 2020 7:24:27 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 228 ms, faster than 99.57% of C# online submissions for Combinations.
 * Memory Usage: 29.6 MB, less than 88.70% of C# online submissions for Combinations.
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace Combinations
{
    public class Solution
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            if (k < 1 || k > n) throw new ArgumentException(null, nameof(k));
            if (n == 1) return new int[1][] { new int[] { 1 } };
            if (n == k)
            {
                var res = new int[n];
                for (var i = 1; i <= n; i++) res[i - 1] = i;
                return new int[1][] { res };
            }

            Span<int> buffer = stackalloc int[k];
            var combinations = new int[GetLength(n, k)][];
            var ptr = 0;
            for (var i = 1; i <= n - k + 1; i++)
            {
                buffer[0] = i;
                Backtrack(combinations, ref ptr, buffer, 1, i, n, k);
            }
            return combinations;
        }

        void Backtrack(int[][] combinations, ref int ptr, Span<int> buffer, int fill, int cur, int n, int k)
        {
            if (fill == k)
            {
                combinations[ptr] = buffer.ToArray();
                ptr += 1;
                return;
            }
            for (var j = cur + 1; j <= n; j++)
            {
                buffer[fill] = j;
                Backtrack(combinations, ref ptr, buffer, fill + 1, j, n, k);
            }
        }

        static int GetLength(int n, int k)
        {
            if (n == k) return 1;
            if (n - k == 1) return n;
            int r = 1;
            for (var d = 1; d <= k; d++)
            {
                r *= n;
                n -= 1;
                r /= d;
            }
            return r;
        }
    }
}