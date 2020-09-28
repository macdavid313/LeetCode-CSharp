/*
 * File: 117PopulatingNextRightPointersInEachNodeII.cs
 * Project: Tree
 * Created Date: Monday, 28th September 2020 6:15:09 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 100 ms, faster than 79.10% of C# online submissions for Populating Next Right Pointers in Each Node II.
 * Memory Usage: 27.4 MB, less than 5.47% of C# online submissions for Populating Next Right Pointers in Each Node II.
 * -----
 * Last Modified: Monday, 28th September 2020 7:42:02 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System.Xml;

namespace PopulatingNextRightPointersInEachNodeII
{
    public class Solution
    {
        public Node Connect(Node root)
        {
            if (root is null) return root;
            if (root.left is Node left)
            {
                if (root.right is null) ConnectTRightNextNode(root.next, left);
                else left.next = root.right;
            }
            if (root.right is Node right) ConnectTRightNextNode(root.next, right);
            // right connections must be available first
            root.right = Connect(root.right);
            root.left = Connect(root.left);
            return root;
        }

        void ConnectTRightNextNode(Node node, Node child)
        {
            while (node is object)
            {
                if (node.left is Node left)
                {
                    child.next = left;
                    return;
                }
                if (node.right is Node right)
                {
                    child.next = right;
                    return;
                }
                node = node.next;
            }
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