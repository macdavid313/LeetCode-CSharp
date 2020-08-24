/*
 * File: 224.cs
 * Project: StackTests
 * Created Date: Monday, 24th August 2020 9:22:36 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using BasicCalculator;

namespace StackTests
{
    public class BasicCalculatorTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestSingleValue()
        {
            var s = " 1 ";
            var expected = 1;
            var actual = sln.Calculate(s);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase1()
        {
            var s = "1 + 1";
            var expected = 2;
            var actual = sln.Calculate(s);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var s = " 2-1 + 2 ";
            var expected = 3;
            var actual = sln.Calculate(s);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var s = "(1+(4+5+2)-3)+(6+8)";
            var expected = 23;
            var actual = sln.Calculate(s);
            Assert.Equal(expected, actual);
        }
    }
}