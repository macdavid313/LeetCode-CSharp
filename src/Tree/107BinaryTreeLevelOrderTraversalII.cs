/*
 * File: 107BinaryTreeLevelOrderTraversalII.cs
 * Project: Tree
 * Created Date: Sunday, 6th September 2020 9:32:18 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 244 ms, faster than 88.69% of C# online submissions for Binary Tree Level Order Traversal II.
 * Memory Usage: 30.7 MB, less than 82.26% of C# online submissions for Binary Tree Level Order Traversal II.
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
            var level = new List<TreeNode>
            {
                root
            };
            while (level.Count != 0)
            {
                levels.Push(level.Select(node => node.val).ToArray());
                var nextLevel = new List<TreeNode>();
                foreach (var node in level)
                {
                    if (node.left is object) nextLevel.Add(node.left);
                    if (node.right is object) nextLevel.Add(node.right);
                }
                level = nextLevel;
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