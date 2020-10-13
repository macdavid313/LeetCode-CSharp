/*
 * File: 133CloneGraph.cs
 * Project: Graph
 * Created Date: Tuesday, 13th October 2020 3:34:27 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Tuesday, 13th October 2020 3:39:53 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;
using System.Linq;

namespace CloneGraph
{
    public class Solution
    {
        public Node CloneGraph(Node node)
        {
            return CloneGraph(node, new Dictionary<Node, Node>());
        }

        Node CloneGraph(Node node, Dictionary<Node, Node> copied)
        {
            if (node is null) return node;
            if (copied.ContainsKey(node)) return copied[node];
            var nodeCopy = new Node(node.val);
            copied.Add(node, nodeCopy);
            nodeCopy.neighbors = node.neighbors.Select(n => CloneGraph(n, copied)).ToArray();
            return nodeCopy;
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}