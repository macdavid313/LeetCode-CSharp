/*
 * File: 94BinaryTreeInorderTraversal.cs
 * Project: Tree
 * Created Date: Monday, 14th September 2020 8:38:18 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 240 ms, faster than 71.94% of C# online submissions for Binary Tree Inorder Traversal.
 * Memory Usage: 30 MB, less than 10.75% of C# online submissions for Binary Tree Inorder Traversal.
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;

using TreeHelper;

namespace BinaryTreeInorderTraversal
{

    public class Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root is null) return System.Array.Empty<int>();
            var elms = new List<int>();
            var stack = new Stack<TreeNode>();
            var node = root;
            while (node is object || stack.Count != 0)
            {
                while (node is object)
                {
                    stack.Push(node);
                    node = node.left;
                }
                node = stack.Pop();
                elms.Add(node.val);
                node = node.right;
            }
            return elms.ToArray();
        }

        /* Trivial recusion solution
         * Runtime: 396 ms, faster than 9.56% of C# online submissions for Binary Tree Inorder Traversal.
         * Memory Usage: 30.1 MB, less than 5.29% of C# online submissions for Binary Tree Inorder Traversal.
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root is null) return new int[0];
            var elms = new List<int>();
            Travel(root, elms);
            return elms.ToArray();
        }

        void Travel(TreeNode node, List<int> elms)
        {
            if (node is null) return;
            Travel(node.left, elms);
            elms.Add(node.val);
            Travel(node.right, elms);
        } */
    }
}