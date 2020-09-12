/*
 * File: 107BinaryTreeLevelOrderTraversalII.cs
 * Project: Tree
 * Created Date: Sunday, 6th September 2020 9:32:18 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 248 ms, faster than 71.43% of C# online submissions for Binary Tree Level Order Traversal II.
 * Memory Usage: 30.7 MB, less than 82.07% of C# online submissions for Binary Tree Level Order Traversal II.
 * Copyright (c) David Gu 2020
 */


using System.Linq;
using System.Collections.Generic;

namespace BinaryTreeLevelOrderTraversalII
{
    public class Solution
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            if (root is null) return new int[0][];
            var levels = new Stack<int[]>();
            var level = new Queue<TreeNode>();
            level.Enqueue(root);
            while (level.Count != 0)
            {
                levels.Push(level.Select(node => node.val).ToArray());
                var n = level.Count;
                while (n != 0)
                {
                    var node = level.Dequeue();
                    if (node.left is object) level.Enqueue(node.left);
                    if (node.right is object) level.Enqueue(node.right);
                    n -= 1;
                }
            }
            return levels.ToArray();
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
    }
}