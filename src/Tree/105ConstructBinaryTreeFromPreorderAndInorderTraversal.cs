/*
 * File: 105ConstructBinaryTreeFromPreorderAndInorderTraversal.cs
 * Project: Tree
 * Created Date: Tuesday, 29th September 2020 4:52:52 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 96 ms, faster than 92.05% of C# online submissions for Construct Binary Tree from Preorder and Inorder Traversal.
 * Memory Usage: 27.2 MB, less than 15.37% of C# online submissions for Construct Binary Tree from Preorder and Inorder Traversal.
 * -----
 * Last Modified: Tuesday, 29th September 2020 5:01:23 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using TreeHelper;

namespace ConstructBinaryTreeFromPreorderAndInorderTraversal
{
    public class Solution
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder) => BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);

        TreeNode BuildTree(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd) return null;
            var rootVal = preorder[preStart];
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
                left = BuildTree(preorder, preStart + 1, preStart + leftSize, inorder, inStart, idx - 1),
                right = BuildTree(preorder, preStart + leftSize + 1, preEnd, inorder, idx + 1, inEnd)
            };
        }
    }
}