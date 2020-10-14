/*
 * File: 606ConstructingStringFromBinaryTree.cs
 * Project: Tree
 * Created Date: Wednesday, 14th October 2020 4:56:28 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 120 ms, faster than 61.73% of C# online submissions for Construct String from Binary Tree.
 * Memory Usage: 47.4 MB, less than 6.17% of C# online submissions for Construct String from Binary Tree.
 * -----
 * Last Modified: Wednesday, 14th October 2020 4:57:11 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System.Text;
using TreeHelper;

namespace ConstructStringFromBinaryTree
{
    public class Solution
    {
        public string Tree2str(TreeNode t)
        {
            return t is null ? "" : TreeToStr(t);
        }

        string TreeToStr(TreeNode t)
        {
            if (t is null) return "()";
            if (t.left is null && t.right is null) return t.val.ToString();

            var sb = new StringBuilder();
            sb.Append(t.val);
            if (t.left is object) sb.Append('(').Append(Tree2str(t.left)).Append(')');
            else sb.Append("()");
            if (t.right is object) sb.Append('(').Append(Tree2str(t.right)).Append(')');
            return sb.ToString();
        }
    }
}