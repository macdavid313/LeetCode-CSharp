/*
 * File: 71.cs
 * Project: StackTests
 * Created Date: Wednesday, 26th August 2020 7:04:04 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using SimplifyPath;

namespace StackTests
{
    public class SimplifyPathTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var path = "/home/";
            var expected = "/home";
            var actual = sln.SimplifyPath(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var path = "/../";
            var expected = "/";
            var actual = sln.SimplifyPath(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var path = "/home//foo/";
            var expected = "/home/foo";
            var actual = sln.SimplifyPath(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase4()
        {
            var path = "/a/./b/../../c/";
            var expected = "/c";
            var actual = sln.SimplifyPath(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase5()
        {
            var path = "/a/../../b/../c//.//";
            var expected = "/c";
            var actual = sln.SimplifyPath(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase6()
        {
            var path = "/a//b////c/d//././/..";
            var expected = "/a/b/c";
            var actual = sln.SimplifyPath(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase7()
        {
            var path = "/.";
            var expected = "/";
            var actual = sln.SimplifyPath(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase8()
        {
            var path = "/...";
            var expected = "/...";
            var actual = sln.SimplifyPath(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase9()
        {
            var path = "/..hidden";
            var expected = "/..hidden";
            var actual = sln.SimplifyPath(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase10()
        {
            var path = "/../";
            var expected = "/";
            var actual = sln.SimplifyPath(path);
            Assert.Equal(expected, actual);
        }
    }
}