/*
 * File: 106ConstructBinaryTreeFromInorderAndPostorderTraversal.cs
 * Project: Tree
 * Created Date: Tuesday, 29th September 2020 5:06:28 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 104 ms, faster than 57.46% of C# online submissions for Construct Binary Tree from Inorder and Postorder Traversal.
 * Memory Usage: 27 MB, less than 16.05% of C# online submissions for Construct Binary Tree from Inorder and Postorder Traversal.
 * -----
 * Last Modified: Tuesday, 29th September 2020 5:14:47 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using TreeHelper;

namespace ConstructBinaryTreeFromInorderAndPostorderTraversal
{
    public class Solution
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder) => BuildTree(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);

        public TreeNode BuildTree(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd)
        {
            if (inStart > inEnd || postStart > postEnd) return null;
            var rootVal = postorder[postEnd];
            var idx = -1;
            for (var i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == rootVal)
                {
                    idx = i;
                    break;
                }
            }
            var leftSize = idx - inStart;
            return new TreeNode(rootVal)
            {
                left = BuildTree(inorder, inStart, idx - 1, postorder, postStart, postStart + leftSize - 1),
                right = BuildTree(inorder, idx + 1, inEnd, postorder, postStart + leftSize, postEnd - 1)
            };
        }
    }
}