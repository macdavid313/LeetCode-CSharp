/*
 * File: 46Permutations.cs
 * Project: Backtracking
 * Created Date: Thursday, 27th August 2020 2:20:59 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 236 ms, faster than 98.01% of C# online submissions for Permutations.
 * Memory Usage: 31.2 MB, less than 91.59% of C# online submissions for Permutations.
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace Permutations
{
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            int totalLen = Factorial(nums.Length);
            var permutations = new List<IList<int>>(totalLen);
            Span<int> numsCopy = stackalloc int[nums.Length];
            nums.CopyTo(numsCopy);
            Backtrack(nums.Length, permutations, numsCopy, 0);
            return permutations;
        }

        void Backtrack(int n, List<IList<int>> permutations, Span<int> permutation, int offset)
        {
            if (offset == n)
            {
                permutations.Add(permutation.ToArray());
                return;
            }
            for (var i = offset; i < n; i++)
            {
                int tmp;
                // swap
                if (i != offset)
                {
                    tmp = permutation[offset];
                    permutation[offset] = permutation[i];
                    permutation[i] = tmp;
                }
                // backtrack
                Backtrack(n, permutations, permutation, offset + 1);
                // undo swap
                if (i != offset)
                {
                    tmp = permutation[offset];
                    permutation[offset] = permutation[i];
                    permutation[i] = tmp;
                }
            }
        }

        /* Heap's algorithm, https://en.wikipedia.org/wiki/Heap%27s_algorithm
        * Runtime: 240 ms, faster than 92.63% of C# online submissions for Permutations.
        * Memory Usage: 31 MB, less than 99.11% of C# online submissions for Permutations.
        public IList<IList<int>> Permute(int[] nums)
        {
            int totalLen = Factorial(nums.Length);
            var permutations = new List<IList<int>>(totalLen);
            Span<int> numsCopy = stackalloc int[nums.Length];
            nums.CopyTo(numsCopy);
            Permute(nums, nums.Length, permutations);
            return permutations;
        }

        void Permute(Span<int> nums, int k, List<IList<int>> permutations)
        {
            if (k == 1)
            {
                permutations.Add(nums.ToArray());
                return;
            }
            Permute(nums, k - 1, permutations);
            for (var i = 0; i < k - 1; i++)
            {
                if (k % 2 == 0)
                {
                    Swap(nums, i, k - 1);
                }
                else
                {
                    Swap(nums, 0, k - 1);
                }
                Permute(nums, k - 1, permutations);
            }
        }

        void Swap(Span<int> nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        } */

        static int Factorial(int n)
        {
            if (n < 0)
                throw new InvalidOperationException();
            if (n <= 10)
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
                    _ => 3628000
                };
            }
            int res = 3628000;
            while (n != 10)
            {
                res *= n;
                n -= 1;
            }
            return res;
        }
    }
}