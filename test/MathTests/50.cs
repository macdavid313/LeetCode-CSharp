/*
 * File: 50.cs
 * Project: MathTests
 * Created Date: Monday, 24th August 2020 7:47:49 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */

using System;
using Xunit;
using MyPow;

namespace MathTests
{
    public class MyPowTest
    {
        readonly Solution sln = new Solution();
        readonly Random random = new Random();

        [Fact]
        public void TestNIsZero()
        {
            var x = random.NextDouble();
            var n = 0;
            var expected = 1.0;
            var actual = sln.MyPow(x, n);
            Assert.Equal(expected, actual, 5);
        }

        [Fact]
        public void TestNIsOne()
        {
            var x = random.NextDouble();
            var n = 1;
            var expected = x;
            var actual = sln.MyPow(x, n);
            Assert.Equal(expected, actual, 5);
        }

        [Fact]
        public void TestBase()
        {
            var xs = new double[] { 2.0, 2.1, 2.0, 8.84372 };
            var ns = new int[] { 10, 3, -2, -5 };
            var expects = new double[] { 1024.0, 9.26100, 0.2500, 2E-5 };
            for (var i = 0; i < xs.Length; i++)
            {
                var x = xs[i];
                var n = ns[i];
                var expected = expects[i];
                var actual = sln.MyPow(x, n);
                Assert.Equal(expected, actual, 5);
            }
        }
    }
}