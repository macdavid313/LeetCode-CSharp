/*
 * File: 399.cs
 * Project: UnionFindTests
 * Created Date: Sunday, 23rd August 2020 5:27:23 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using EvaluateDivision;

namespace UnionFindTests
{
    public class EvaluateDivisionTets
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestBase()
        {
            var equations = new string[][] { new string[] { "a", "b" }, new string[] { "b", "c" } };
            var values = new double[] { 2.0, 3.0 };
            var queries = new string[][] {
                new string[] { "a", "c" },
                new string[] { "b", "a" },
                new string[] { "a", "e" },
                new string[] { "a", "a" },
                new string[] {"x", "x"}
            };
            var expectedValues = new double[] { 6.0, 0.5, -1.0, 1.0, -1.0 };
            var actualValues = sln.CalcEquation(equations, values, queries);
            Assert.Equal(expectedValues, actualValues);
        }
    }
}