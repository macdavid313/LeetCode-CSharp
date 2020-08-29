/*
 * File: 264UglyNumberII.cs
 * Project: Math
 * Created Date: Friday, 28th August 2020 9:28:37 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 40 ms, faster than 98.53% of C# online submissions for Ugly Number II.
 * Memory Usage: 14.6 MB, less than 98.38% of C# online submissions for Ugly Number II.
 * Copyright (c) David Gu 2020
 */


using System;

namespace UglyNumberII
{
    public class Solution
    {
        public int NthUglyNumber(int n)
        {
            return UglyNumberSequence.NumAt(n);
        }
    }

    class UglyNumberSequence
    {
        readonly static int maxLen = 1690;
        readonly static int[] sequence = new int[maxLen];

        static UglyNumberSequence()
        {
            sequence[0] = 1;
            var i2 = 0;
            var i3 = 0;
            var i5 = 0;
            for (var idx = 1; idx < maxLen; idx++)
            {
                var factor = Min(sequence[i2] * 2, sequence[i3] * 3, sequence[i5] * 5);
                sequence[idx] = factor;
                if (factor == sequence[i2] * 2) i2 += 1;
                if (factor == sequence[i3] * 3) i3 += 1;
                if (factor == sequence[i5] * 5) i5 += 1;
            }
        }

        public static int NumAt(int nth)
        {
            if (nth < 1)
                throw new InvalidOperationException(nameof(nth));
            return sequence[nth - 1];
        }

        static int Min(int x, int y) => x < y ? x : y;

        static int Min(int x, int y, int z) => x < y ? Min(x, z) : Min(y, z);
    }
}