/*
 * File: 652FindDuplicateSubtrees.cs
 * Project: Tree
 * Created Date: Tuesday, 13th October 2020 5:19:14 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 384 ms, faster than 67.07% of C# online submissions for Find Duplicate Subtrees.
 * Memory Usage: 62.6 MB, less than 6.10% of C# online submissions for Find Duplicate Subtrees.
 * -----
 * Last Modified: Wednesday, 14th October 2020 3:45:30 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;
using System.Text;
using TreeHelper;

namespace FindDuplicateSubtrees
{
    public class Solution
    {
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            var lookup = new Dictionary<string, int>();
            var ans = new List<TreeNode>();
            _ = PostorderTraverse(root, lookup, ans);
            return ans;
        }

        string PostorderTraverse(TreeNode node, Dictionary<string, int> lookup, List<TreeNode> ans)
        {
            if (node is null) return "#";

            var (left, right) = (PostorderTraverse(node.left, lookup, ans), PostorderTraverse(node.right, lookup, ans));
            var sb = new StringBuilder();
            sb.Append(right).Append(' ').Append(left).Append(' ').Append(node.val);
            var repr = sb.ToString();
            if (lookup.ContainsKey(repr)) lookup[repr] += 1;
            else lookup.Add(repr, 0);
            if (lookup[repr] == 1) ans.Add(node);
            return repr;
        }
    }
}