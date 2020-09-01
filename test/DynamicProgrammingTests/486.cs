/*
 * File: 486.cs
 * Project: DynamicProgrammingTests
 * Created Date: Tuesday, 1st September 2020 1:32:36 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using PredictTheWinner;

namespace DynamicProgrammingTests
{
    public class PredictTheWinnerTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var nums = new int[] { 1, 5, 2 };
            var expected = false;
            var actual = sln.PredictTheWinner(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var nums = new int[] { 1, 5, 233, 7 };
            var expected = true;
            var actual = sln.PredictTheWinner(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var nums = new int[] { 1000, 999, 999, 1000, 555, 400 };
            var expected = true;
            var actual = sln.PredictTheWinner(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase4()
        {
            var nums = new int[] { 1921045, 6, 5132440, 5, 3, 6610604, 7, 8650002, 6337645, 3740419, 5242495, 3729694, 1, 4293537, 3, 2, 5, 9278, 4 };
            var expected = false;
            var actual = sln.PredictTheWinner(nums);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase5()
        {
            var nums = new int[] { 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000, 10000000 };
            var expected = true;
            var actual = sln.PredictTheWinner(nums);
            Assert.Equal(expected, actual);
        }
    }
}