/*
 * File: 908SmallestRangeI.cs
 * Project: Misc
 * Created Date: Sunday, 23rd August 2020 3:33:59 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 228 ms, faster than 7.69% of C# online submissions for Smallest Range I.
 * Memory Usage: 28.1 MB, less than 100.00% of C# online submissions for Smallest Range I.
 * Copyright (c) David Gu 2020
 */


namespace SmallestRangeI
{
    public class Solution
    {
        public int SmallestRangeI(int[] A, int K)
        {
            // it seems that if it uses A.Max() and A.Min() here
            // it would be slightly faster
            var max = int.MinValue;
            var min = int.MaxValue;
            foreach (int a in A)
            {
                if (a > max)
                {
                    max = a;
                }
                if (a < min)
                {
                    min = a;
                }
            }

            if (K == 0) return max - min;
            var x = min + K;
            var y = max - K;
            if (x < y)
            {
                return y - x;
            }
            return 0;
        }
    }
}