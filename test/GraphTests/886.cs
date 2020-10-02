/*
 * File: 886.cs
 * Project: GraphTests
 * Created Date: Friday, 2nd October 2020 12:07:48 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Friday, 2nd October 2020 12:10:29 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using PossibleBipartition;

namespace GraphTests
{
    public class PossibleBipartitionTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var N = 4;
            var dislikes = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 1, 3 },
                new int[] { 2, 4 }
            };
            var expected = true;
            var actual = sln.PossibleBipartition(N, dislikes);
            Assert.Equal(expected, actual);
        }
    }
}