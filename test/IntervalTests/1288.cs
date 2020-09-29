/*
 * File: 1288.cs
 * Project: IntervalTests
 * Created Date: Wednesday, 30th September 2020 7:54:30 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Wednesday, 30th September 2020 7:56:17 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using RemoveCoveredIntervals;

namespace IntervalTests
{
    public class RemoveCoveredIntervalsTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var intervals = new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 3, 6 },
                new int[] { 2, 8 }
            };
            var expected = 2;
            var actual = sln.RemoveCoveredIntervals(intervals);
            Assert.Equal(expected, actual);
        }
    }
}