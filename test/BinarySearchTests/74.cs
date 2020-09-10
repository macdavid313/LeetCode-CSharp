/*
 * File: 74.cs
 * Project: BinarySearchTests
 * Created Date: Friday, 11th September 2020 8:46:14 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using SearchA2DMatrix;

namespace BinarySearchTests
{
    public class SearchA2DMatrixTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var matrix = new int[][]
            {
                new int[] {1, 3, 5, 7},
                new int[] {10, 11, 16, 20},
                new int[] {23, 30, 34, 50}
            };
            var target = 3;
            var expected = true;
            var actual = sln.SearchMatrix(matrix, target);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var matrix = new int[][]
            {
                new int[] {1, 3, 5, 7},
                new int[] {10, 11, 16, 20},
                new int[] {23, 30, 34, 50}
            };
            var target = 6;
            var expected = false;
            var actual = sln.SearchMatrix(matrix, target);
            Assert.Equal(expected, actual);
        }
    }
}