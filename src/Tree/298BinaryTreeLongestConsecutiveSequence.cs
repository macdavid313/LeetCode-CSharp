/*
 * File: 298BinaryTreeLongestConsecutiveSequence.cs
 * Project: Tree
 * Created Date: Sunday, 11th October 2020 1:30:36 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Sunday, 11th October 2020 1:47:29 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using TreeHelper;

namespace BinaryTreeLongestConsecutiveSequence
{
    public class Solution
    {
        public int LongestConsecutive(TreeNode root)
        {
            if (root is null) return 0;
            var best = 0;
            DFS(root, null, 0, ref best);
            return best;
        }

        void DFS(TreeNode node, TreeNode parent, int length, ref int best)
        {
            if (node is null) return;
            length = (parent != null && node.val - parent.val == 1) ? length + 1 : 1;
            if (length > best) best = length;
            DFS(node.left, node, length, ref best);
            DFS(node.right, node, length, ref best);
        }
    }
}