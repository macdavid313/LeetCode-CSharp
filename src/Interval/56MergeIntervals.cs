/*
 * File: 56MergeIntervals.cs
 * Project: Interval
 * Created Date: Wednesday, 30th September 2020 9:53:07 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 256 ms, faster than 90.55% of C# online submissions for Merge Intervals.
 * Memory Usage: 34.2 MB, less than 5.04% of C# online submissions for Merge Intervals.
 * -----
 * Last Modified: Wednesday, 30th September 2020 10:51:52 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeIntervals
{
    public class Solution
    {
        static readonly IComparer<int[]> _comparer = Comparer<int[]>.Create((x, y) => x[0] == y[0] ? y[1].CompareTo(x[1]) : x[0].CompareTo(y[0]));

        public int[][] Merge(int[][] intervals)
        {
            if (intervals is null || intervals.Length == 0) return Array.Empty<int[]>();
            if (intervals.Length == 1) return new int[][] { intervals[0] };

            Array.Sort(intervals, _comparer);
            var merged = new List<int[]> { intervals[0] };
            foreach (var interval in intervals[1..])
            {
                var last = merged.Last();
                var l = last[0];
                var r = last[1];
                var a = interval[0];
                var b = interval[1];

                if (b <= r) continue;
                if (l <= a && a <= r) last[1] = b;
                if (a > r) merged.Add(interval);
            }
            return merged.ToArray();
        }
    }
}