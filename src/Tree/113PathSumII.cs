/*
 * File: 113PathSumII.cs
 * Project: Tree
 * Created Date: Saturday, 26th September 2020 10:22:40 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 248 ms, faster than 81.59% of C# online submissions for Path Sum II.
 * Memory Usage: 33.1 MB, less than 29.10% of C# online submissions for Path Sum II.
 * -----
 * Last Modified: Saturday, 26th September 2020 10:49:40 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using System.Linq;
using TreeHelper;

namespace PathSumII
{
    public class Solution
    {
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            if (root is null) return Array.Empty<int[]>();
            var paths = new List<int[]>();
            var stack = new Stack<int>();
            DFS(root, stack, sum, paths);
            return paths.ToArray();
        }

        void DFS(TreeNode node, Stack<int> stack, int sum, List<int[]> paths)
        {
            sum -= node.val;
            if (IsLeafNode(node))
            {
                stack.Push(node.val);
                if (sum == 0) paths.Add(stack.Reverse().ToArray());
                stack.Pop();
                return;
            }
            if (node.left is TreeNode left)
            {
                stack.Push(node.val);
                DFS(left, stack, sum, paths);
                stack.Pop();
            }
            if (node.right is TreeNode right)
            {
                stack.Push(node.val);
                DFS(right, stack, sum, paths);
                stack.Pop();
            }
        }

        bool IsLeafNode(TreeNode node) => node is TreeNode t && t.left is null && t.right is null;
    }
}