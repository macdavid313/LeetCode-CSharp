/*
 * File: 701InsertIntoABinarySearchTree.cs
 * Project: Tree
 * Created Date: Wednesday, 30th September 2020 6:49:40 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Wednesday, 30th September 2020 6:50:22 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using TreeHelper;

namespace InsertIntoABinarySearchTree
{
    public class Solution
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root is null) return new TreeNode(val);
            if (root.val < val) root.right = InsertIntoBST(root.right, val);
            else root.left = InsertIntoBST(root.left, val);
            return root;
        }
    }
}