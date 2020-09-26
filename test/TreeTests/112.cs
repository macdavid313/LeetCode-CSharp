/*
 * File: 112.cs
 * Project: TreeTests
 * Created Date: Saturday, 26th September 2020 7:28:35 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Saturday, 26th September 2020 10:16:59 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TreeHelper;
using PathSum;

namespace TreeTests
{
    public class PathSumTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        right = new TreeNode(1)
                    }
                }
            };
            var sum = 22;
            var expected = true;
            var actual = sln.HasPathSum(root, sum);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var root = new TreeNode(-2)
            {
                right = new TreeNode(-3)
            };
            var sum = -5;
            var expected = true;
            var actual = sln.HasPathSum(root, sum);
            Assert.Equal(expected, actual);
        }
    }
}