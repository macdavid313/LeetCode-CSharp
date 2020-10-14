/*
 * File: 297SerializeAndDeserializeBinaryTree.cs
 * Project: Tree
 * Created Date: Tuesday, 13th October 2020 5:23:17 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 124 ms, faster than 76.24% of C# online submissions for Serialize and Deserialize Binary Tree.
 * Memory Usage: 35.3 MB, less than 5.74% of C# online submissions for Serialize and Deserialize Binary Tree.
 * -----
 * Last Modified: Wednesday, 14th October 2020 3:19:28 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using TreeHelper;

namespace SerializeAndDeserializeBinaryTree
{
    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            var vals = new List<string>();
            PreorderTraverse(root, vals);
            return string.Join(' ', vals);
        }

        void PreorderTraverse(TreeNode node, List<string> vals)
        {
            if (node is null) vals.Add("#");
            else
            {
                vals.Add(node.val.ToString());
                PreorderTraverse(node.left, vals);
                PreorderTraverse(node.right, vals);
            }
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            var vals = new Queue<string>(data.Split(" "));
            return Deserialize(vals);
        }

        TreeNode Deserialize(Queue<string> vals)
        {
            if (vals.Count == 0) return null;

            var first = vals.Dequeue();
            if (first == "#") return null;
            var node = new TreeNode(Convert.ToInt32(first))
            {
                left = Deserialize(vals),
                right = Deserialize(vals)
            };
            return node;
        }
    }
}