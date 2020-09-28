/*
 * File: 530MinimumAbsoluteDifferenceInBST.cs
 * Project: Tree
 * Created Date: Monday, 28th September 2020 8:34:13 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 96 ms, faster than 97.00% of C# online submissions for Minimum Absolute Difference in BST.
 * Memory Usage: 28.7 MB, less than 9.00% of C# online submissions for Minimum Absolute Difference in BST.
 * -----
 * Last Modified: Monday, 28th September 2020 8:41:42 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using TreeHelper;

namespace MinimumAbsoluteDifferenceInBST
{
    public class Solution
    {
        static int _diff;
        static TreeNode _prev;

        public int GetMinimumDifference(TreeNode root)
        {
            _diff = int.MaxValue;
            _prev = null;
            InOrderTraverse(root);
            return _diff;
        }

        void InOrderTraverse(TreeNode node)
        {
            InOrderTraverse(node.left);
            if (_prev is object)
            {
                var newDiff = Math.Abs(node.val - _prev.val);
                _diff = _diff > newDiff ? newDiff : _diff;
            }
            _prev = node;
            InOrderTraverse(node.right);
        }
    }
}