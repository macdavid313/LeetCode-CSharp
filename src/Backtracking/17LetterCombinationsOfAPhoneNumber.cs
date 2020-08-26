/*
 * File: 17LetterCombinationsOfAPhoneNumber.cs
 * Project: Backtracking
 * Created Date: Wednesday, 26th August 2020 8:09:27 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 240 ms, faster than 82.43% of C# online submissions for Letter Combinations of a Phone Number.
 * Memory Usage: 31.2 MB, less than 95.92% of C# online submissions for Letter Combinations of a Phone Number.
 * Copyright (c) David Gu 2020
 */


using System.Text;
using System.Collections.Generic;

namespace LetterCombinationsOfAPhoneNumber
{
    public class Solution
    {
        Dictionary<char, char[]> PhoneMap { get; }

        public Solution()
        {
            PhoneMap = new Dictionary<char, char[]>(8)
            {
                { '2', new char[] { 'a', 'b', 'c' } },
                { '3', new char[] { 'd', 'e', 'f' } },
                { '4', new char[] { 'g', 'h', 'i' } },
                { '5', new char[] { 'j', 'k', 'l' } },
                { '6', new char[] { 'm', 'n', 'o' } },
                { '7', new char[] { 'p', 'q', 'r', 's' } },
                { '8', new char[] { 't', 'u', 'v' } },
                { '9', new char[] { 'w', 'x', 'y', 'z' } }
            };
        }

        public IList<string> LetterCombinations(string digits)
        {
            var sb = new StringBuilder(digits.Length);
            var combinations = new List<string>();

            if (digits.Length == 0) return combinations;
            Backtrack(combinations, digits, 0, sb);
            return combinations;
        }

        void Backtrack(List<string> combinations, string digits, int index, StringBuilder sb)
        {
            if (index == digits.Length)
            {
                combinations.Add(sb.ToString());
            }
            else
            {
                char digit = digits[index];
                foreach (var letter in PhoneMap[digit])
                {
                    sb.Append(letter);
                    Backtrack(combinations, digits, index + 1, sb);
                    sb.Remove(index, 1);
                }
            }
        }
    }
}