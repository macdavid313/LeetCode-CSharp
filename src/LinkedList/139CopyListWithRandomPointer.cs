/*
 * File: 139CopyListWithRandomPointer.cs
 * Project: LinkedList
 * Created Date: Tuesday, 13th October 2020 2:40:18 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 88 ms, faster than 98.89% of C# online submissions for Copy List with Random Pointer.
 * Memory Usage: 25.9 MB, less than 25.49% of C# online submissions for Copy List with Random Pointer.
 * -----
 * Last Modified: Tuesday, 13th October 2020 3:30:37 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;

namespace CopyListWithRandomPointer
{
    public class Solution
    {
        public Node CopyRandomList(Node head)
        {
            if (head is null) return null;
            var copied = new Dictionary<Node, Node>();
            return CopyRandomList(head, copied);
        }

        Node CopyRandomList(Node node, Dictionary<Node, Node> copied)
        {
            if (node is null) return null;
            if (copied.ContainsKey(node)) return copied[node];

            var nodeCopy = new Node(node.val);
            copied.Add(node, nodeCopy);
            nodeCopy.next = CopyRandomList(node.next, copied);
            nodeCopy.random = CopyRandomList(node.random, copied);
            return nodeCopy;
        }
    }

    /* Definition for a Node. */
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}