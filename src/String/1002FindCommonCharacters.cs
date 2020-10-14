/*
 * File: 1002FindCommonCharacters.cs
 * Project: String
 * Created Date: Wednesday, 14th October 2020 2:16:10 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 232 ms, faster than 100.00% of C# online submissions for Find Common Characters.
 * Memory Usage: 32.9 MB, less than 29.10% of C# online submissions for Find Common Characters.
 * -----
 * Last Modified: Wednesday, 14th October 2020 2:37:42 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace FindCommonCharacters
{
    public class Solution
    {
        const int _offset = 97;

        public IList<string> CommonChars(string[] A)
        {
            if (A.Length == 0) return Array.Empty<string>();
            Span<int> lookup = stackalloc int[26];
            Span<int> freq = stackalloc int[26];
            CountFrequency(A[0], lookup);
            foreach (var s in A[1..])
            {
                freq.Fill(0);
                CountFrequency(s, freq);
                for (var i = 0; i < 26; i++)
                {
                    if (freq[i] == 0) lookup[i] = 0;
                    else if (freq[i] < lookup[i]) lookup[i] = freq[i];
                }
            }
            var ans = new List<string>();
            for (var i = 0; i < 26; i++)
            {
                var s = Convert.ToChar(_offset + i).ToString();
                var count = lookup[i];
                while (count != 0)
                {
                    ans.Add(s);
                    count -= 1;
                }
            }
            return ans;
        }

        void CountFrequency(string s, Span<int> span)
        {
            foreach (var c in s)
            {
                var radix = Convert.ToInt32(c) - _offset;
                span[radix] += 1;
            }
        }
    }
}