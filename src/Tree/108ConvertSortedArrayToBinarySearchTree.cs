/*
 * File: 108ConvertSortedArrayToBinarySearchTree.cs
 * Project: Tree
 * Created Date: Thursday, 1st October 2020 6:45:30 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 88 ms, faster than 97.74% of C# online submissions for Convert Sorted Array to Binary Search Tree.
 * Memory Usage: 26.2 MB, less than 10.59% of C# online submissions for Convert Sorted Array to Binary Search Tree.
 * -----
 * Last Modified: Thursday, 1st October 2020 6:48:11 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using TreeHelper;

namespace ConvertSortedArrayToBinarySearchTree
{
    public class Solution
    {
        public TreeNode SortedArrayToBST(int[] nums) => SortedArrayToBST(nums, 0, nums.Length - 1);

        TreeNode SortedArrayToBST(int[] nums, int lo, int hi)
        {
            if (lo > hi) return null;
            var mid = lo + (hi - lo) / 2;
            var root = new TreeNode(nums[mid])
            {
                left = SortedArrayToBST(nums, lo, mid - 1),
                right = SortedArrayToBST(nums, mid + 1, hi)
            };
            return root;
        }
    }
}