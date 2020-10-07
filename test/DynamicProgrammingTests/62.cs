/*
 * File: 62.cs
 * Project: DynamicProgrammingTests
 * Created Date: Thursday, 8th October 2020 9:00:16 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Thursday, 8th October 2020 9:27:46 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using UniquePaths;

namespace DynamicProgrammingTests
{
    public class UniquePathsTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var expected = 28;
            var actual = sln.UniquePaths(7, 3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var expected = 167960;
            var actual = sln.UniquePaths(10, 12);
            Assert.Equal(expected, actual);
        }
    }
}