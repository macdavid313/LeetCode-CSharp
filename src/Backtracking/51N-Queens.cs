/*
 * File: 51N-Queens.cs
 * Project: Backtracking
 * Created Date: Thursday, 3rd September 2020 8:18:02 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 248 ms, faster than 84.43% of C# online submissions for N-Queens.
 * Memory Usage: 32.9 MB, less than 74.59% of C# online submissions for N-Queens.
 * Copyright (c) David Gu 2020
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace NQueens
{
    public class Solution
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
            if (n == 1) return new string[1][] { new string[1] { "Q" } };
            if (n == 2 || n == 3) return Array.Empty<string[]>();

            var allSolutions = new List<string[]>();
            var permutation = new int[n];
            /* enumerate columns */
            for (var i = 0; i < n; i++)
            {
                Array.Fill(permutation, -1);
                permutation[0] = i;
                Solve(allSolutions, permutation, n, 1);
            }
            return allSolutions.ToArray();
        }

        void Solve(List<string[]> allSolutions, int[] permutation, int n, int row)
        {
            /* a solution found */
            if (row == n)
            {
                allSolutions.Add(SolutionToStringList(permutation));
                return;
            }
            /* enumerate columns */
            for (var i = 0; i < n; i++)
            {
                permutation[row] = i;
                if (NoConflict(permutation, row))
                {
                    Solve(allSolutions, permutation, n, row + 1);
                }
                else
                {
                    permutation[row] = -1;
                }
            }
        }

        static bool NoConflict(int[] permutation, int row)
        {
            for (var i = 0; i < row; i++)
            {
                if (permutation[i] == permutation[row])
                    return false;
                if (row - i == Math.Abs(permutation[row] - permutation[i]))
                    return false;
            }
            return true;
        }

        static string[] SolutionToStringList(int[] permutation)
        {
            var n = permutation.Length;
            var res = new string[n];
            for (var i = 0; i < n; i++)
            {
                var chars = Enumerable.Repeat('.', n).ToArray();
                chars[permutation[i]] = 'Q';
                res[i] = new string(chars);
            }
            return res;
        }
    }
}