/*
 * File: 986.cs
 * Project: IntervalTests
 * Created Date: Wednesday, 30th September 2020 11:29:20 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Wednesday, 30th September 2020 11:32:53 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using IntervalListIntersections;

namespace IntervalTests
{
    public class IntervalListIntersectionsTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var A = new int[][]
            {
                new int[] { 0, 2 },
                new int[] { 5, 10 },
                new int[] { 13, 23 },
                new int[] { 24, 25 }
            };
            var B = new int[][]
            {
                new int[] { 1, 5 },
                new int[] { 8, 12 },
                new int[] { 15, 24 },
                new int[] { 25, 26 }
            };
            var expected = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 5, 5 },
                new int[] { 8, 10 },
                new int[] { 15, 23 },
                new int[] { 24, 24 },
                new int[] { 25, 25 }
            };
            var actual = sln.IntervalIntersection(A, B);
            Assert.Equal(expected, actual);
        }
    }
}