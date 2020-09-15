/*
 * File: 226InvertBinaryTree.cs
 * Project: Tree
 * Created Date: Wednesday, 16th September 2020 8:40:52 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 88 ms, faster than 93.56% of C# online submissions for Invert Binary Tree.
 * Memory Usage: 23.8 MB, less than 62.95% of C# online submissions for Invert Binary Tree.
 * Copyright (c) David Gu 2020
 */


namespace InvertBinaryTree
{
    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root is null) return null;
            if (root.left is null && root.right is null) return root;
            root.left = InvertTree(root.left);
            root.right = InvertTree(root.right);
            var tmp = root.left;
            root.left = root.right;
            root.right = tmp;
            return root;
        }
    }

    /* Definition for a binary tree node. */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        static public bool TreeEquals(TreeNode r1, TreeNode r2)
        {
            if (r1 is null && r2 is null) return true;
            else if (r1 is null || r2 is null) return false;
            return r1.val == r2.val && TreeEquals(r1.left, r2.left) && TreeEquals(r1.right, r2.right);
        }
    }
}