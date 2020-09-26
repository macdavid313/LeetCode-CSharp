/*
 * File: 637.cs
 * Project: TreeTests
 * Created Date: Saturday, 12th September 2020 2:09:50 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TreeHelper;
using AverageOfLevelsInBinaryTree;

namespace TreeTests
{
    public class AverageOfLevelsInBinaryTreeTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };
            var expected = new double[] { 3, 14.5, 11 };
            var actual = sln.AverageOfLevels(root);
            Assert.Equal(expected, actual);
        }
    }
}