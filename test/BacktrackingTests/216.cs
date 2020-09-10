/*
 * File: 216.cs
 * Project: BacktrackingTests
 * Created Date: Friday, 11th September 2020 8:14:21 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using CombinationSumIII;

namespace BacktrackingTests
{
    public class CombinationSumIIITest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var k = 3;
            var n = 7;
            var expected = new int[][] { new int[] { 1, 2, 4 } };
            var actual = sln.CombinationSum3(k, n);
            foreach (var item in actual)
            {
                Assert.Contains(item, expected);
            }
        }

        [Fact]
        public void TestCase2()
        {
            var k = 3;
            var n = 9;
            var expected = new int[][]
            {
                new int[] { 1, 2, 6 } ,
                new int[] { 1, 3, 5 },
                new int[] { 2, 3, 4 }
            };
            var actual = sln.CombinationSum3(k, n);
            foreach (var item in actual)
            {
                Assert.Contains(item, expected);
            }
        }
    }
}