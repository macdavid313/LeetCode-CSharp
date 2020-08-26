/*
 * File: 42.cs
 * Project: StackTests
 * Created Date: Wednesday, 26th August 2020 9:52:41 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TrappingRainWater;

namespace StackTests
{
    public class TrappingRainWaterTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var expected = 6;
            var actual = sln.Trap(height);
            Assert.Equal(expected, actual);
        }
    }
}