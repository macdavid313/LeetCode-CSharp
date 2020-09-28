/*
 * File: 116PopulatingNextRightPointersInEachNode.cs
 * Project: Tree
 * Created Date: Monday, 28th September 2020 5:43:07 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 92 ms, faster than 99.81% of C# online submissions for Populating Next Right Pointers in Each Node.
 * Memory Usage: 30 MB, less than 5.21% of C# online submissions for Populating Next Right Pointers in Each Node.
 * -----
 * Last Modified: Monday, 28th September 2020 7:06:25 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


namespace PopulatingNextRightPointersInEachNode
{
    public class Solution
    {
        public Node Connect(Node root)
        {
            if (root is null) return root;
            if (root.left is Node left) left.next = root.right;
            if (root.right is Node right) right.next = root.next?.left;
            root.left = Connect(root.left);
            root.right = Connect(root.right);
            return root;
        }
    }

    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}