/*
 * File: 236LowestCommonAncestorOfABinaryTree.cs
 * Project: Tree
 * Created Date: Sunday, 27th September 2020 8:22:16 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 128 ms, faster than 29.04% of C# online submissions for Lowest Common Ancestor of a Binary Tree.
 * Memory Usage: 28.6 MB, less than 38.76% of C# online submissions for Lowest Common Ancestor of a Binary Tree.
 * -----
 * Last Modified: Saturday, 3rd October 2020 10:31:56 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using TreeHelper;

namespace LowestCommentAncestorOfABinaryTree
{
    public class Solution
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root is null) return null;
            if (root == p || root == q) return root;
            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            if (left is null && right is null) return null;
            if (left is object && right is object) return root;
            return left is null ? right : left;
        }
    }

    /*
    * Runtime: 104 ms, faster than 82.17% of C# online submissions for Lowest Common Ancestor of a Binary Tree.
    * Memory Usage: 31.3 MB, less than 5.95% of C# online submissions for Lowest Common Ancestor of a Binary Tree.
    public class Solution
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            root = root ?? throw new ArgumentNullException(nameof(root));
            p = p ?? throw new ArgumentNullException(nameof(p));
            q = q ?? throw new ArgumentNullException(nameof(q));

            var parents = new Dictionary<int, TreeNode>
            {
                { root.val, null }
            };
            DFS(root, parents);

            var marked = new HashSet<int>(parents.Count);
            while (p is object)
            {
                marked.Add(p.val);
                p = parents[p.val];
            }
            while (q is object)
            {
                if (marked.Contains(q.val)) return q;
                q = parents[q.val];
            }
            return null;
        }

        void DFS(TreeNode node, Dictionary<int, TreeNode> parents)
        {
            if (node.left is TreeNode left)
            {
                parents.Add(left.val, node);
                DFS(left, parents);
            }
            if (node.right is TreeNode right)
            {
                parents.Add(right.val, node);
                DFS(right, parents);
            }
        }
    } */

    /*
    * Runtime: 108 ms, faster than 62.07% of C# online submissions for Lowest Common Ancestor of a Binary Tree.
    * Memory Usage: 31.2 MB, less than 5.95% of C# online submissions for Lowest Common Ancestor of a Binary Tree.
    public class Solution
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            root = root ?? throw new ArgumentNullException(nameof(root));
            p = p ?? throw new ArgumentNullException(nameof(p));
            q = q ?? throw new ArgumentNullException(nameof(q));
            var path1 = GetPath(root, p);
            var path2 = GetPath(root, q);
            TreeNode ancestor = null;
            for (var i = 0; i < path1.Length && i < path2.Length; i++)
            {
                if (path1[i].val == path2[i].val) ancestor = path1[i];
            }
            return ancestor;
        }

        TreeNode[] GetPath(TreeNode root, TreeNode target)
        {
            var path = new Stack<TreeNode>();
            Search(root, target, path);
            return path.Reverse().ToArray();
        }

        bool Search(TreeNode node, TreeNode target, Stack<TreeNode> path)
        {
            if (node is null) return false;
            path.Push(node);
            if (node.val == target.val) return true;
            var flag = Search(node.left, target, path) || Search(node.right, target, path);
            if (!flag) path.Pop();
            return flag;
        }
    } */
}