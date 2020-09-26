/*
 * File: 637AverageOfLevelsInBinaryTree.cs
 * Project: Tree
 * Created Date: Saturday, 12th September 2020 2:08:53 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 252 ms, faster than 81.30% of C# online submissions for Average of Levels in Binary Tree.
 * Memory Usage: 33.2 MB, less than 66.26% of C# online submissions for Average of Levels in Binary Tree.
 * Copyright (c) David Gu 2020
 */


using System;
using System.Linq;
using System.Collections.Generic;

using TreeHelper;

namespace AverageOfLevelsInBinaryTree
{
    public class Solution
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {
            if (root is null) throw new ArgumentNullException(nameof(root));
            var avgs = new List<double>();
            var level = new Queue<TreeNode>();
            level.Enqueue(root);
            while (level.Count != 0)
            {
                avgs.Add(level.Select(x => x.val).Average());
                var n = level.Count;
                while (n != 0)
                {
                    var node = level.Dequeue();
                    if (node.left is object) level.Enqueue(node.left);
                    if (node.right is object) level.Enqueue(node.right);
                    n -= 1;
                }
            }
            return avgs.ToArray();
        }
    }
}