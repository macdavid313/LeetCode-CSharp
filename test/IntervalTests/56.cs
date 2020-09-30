/*
 * File: 56.cs
 * Project: IntervalTests
 * Created Date: Wednesday, 30th September 2020 9:53:31 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Wednesday, 30th September 2020 10:26:58 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using MergeIntervals;

namespace IntervalTests
{
    public class MergeIntervalsTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var intervals = new int[][]
            {
                new int[] { 1, 3 },
                new int[] { 2, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 },
            };
            var expected = new int[][]
            {
                new int[] { 1, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 },
            };
            var actual = sln.Merge(intervals);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var intervals = new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 4, 5 },
            };
            var expected = new int[][]
            {
                new int[] { 1, 5 },
            };
            var actual = sln.Merge(intervals);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var intervals = new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 1, 10 },
            };
            var expected = new int[][]
            {
                new int[] { 1, 10 },
            };
            var actual = sln.Merge(intervals);
            Assert.Equal(expected, actual);
        }
    }
}