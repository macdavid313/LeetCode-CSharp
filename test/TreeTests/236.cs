/*
 * File: 236.cs
 * Project: TreeTests
 * Created Date: Sunday, 27th September 2020 8:24:14 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Sunday, 27th September 2020 8:28:23 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TreeHelper;
using LowestCommentAncestorOfABinaryTree;

namespace TreeTests
{
    public class LowestCommentAncestorOfABinaryTreeTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(4)
                    }
                },
                right = new TreeNode(1)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(8)
                }
            };
            var p = new TreeNode(5);
            var q = new TreeNode(1);
            Assert.Equal(3, sln.LowestCommonAncestor(root, p, q).val);
        }

        [Fact]
        public void TestCase2()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(4)
                    }
                },
                right = new TreeNode(1)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(8)
                }
            };
            var p = new TreeNode(5);
            var q = new TreeNode(4);
            Assert.Equal(5, sln.LowestCommonAncestor(root, p, q).val);
        }
    }
}