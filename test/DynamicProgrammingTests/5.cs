/*
 * File: 5.cs
 * Project: DynamicProgrammingTests
 * Created Date: Thursday, 27th August 2020 11:06:52 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using LongestPalindromicSubstring;

namespace DynamicProgrammingTests
{
    public class LongestPalindromicSubstringTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var s = "babad";
            var expected = "bab";
            var actual = sln.LongestPalindrome(s);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var s = "cbbd";
            var expected = "bb";
            var actual = sln.LongestPalindrome(s);
            Assert.Equal(expected, actual);
        }
    }
}