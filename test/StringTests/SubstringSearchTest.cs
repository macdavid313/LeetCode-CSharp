/*
 * File: SubstringSearchTest.cs
 * Project: StringTests
 * Created Date: Saturday, 3rd October 2020 6:14:53 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Saturday, 3rd October 2020 8:23:25 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using System;
using Substring.Search;

namespace SubstringSearchTest
{
    public class SubstringSearchTest
    {
        readonly static Random _random = new Random();

        static void GetSampleString(int len, out string s, out string pat)
        {
            var chars = new char[len];
            for (var i = 0; i < len; i++)
            {
                var c = Convert.ToChar(_random.Next(65, 91));
                chars[i] = c;
            }
            var start = _random.Next(0, len / 2);
            var end = start + _random.Next(0, len / 4) + 1;
            s = new string(chars);
            pat = s[start..end];
        }

        [Fact]
        public void TestBrutal1()
        {
            var s = "ACCCCCAB";
            var pat = "AB";
            var expected = 6;
            var actual = SubstringSearch.Brutal1(s, pat);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBrutal1Random()
        {
            GetSampleString(10000, out string s, out string pat);
            var expected = s.IndexOf(pat);
            var actual = SubstringSearch.Brutal1(s, pat);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBrutal2()
        {
            var s = "ACCCCCAB";
            var pat = "AB";
            var expected = 6;
            var actual = SubstringSearch.Brutal2(s, pat);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBrutal2Random()
        {
            GetSampleString(10000, out string s, out string pat);
            var expected = s.IndexOf(pat);
            var actual = SubstringSearch.Brutal2(s, pat);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestKMP()
        {
            var s = "ACCCCCAB";
            var pat = "AB";
            var expected = 6;
            var actual = SubstringSearch.KMP(s, pat);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestKMPRandom()
        {
            GetSampleString(10000, out string s, out string pat);
            var expected = s.IndexOf(pat);
            var actual = SubstringSearch.KMP(s, pat);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBoyerMoore()
        {
            var s = "ACCCCCAB";
            var pat = "AB";
            var expected = 6;
            var actual = SubstringSearch.BoyerMoore(s, pat);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBoyerMooreRandom()
        {
            GetSampleString(10000, out string s, out string pat);
            var expected = s.IndexOf(pat);
            var actual = SubstringSearch.BoyerMoore(s, pat);
            Assert.Equal(expected, actual);
        }
    }
}