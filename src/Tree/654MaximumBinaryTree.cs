/*
 * File: 654MaximumBinaryTree.cs
 * Project: Tree
 * Created Date: Tuesday, 29th September 2020 4:27:39 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 132 ms, faster than 39.87% of C# online submissions for Maximum Binary Tree.
 * Memory Usage: 29.7 MB, less than 5.23% of C# online submissions for Maximum Binary Tree.
 * -----
 * Last Modified: Tuesday, 29th September 2020 4:36:39 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;
using System.Linq;
using TreeHelper;

namespace MaximumBinaryTree
{
    public class Solution
    {
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            if (nums.Length == 0) return null;
            if (nums.Length == 1) return new TreeNode(nums[0]);
            var idx = -1;
            var max = int.MinValue;
            foreach (var i in Enumerable.Range(0, nums.Length))
            {
                if (max < nums[i])
                {
                    idx = i;
                    max = nums[i];
                }
            }
            var root = new TreeNode(nums[idx])
            {
                left = ConstructMaximumBinaryTree(nums[0..idx]),
                right = ConstructMaximumBinaryTree(nums[(idx + 1)..nums.Length])
            };
            return root;
        }
    }
}