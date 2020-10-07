/*
 * File: 62UniquePaths.cs
 * Project: DynamicProgramming
 * Created Date: Thursday, 8th October 2020 8:59:25 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 36 ms, faster than 94.14% of C# online submissions for Unique Paths.
 * Memory Usage: 15.2 MB, less than 19.41% of C# online submissions for Unique Paths.
 * -----
 * Last Modified: Thursday, 8th October 2020 9:30:09 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


namespace UniquePaths
{
    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1) return 1;

            var dp = new int[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0) dp[i, j] = 1;
                    else dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                }
            }
            return dp[m - 1, n - 1];
        }
    }

    /* time limt exceeded
    public class Solution
    {
        static int M;
        static int N;

        public int UniquePaths(int m, int n)
        {
            M = m;
            N = n;
            var count = 0;
            Backtrack((0, 0), ref count);
            return count;
        }

        void Backtrack(ValueTuple<int, int> step, ref int count)
        {
            if (step.Item1 == N - 1 && step.Item2 == M - 1)
            {
                count += 1;
                return;
            }
            foreach (var next in NextStep(step))
            {
                Backtrack(next, ref count);
            }
        }

        IEnumerable<ValueTuple<int, int>> NextStep(ValueTuple<int, int> step)
        {
            var (i, j) = step;
            if (j + 1 < M) yield return (i, j + 1);
            if (i + 1 < N) yield return (i + 1, j);
        }
    } */
}