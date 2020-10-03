/*
 * File: SubstringSearch.cs
 * Project: String
 * Created Date: Saturday, 3rd October 2020 6:09:01 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Saturday, 3rd October 2020 8:45:41 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;

namespace Substring.Search
{
    public class SubstringSearch
    {
        const int _radix = 26;

        public static int Brutal1(string s, string pat)
        {
            s = s ?? throw new ArgumentNullException(nameof(s));
            pat = pat ?? throw new ArgumentNullException(nameof(pat));
            if (string.IsNullOrEmpty(pat)) return 0;
            if (string.IsNullOrEmpty(s)) return -1;

            for (var i = 0; i <= s.Length - pat.Length; i++)
            {
                if (s[i] == pat[0])
                {
                    var j = 1;
                    while (j < pat.Length && s[i + j] == pat[j]) j += 1;
                    if (j == pat.Length) return i;
                }
            }
            return -1;
        }

        public static int Brutal2(string s, string pat)
        {
            s = s ?? throw new ArgumentNullException(nameof(s));
            pat = pat ?? throw new ArgumentNullException(nameof(pat));
            if (string.IsNullOrEmpty(pat)) return 0;
            if (string.IsNullOrEmpty(s)) return -1;

            var (i, j) = (0, 0);
            while (i < s.Length && j < pat.Length)
            {
                if (s[i] == pat[j]) j += 1;
                else
                {
                    i -= j;
                    j = 0;
                }
                i += 1;
            }
            return j == pat.Length ? i - pat.Length : -1;
        }

        public static int KMP(string s, string pat)
        {
            s = s ?? throw new ArgumentNullException(nameof(s));
            pat = pat ?? throw new ArgumentNullException(nameof(pat));
            if (string.IsNullOrEmpty(pat)) return 0;
            if (string.IsNullOrEmpty(s)) return -1;

            // construct dfa
            var dfa = new int[_radix, pat.Length];
            dfa[ToRadix(pat[0]), 0] = 1;
            var i = 1;
            for (var x = 0; i < pat.Length; i++)
            {
                var r = ToRadix(pat[i]);
                // copy mismatch case
                for (var c = 0; c < _radix; c++) dfa[c, i] = dfa[c, x];
                // set match case
                dfa[r, i] = i + 1;
                // set restart case
                x = dfa[r, x];
            }

            // search
            i = 0;
            var j = 0;
            while (i < s.Length && j < pat.Length)
            {
                var r = ToRadix(s[i]);
                j = dfa[r, j];
                i += 1;
            }
            return j == pat.Length ? i - j : -1;
        }

        public static int BoyerMoore(string s, string pat)
        {
            s = s ?? throw new ArgumentNullException(nameof(s));
            pat = pat ?? throw new ArgumentNullException(nameof(pat));
            if (string.IsNullOrEmpty(pat)) return 0;
            if (string.IsNullOrEmpty(s)) return -1;

            // construct skip table
            Span<int> right = stackalloc int[_radix];
            right.Fill(-1);
            for (var i = 0; i < pat.Length; i++) right[ToRadix(pat[i])] = i;

            // search
            var skip = 0;
            for (var i = 0; i <= s.Length - pat.Length; i += skip)
            {
                skip = 0;
                for (var j = pat.Length - 1; j >= 0; j--)
                {
                    if (s[i + j] != pat[j])
                    {
                        skip = j - right[ToRadix(s[i + j])];
                        if (skip < 1) skip = 1;
                        break;
                    }
                }
                if (skip == 0) return i;
            }
            return -1;
        }

        static int ToRadix(char c) => Convert.ToInt32(c) - Convert.ToInt32('A');
    }
}