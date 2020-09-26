/*
 * File: 235LowestCommonAncestorOfABinarySearchTree.cs
 * Project: Tree
 * Created Date: Sunday, 27th September 2020 8:00:56 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 104 ms, faster than 96.50% of C# online submissions for Lowest Common Ancestor of a Binary Search Tree.
 * Memory Usage: 32.5 MB, less than 5.08% of C# online submissions for Lowest Common Ancestor of a Binary Search Tree.
 * -----
 * Last Modified: Sunday, 27th September 2020 8:22:39 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using TreeHelper;

namespace LowestCommonAncestorOfABinarySearchTree
{
    public class Solution
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            root = root ?? throw new ArgumentNullException(nameof(root));
            p = p ?? throw new ArgumentNullException(nameof(p));
            q = q ?? throw new ArgumentNullException(nameof(q));
            TreeNode parent = root;
            while (true)
            {
                if (p.val < parent.val && q.val < parent.val) parent = parent.left;
                else if (p.val > parent.val && q.val > parent.val) parent = parent.right;
                else break;
            }
            return parent;
        }
    }
}