/*
 * File: 501FindModeInBinarySearchTree.cs
 * Project: Tree
 * Created Date: Thursday, 24th September 2020 2:48:57 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 240 ms, faster than 99.02% of C# online submissions for Find Mode in Binary Search Tree.
 * Memory Usage: 32.8 MB, less than 97.06% of C# online submissions for Find Mode in Binary Search Tree.
 * -----
 * Last Modified: Saturday, 26th September 2020 9:59:45 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;

using TreeHelper;

namespace FindModeInBinarySearchTree
{
    public class Solution
    {
        public int[] FindMode(TreeNode root)
        {
            var trace = new Trace(0, 0, 0);
            InOrderTravel(root, trace);
            return trace.Modes;
        }

        void InOrderTravel(TreeNode node, Trace trace)
        {
            if (node is null) return;
            InOrderTravel(node.left, trace);
            trace.Update(node);
            InOrderTravel(node.right, trace);
        }
    }

    public class Trace
    {
        int num;
        int count;
        int maxCount;
        readonly List<int> modes;

        public int[] Modes { get => modes.ToArray(); }

        public Trace(int num, int count, int maxCount)
        {
            this.num = num;
            this.count = count;
            this.maxCount = maxCount;
            modes = new List<int>();
        }

        public void Update(TreeNode node)
        {
            if (node.val == num) count += 1;
            else
            {
                count = 1;
                num = node.val;
            }
            if (count == maxCount) modes.Add(num);
            else if (count > maxCount)
            {
                maxCount = count;
                modes.Clear();
                modes.Add(num);
            }
        }
    }
}