/*
 * File: 349IntersectionOfTwoArrays.cs
 * Project: Array
 * Created Date: Friday, 9th October 2020 10:05:56 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 240 ms, faster than 77.78% of C# online submissions for Intersection of Two Arrays.
 * Memory Usage: 31.4 MB, less than 27.53% of C# online submissions for Intersection of Two Arrays.
 * -----
 * Last Modified: Friday, 9th October 2020 10:07:24 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace IntersectionOfTwoArrays
{
    public class Solution
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            var (p1, p2) = (0, 0);
            var ans = new List<int>();
            while (p1 < nums1.Length && p2 < nums2.Length)
            {
                var (a, b) = (nums1[p1], nums2[p2]);
                if (a < b)
                {
                    while (p1 < nums1.Length && nums1[p1] == a) p1 += 1;
                }
                else if (a > b)
                {
                    while (p2 < nums2.Length && nums2[p2] == b) p2 += 1;
                }
                else
                {
                    ans.Add(a);
                    while (p1 < nums1.Length && nums1[p1] == a) p1 += 1;
                    while (p2 < nums2.Length && nums2[p2] == b) p2 += 1;
                }
            }
            return ans.ToArray();
        }
    }
}