/*
 * File: 545BoundryOfBinaryTree.cs
 * Project: Tree
 * Created Date: Sunday, 11th October 2020 12:52:58 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Sunday, 11th October 2020 1:22:01 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using TreeHelper;

namespace BoundryOfBinaryTree
{
    public class Solution
    {
        public IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            if (root is null) return Array.Empty<int>();

            var ans = new List<int>();
            if (!IsLeaf(root)) ans.Add(root.val);
            // left
            if (root.left is TreeNode left)
            {
                while (left is object)
                {
                    if (!IsLeaf(left)) ans.Add(left.val);
                    if (left.left is object) left = left.left;
                    else left = left.right;
                }
            }
            // leaves
            AddLeaves(ans, root);
            // right
            var stack = new Stack<int>();
            if (root.right is TreeNode right)
            {
                while (right is object)
                {
                    if (!IsLeaf(right)) stack.Push(right.val);
                    if (right.right is object) right = right.right;
                    else right = right.left;
                }
            }
            while (stack.Count != 0) ans.Add(stack.Pop());
            return ans;
        }

        void AddLeaves(List<int> ans, TreeNode node)
        {
            if (node is null) return;
            if (IsLeaf(node)) ans.Add(node.val);
            AddLeaves(ans, node.left);
            AddLeaves(ans, node.right);
        }

        bool IsLeaf(TreeNode node) => node.left is null && node.right is null;
    }
}