/*
 * File: 60PermutationSequence.cs
 * Project: Math
 * Created Date: Saturday, 5th September 2020 3:30:27 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 80 ms, faster than 78.21% of C# online submissions for Permutation Sequence.
 * Memory Usage: 22.6 MB, less than 78.20% of C# online submissions for Permutation Sequence.
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace PermutationSequence
{
    public class Solution
    {
        public string GetPermutation(int n, int k)
        {
            if (n == 1) return "1";
            char[] permutation = new char[n];
            var digits = new List<int>(n);
            int i;
            for (i = 1; i <= n; i++) digits.Add(i);
            i = 0;
            while (digits.Count != 0)
            {
                var fact = Factorial(digits.Count - 1);
                var ithMin = k % fact == 0 ? k / fact : k / fact + 1;
                var digit = digits[ithMin - 1];
                permutation[i] = Convert.ToChar(48 + digit);
                i += 1;
                digits.RemoveAt(ithMin - 1);
                k = k % fact == 0 ? fact : k % fact;
            }
            return new string(permutation);
        }

        int Factorial(int n)
        {
            return n switch
            {
                0 => 1,
                1 => 1,
                2 => 2,
                3 => 6,
                4 => 24,
                5 => 120,
                6 => 720,
                7 => 5040,
                8 => 40320,
                9 => 362800,
                _ => throw new NotImplementedException()
            };
        }
    }
}
