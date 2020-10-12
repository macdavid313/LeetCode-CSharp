/*
 * File: 91DecodeWays.cs
 * Project: DynamicProgramming
 * Created Date: Sunday, 11th October 2020 2:46:01 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 68 ms, faster than 98.02% of C# online submissions for Decode Ways.
 * Memory Usage: 23.3 MB, less than 9.16% of C# online submissions for Decode Ways.
 * -----
 * Last Modified: Monday, 12th October 2020 11:22:01 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


namespace DecodeWays
{
    public class Solution
    {
        public int NumDecodings(string s)
        {
            if (s.Length == 0 || s[0] == '0') return 0;

            var dp = new int[s.Length + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    if (s[i - 1] == '1' || s[i - 1] == '2') dp[i + 1] = dp[i - 1];
                    else return 0;
                }
                else if (s[i - 1] == '1' || (s[i - 1] == '2' && '1' <= s[i] && s[i] <= '6'))
                {
                    dp[i + 1] = dp[i] + dp[i - 1];
                }
                else dp[i + 1] = dp[i];
            }
            return dp[^1];
        }
    }
}