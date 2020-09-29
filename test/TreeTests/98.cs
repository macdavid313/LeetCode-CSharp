/*
 * File: 98.cs
 * Project: TreeTests
 * Created Date: Tuesday, 29th September 2020 5:36:08 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Tuesday, 29th September 2020 5:38:30 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TreeHelper;
using ValidateBinarySearchTree;

namespace TreeTests
{
    public class ValidateBinarySearchTreeTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new TreeNode(10)
            {
                left = new TreeNode(5),
                right = new TreeNode(15)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(20)
                }
            };
            var expected = false;
            var actual = sln.IsValidBST(root);
            Assert.Equal(expected, actual);
        }
    }
}