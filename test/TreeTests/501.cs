/*
 * File: 501.cs
 * Project: TreeTests
 * Created Date: Thursday, 24th September 2020 5:11:10 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Saturday, 26th September 2020 9:57:53 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TreeHelper;
using FindModeInBinarySearchTree;

namespace TreeTests
{
    public class FindModeInBinarySearchTreeTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new TreeNode(1)
            {
                left = null,
                right = new TreeNode(2)
                {
                    left = new TreeNode(2),
                    right = null
                }
            };
            var expected = new int[] { 2 };
            var actual = sln.FindMode(root);
            Assert.Equal(expected, actual);
        }
    }
}