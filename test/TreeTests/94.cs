/*
 * File: 94.cs
 * Project: TreeTests
 * Created Date: Monday, 14th September 2020 8:39:28 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TreeHelper;
using BinaryTreeInorderTraversal;

namespace TreeTests
{
    public class BinaryTreeInorderTraversalTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    left = new TreeNode(3)
                }
            };
            var expected = new int[] { 1, 3, 2 };
            var actual = sln.InorderTraversal(root);
            Assert.Equal(expected, actual);
        }
    }
}