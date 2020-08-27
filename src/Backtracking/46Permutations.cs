/*
 * File: 46Permutations.cs
 * Project: Backtracking
 * Created Date: Thursday, 27th August 2020 2:20:59 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 240 ms, faster than 94.14% of C# online submissions for Permutations.
 * Memory Usage: 31.2 MB, less than 90.93% of C# online submissions for Permutations.
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
            var stack = new Stack<int>(nums.Length);
            var totalLen = Factorial(nums.Length);
            IList<IList<int>> permutations = new List<IList<int>>(totalLen);
            var indexCache = new HashSet<int>(nums.Length);
            for (var i = 0; i < nums.Length; i++)
            {
                stack.Push(nums[i]);
                for (var j = 0; j < nums.Length; j++)
                    indexCache.Add(j);
                indexCache.Remove(i);
                Backtracking(permutations, stack, nums, indexCache);
                stack.Pop();
            }
            return permutations;
        }

        int Factorial(int n)
        {
            if (n < 0)
                throw new InvalidOperationException();
            int res = 1;
            while (n != 0)
            {
                res *= n;
                n -= 1;
            }
            return res;
        }

        void Backtracking(IList<IList<int>> permutations, Stack<int> permutation, int[] nums, HashSet<int> otherIdx)
        {
            if (otherIdx.Count == 0)
            {
                permutations.Add(permutation.ToArray());
                return;
            }
            var otherIdxArray = new int[otherIdx.Count];
            otherIdx.CopyTo(otherIdxArray);
            foreach (var idx in otherIdxArray)
            {
                permutation.Push(nums[idx]);
                otherIdx.Remove(idx);
                Backtracking(permutations, permutation, nums, otherIdx);
                otherIdx.Add(idx);
                permutation.Pop();
            }
        }
    }
}