/*
 * File: 98ValidateBinarySearchTree.cs
 * Project: Tree
 * Created Date: Tuesday, 29th September 2020 5:35:28 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 100 ms, faster than 65.12% of C# online submissions for Validate Binary Search Tree.
 * Memory Usage: 26.8 MB, less than 7.63% of C# online submissions for Validate Binary Search Tree.
 * -----
 * Last Modified: Tuesday, 29th September 2020 5:40:54 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using TreeHelper;

namespace ValidateBinarySearchTree
{
    public class Solution
    {
        static TreeNode _prev;
        static bool _flag;

        public bool IsValidBST(TreeNode root)
        {
            if (root is null) return true;
            _prev = null;
            _flag = true;
            InOrderTraverse(root);
            return _flag;
        }

        void InOrderTraverse(TreeNode root)
        {
            if (!_flag) return;
            if (root is null) return;

            InOrderTraverse(root.left);
            if (_prev is TreeNode prev)
            {
                if (root.val <= prev.val)
                {
                    _flag = false;
                    return;
                }
            }
            _prev = root;
            InOrderTraverse(root.right);
        }
    }
}