/*
 * File: 5LongestPalindromicSubstring.cs
 * Project: DynamicProgramming
 * Created Date: Thursday, 27th August 2020 11:01:39 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 224 ms, faster than 34.54% of C# online submissions for Longest Palindromic Substring.
 * Memory Usage: 41.6 MB, less than 7.89% of C# online submissions for Longest Palindromic Substring.
 * Copyright (c) David Gu 2020
 */


using System;

namespace LongestPalindromicSubstring
{
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            if (s.Length <= 1) return s;

            var dp = new bool[s.Length, s.Length];
            string res = "";
            for (var l = 0; l < s.Length; l++)
            {
                for (var i = 0; i < s.Length; i++)
                {
                    var j = i + l;
                    if (j == s.Length) break;
                    dp[i, j] = l switch
                    {
                        0 => true,
                        1 => s[i] == s[j],
                        _ => dp[i + 1, j - 1] && s[i] == s[j]
                    };
                    if (dp[i, j] && l + 1 > res.Length)
                        res = s[i..(j + 1)];
                }
            }
            return res;
        }
    }
}