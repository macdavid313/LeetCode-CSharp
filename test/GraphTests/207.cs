/*
 * File: 207.cs
 * Project: GraphTests
 * Created Date: Friday, 18th September 2020 9:21:03 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Friday, 18th September 2020 9:23:28 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using CourseSchedule;

namespace GraphTests
{
    public class CourseScheduleTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var numCourses = 2;
            var prerequisites = new int[][] { new int[] { 1, 0 } };
            var expected = true;
            var actual = sln.CanFinish(numCourses, prerequisites);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var numCourses = 2;
            var prerequisites = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            var expected = false;
            var actual = sln.CanFinish(numCourses, prerequisites);
            Assert.Equal(expected, actual);
        }
    }
}