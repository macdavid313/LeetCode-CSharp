/*
 * File: 257.cs
 * Project: TreeTests
 * Created Date: Friday, 4th September 2020 7:28:25 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using TreeHelper;
using BinaryTreePaths;

namespace TreeTests
{
    public class BinaryTreePaths
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2, null, new TreeNode(5)),
                right = new TreeNode(3)
            };
            var expected = new string[2] { "1->2->5", "1->3" };
            var actual = sln.BinaryTreePaths(root);
            Assert.Equal(expected, actual);
        }
    }
}