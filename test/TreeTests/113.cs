/*
 * File: 113.cs
 * Project: TreeTests
 * Created Date: Saturday, 26th September 2020 10:23:54 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Saturday, 26th September 2020 10:42:41 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using PathSumII;
using TreeHelper;

namespace TreeTests
{
    public class PathSumIITest
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
                        left = new TreeNode(5),
                        right = new TreeNode(1)
                    }
                }
            };
            var sum = 22;
            var expected = new int[][]
            {
                new int[] { 5, 4, 11, 2 },
                new int[] { 5, 8, 4, 5 }
            };
            var actual = sln.PathSum(root, sum);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
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
                    left = new TreeNode(13)
                    {
                        left = new TreeNode(-4)
                    },
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(5),
                        right = new TreeNode(1)
                    }
                }
            };
            var sum = 22;
            var expected = new int[][]
            {
                new int[] { 5, 4, 11, 2 },
                new int[] { 5, 8, 13, -4 },
                new int[] { 5, 8, 4, 5 }
            };
            var actual = sln.PathSum(root, sum);
            Assert.Equal(expected, actual);
        }
    }
}