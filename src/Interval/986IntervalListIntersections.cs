/*
 * File: 986IntervalListIntersections.cs
 * Project: Interval
 * Created Date: Wednesday, 30th September 2020 11:09:44 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 332 ms, faster than 76.47% of C# online submissions for Merge Intervals.
 * Memory Usage: 35 MB, less than 90.00% of C# online submissions for Merge Intervals.
 * -----
 * Last Modified: Wednesday, 30th September 2020 12:42:20 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace IntervalListIntersections
{
    public class Solution
    {
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            if (A.Length == 0) return Array.Empty<int[]>();
            if (B.Length == 0) return Array.Empty<int[]>();
            var (i, j) = (0, 0);
            var intersections = new List<int[]>();
            while (i < A.Length && j < B.Length)
            {
                var a = A[i];
                var b = B[j];
                var inter = Intersect(a, b);
                if (inter is object) intersections.Add(inter);

                if (a[1] <= b[1]) i += 1;
                else j += 1;
            }
            return intersections.ToArray();
        }

        int[] Intersect(int[] a, int[] b)
        {
            if (a[1] < b[0] || b[1] < a[0]) return null;
            return new int[] { Math.Max(a[0], b[0]), Math.Min(a[1], b[1]) };
        }
    }
}