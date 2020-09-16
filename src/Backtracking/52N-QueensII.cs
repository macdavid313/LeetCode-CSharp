/*
 * File: 52N-QueensII.cs
 * Project: Backtracking
 * Created Date: Sunday, 6th September 2020 10:01:46 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 44 ms, faster than 75.31% of C# online submissions for N-Queens II.
 * Memory Usage: 14.5 MB, less than 77.78% of C# online submissions for N-Queens II.
 * Copyright (c) David Gu 2020
 */


using System;

namespace NQueensII
{
    public class Solution
    {
        public int TotalNQueens(int n)
        {
            if (n == 0 || n == 1) return 1;
            var count = 0;
            Span<int> permutation = stackalloc int[n];
            for (var i = 0; i < n; i++)
            {
                permutation.Fill(-1);
                permutation[0] = i;
                Solve(ref count, permutation, 1, n);
            }
            return count;
        }

        void Solve(ref int count, Span<int> permutation, int row, int n)
        {
            if (row == n)
            {
                count += 1;
                return;
            }
            for (var i = 0; i < n; i++)
            {
                if (NoConflict(permutation, row, i))
                {
                    permutation[row] = i;
                    Solve(ref count, permutation, row + 1, n);
                }
            }
        }

        static bool NoConflict(Span<int> permutation, int row, int col)
        {
            for (var i = 0; i < row; i++)
            {
                if (permutation[i] == col) return false;
                if (row - i == Math.Abs(permutation[i] - col)) return false;
            }
            return true;
        }
    }
}