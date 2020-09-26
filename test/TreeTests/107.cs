/*
 * File: 107.cs
 * Project: TreeTests
 * Created Date: Sunday, 6th September 2020 9:34:28 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TreeHelper;
using BinaryTreeLevelOrderTraversalII;

namespace TreeTests
{
    public class BinaryTreeLevelOrderTraversalIITest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20, new TreeNode(15), new TreeNode(7))
            };
            var expected = new int[3][]
            {
                new int[] { 15, 7 },
                new int[] { 9, 20 },
                new int[] { 3 }
            };
            var actual = sln.LevelOrderBottom(root);
            Assert.Equal(expected, actual);
        }
    }
}