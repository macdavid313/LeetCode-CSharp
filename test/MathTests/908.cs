/*
 * File: 908.cs
 * Project: MiscTests
 * Created Date: Sunday, 23rd August 2020 3:40:19 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */

using System;
using Xunit;
using SmallestRangeI;

namespace MathTests
{
    public class SmallestRangeITest
    {
        readonly Solution sln = new Solution();
        readonly Random random = new Random();

        [Fact]
        public void TestSingleElement()
        {
            var A = new int[] { 1 };
            var K = random.Next(0, 10000 + 1);
            var diff = sln.SmallestRangeI(A, K);
            Assert.Equal(0, diff);
        }

        [Fact]
        public void TestKisZero()
        {
            var A = new int[] { 1, 2, 3, 4, 5 };
            var K = 0;
            var diff = sln.SmallestRangeI(A, K);
            Assert.Equal(4, diff);
        }

        [Fact]
        public void TestBase()
        {
            var A1 = new int[] { 0, 10 };
            var K1 = 2;
            var A2 = new int[] { 1, 3, 6 };
            var K2 = 3;
            var diff1 = sln.SmallestRangeI(A1, K1);
            var diff2 = sln.SmallestRangeI(A2, K2);
            Assert.Equal(6, diff1);
            Assert.Equal(0, diff2);
        }
    }
}