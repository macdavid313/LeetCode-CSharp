/*
 * File: 1288RemoveCoveredIntervals.cs
 * Project: Interval
 * Created Date: Wednesday, 30th September 2020 7:42:00 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 104 ms, faster than 95.45% of C# online submissions for Remove Covered Intervals.
 * Memory Usage: 29.9 MB, less than 9.09% of C# online submissions for Remove Covered Intervals.
 * -----
 * Last Modified: Wednesday, 30th September 2020 7:58:41 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace RemoveCoveredIntervals
{
    public class Solution
    {
        static readonly IComparer<int[]> _comparer = Comparer<int[]>.Create((x, y) => x[0] == y[0] ? y[1].CompareTo(x[1]) : x[0].CompareTo(y[0]));

        public int RemoveCoveredIntervals(int[][] intervals)
        {
            if (intervals.Length == 1) return 1;

            Array.Sort(intervals, _comparer);
            var l = intervals[0][0];
            var r = intervals[0][1];
            var count = 0;
            foreach (var interval in intervals[1..])
            {
                var a = interval[0];
                var b = interval[1];
                // covered
                if (l <= a && b <= r) count += 1;
                // to merge
                if (a <= r && r <= b) r = b;
                // disjoint
                if (r < a)
                {
                    l = a;
                    r = b;
                }
            }
            return intervals.Length - count;
        }
    }
}