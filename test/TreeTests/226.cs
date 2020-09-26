/*
 * File: 226.cs
 * Project: TreeTests
 * Created Date: Wednesday, 16th September 2020 8:51:54 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TreeHelper;
using InvertBinaryTree;

namespace TreeTests
{
    public class InvertBinaryTreeTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(7)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(9)
                },
            };
            var expected = new TreeNode(4)
            {
                left = new TreeNode(7)
                {
                    left = new TreeNode(9),
                    right = new TreeNode(6)
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(1)
                },
            };
            var actual = sln.InvertTree(root);
            Assert.Equal(expected, actual);
        }
    }
}