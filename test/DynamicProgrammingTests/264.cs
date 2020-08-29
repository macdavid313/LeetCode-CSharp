/*
 * File: 264.cs
 * Project: DynamicProgrammingTests
 * Created Date: Friday, 28th August 2020 9:29:42 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using UglyNumberII;

namespace MathTests
{
    public class UglyNumberIITest
    {
        readonly static Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var n = 1;
            var expected = 1;
            var actual = sln.NthUglyNumber(n);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var n = 5;
            var expected = 5;
            var actual = sln.NthUglyNumber(n);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var n = 10;
            var expected = 12;
            var actual = sln.NthUglyNumber(n);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase4()
        {
            var n = 435;
            var expected = 468750;
            var actual = sln.NthUglyNumber(n);
            Assert.Equal(expected, actual);
        }
    }
}