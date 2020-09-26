/*
 * File: TreeNode.cs
 * Project: Tree
 * Created Date: Saturday, 26th September 2020 7:31:43 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Saturday, 26th September 2020 10:00:54 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;

namespace TreeHelper
{
    /* Definition for a binary tree node. */
    public class TreeNode : IEquatable<TreeNode>
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public bool Equals(TreeNode other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            var flag = val == other.val;
            if (left is object) flag = flag && left.Equals(other.left);
            if (right is object) flag = flag && right.Equals(other.right);
            return flag;
        }

        public override bool Equals(object obj) => Equals(obj as TreeNode);

        public override int GetHashCode() => HashCode.Combine(val, left, right);

        public static bool operator ==(TreeNode t1, TreeNode t2)
        {
            if (ReferenceEquals(t1, t2)) return true;
            if (t1 is object && t2 is object) return t1.Equals(t2);
            else return false;
        }

        public static bool operator !=(TreeNode t1, TreeNode t2) => !(t1 == t2);
    }
}