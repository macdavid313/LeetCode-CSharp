/*
 * File: 114FlattenBinaryTreeToLinkedList.cs
 * Project: Tree
 * Created Date: Monday, 28th September 2020 6:02:00 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 88 ms, faster than 97.19% of C# online submissions for Flatten Binary Tree to Linked List.
 * Memory Usage: 26 MB, less than 5.15% of C# online submissions for Flatten Binary Tree to Linked List.
 * -----
 * Last Modified: Monday, 28th September 2020 6:12:21 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using TreeHelper;

namespace FlattenBinaryTreeToLinkedList
{
    public class Solution
    {
        public void Flatten(TreeNode root)
        {
            if (root is null) return;
            Flatten(root.left);
            Flatten(root.right);
            var left = root.left;
            var right = root.right;
            root.left = null;
            if (left is null)
            {
                root.right = right;
                return;
            }
            root.right = left;
            while (left.right is TreeNode node) left = node;
            left.right = right;
        }
    }
}