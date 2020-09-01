/*
 * File: 70ClimbingStairs.cs
 * Project: DynamicProgramming
 * Created Date: Tuesday, 1st September 2020 11:03:26 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 56 ms, faster than 28.76% of C# online submissions for Climbing Stairs.
 * Memory Usage: 14.5 MB, less than 62.22% of C# online submissions for Climbing Stairs.
 * Copyright (c) David Gu 2020
 */


using System;

namespace ClimbingStairs
{
    public class Solution
    {
        readonly static int[] solutions = new int[46];

        static Solution()
        {
            solutions[0] = 0;
            solutions[1] = 1;
            solutions[2] = 2;
            for (var i = 3; i < 46; i++)
            {
                solutions[i] = solutions[i - 1] + solutions[i - 2];
            }
        }

        public int ClimbStairs(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
            return solutions[n];
        }
    }
}