/*
 * File: 20.cs
 * Project: StackTests
 * Created Date: Wednesday, 26th August 2020 12:31:04 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using ValidParentheses;

namespace StackTests
{
    public class ValidParenthesesTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCaseEmptyString()
        {
            var s = "";
            var expected = true;
            var actual = sln.IsValid(s);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase1()
        {
            var s = "()";
            var expected = true;
            var actual = sln.IsValid(s);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var s = "()[]{}";
            var expected = true;
            var actual = sln.IsValid(s);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var s = "(]";
            var expected = false;
            var actual = sln.IsValid(s);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase4()
        {
            var s = "([)]";
            var expected = false;
            var actual = sln.IsValid(s);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase5()
        {
            var s = "{[]}";
            var expected = true;
            var actual = sln.IsValid(s);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase6()
        {
            var s = "((";
            var expected = false;
            var actual = sln.IsValid(s);
            Assert.Equal(expected, actual);
        }
    }
}