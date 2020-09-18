/*
 * File: 210.cs
 * Project: GraphTests
 * Created Date: Friday, 18th September 2020 8:42:05 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Friday, 18th September 2020 9:01:39 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using CourseScheduleII;
using System;

namespace GraphTests
{
    public class CourseScheduleIITest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var numCourses = 2;
            var prerequisites = new int[][] { new int[] { 1, 0 } };
            var expected = new int[] { 0, 1 };
            var actual = sln.FindOrder(numCourses, prerequisites);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var numCourses = 4;
            var prerequisites = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 2, 0 },
                new int[] { 3, 1 },
                new int[] { 3, 2 },
            };
            var expected = new int[] { 0, 2, 1, 3 };
            var actual = sln.FindOrder(numCourses, prerequisites);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var numCourses = 3;
            var prerequisites = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 2, 1 },
                new int[] { 0, 2 },
            };
            var expected = Array.Empty<int>();
            var actual = sln.FindOrder(numCourses, prerequisites);
            Assert.Equal(expected, actual);
        }
    }
}