/*
 * File: 91.cs
 * Project: DynamicProgrammingTests
 * Created Date: Monday, 12th October 2020 11:18:38 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Monday, 12th October 2020 11:19:42 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using DecodeWays;

namespace DynamicProgrammingTests
{
    public class DecodeWaysTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var s = "27";
            var expected = 1;
            var actual = sln.NumDecodings(s);
            Assert.Equal(expected, actual);
        }
    }
}