/*
 * File: 112PathSum.cs
 * Project: Tree
 * Created Date: Saturday, 26th September 2020 7:28:11 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 100 ms, faster than 71.00% of C# online submissions for Path Sum.
 * Memory Usage: 26.6 MB, less than 5.14% of C# online submissions for Path Sum.
 * -----
 * Last Modified: Saturday, 26th September 2020 10:19:12 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using TreeHelper;

namespace PathSum
{
    public class Solution
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root is null) return false;
            return DFS(root, sum);
        }

        bool DFS(TreeNode node, int sum)
        {
            sum -= node.val;
            if (IsLeafNode(node)) return sum == 0;
            return (node.left is TreeNode left && DFS(left, sum))
                    || (node.right is TreeNode right && DFS(right, sum));
        }

        bool IsLeafNode(TreeNode node) => node is TreeNode t && t.left is null && t.right is null;
    }
}