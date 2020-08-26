/*
 * File: 17.cs
 * Project: BacktrackingTests
 * Created Date: Wednesday, 26th August 2020 8:10:28 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using LetterCombinationsOfAPhoneNumber;

namespace BacktrackingTests
{
    public class LetterCombinationsOfAPhoneNumberTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestBase()
        {
            var digits = "23";
            var expected = new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
            var actual = sln.LetterCombinations(digits);
            Assert.Equal(expected, actual);
        }
    }
}