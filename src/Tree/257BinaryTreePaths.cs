/*
 * File: 257BinaryTreePaths.cs
 * Project: Tree
 * Created Date: Friday, 4th September 2020 7:27:05 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 248 ms, faster than 87.79% of C# online submissions for Binary Tree Paths.
 * Memory Usage: 31.7 MB, less than 32.47% of C# online submissions for Binary Tree Paths.
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;

using TreeHelper;

namespace BinaryTreePaths
{
    public class Solution
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            if (root is null) return System.Array.Empty<string>();
            if (root.left is null && root.right is null) return new string[1] { root.val.ToString() };
            var path = new List<string>();
            var allPaths = new List<string>();
            Travel(root, path, allPaths);
            return allPaths;
        }

        void Travel(TreeNode node, List<string> path, List<string> allPaths)
        {
            path.Add(node.val.ToString());
            if (node.left is null && node.right is null)
            {
                allPaths.Add(PathToString(path));
                path.RemoveAt(path.Count - 1);
                return;
            }
            if (node.left is object)
                Travel(node.left, path, allPaths);
            if (node.right is object)
                Travel(node.right, path, allPaths);
            path.RemoveAt(path.Count - 1);
        }

        string PathToString(List<string> path) => string.Join("->", path);
    }
}