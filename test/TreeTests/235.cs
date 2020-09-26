/*
 * File: 235.cs
 * Project: TreeTests
 * Created Date: Sunday, 27th September 2020 8:02:51 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Sunday, 27th September 2020 8:23:00 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TreeHelper;
using LowestCommonAncestorOfABinarySearchTree;

namespace TreeTests
{
    public class LowestCommonAncestorOfABinarySearchTreeTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new TreeNode(6)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(3),
                        right = new TreeNode(5)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(7),
                    right = new TreeNode(9)
                }
            };
            var p = new TreeNode(2);
            var q = new TreeNode(8);
            Assert.Equal(6, sln.LowestCommonAncestor(root, p, q).val);
        }

        [Fact]
        public void TestCase2()
        {
            var root = new TreeNode(6)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(3),
                        right = new TreeNode(5)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(7),
                    right = new TreeNode(9)
                }
            };
            var p = new TreeNode(2);
            var q = new TreeNode(4);
            Assert.Equal(2, sln.LowestCommonAncestor(root, p, q).val);
        }
    }
}