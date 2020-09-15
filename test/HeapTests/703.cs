/*
 * File: 703.cs
 * Project: HeapTests
 * Created Date: Tuesday, 15th September 2020 7:33:24 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using KthLargestElementInAStream;

namespace HeapTests
{
    public class KthLargestElementInAStreamTest
    {
        [Fact]
        public void TestCase1()
        {
            var nums = new int[] { 4, 5, 8, 2 };
            var sln = new KthLargest(3, nums);
            Assert.Equal(4, sln.Add(3));
            Assert.Equal(5, sln.Add(5));
            Assert.Equal(5, sln.Add(10));
            Assert.Equal(8, sln.Add(9));
            Assert.Equal(8, sln.Add(4));
        }

        [Fact]
        public void TestCase2()
        {
            var nums = new int[] { 0 };
            var sln = new KthLargest(2, nums);
            Assert.Equal(-1, sln.Add(-1));
            Assert.Equal(0, sln.Add(1));
            Assert.Equal(0, sln.Add(-2));
            Assert.Equal(0, sln.Add(-4));
            Assert.Equal(1, sln.Add(3));
        }
    }
}