/*
 * File: MyTree.cs
 * Project: Tree
 * Created Date: Sunday, 6th September 2020 12:13:19 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections;
using System.Collections.Generic;

namespace MyTree
{
    public class BinarySearchTree<TKey, TValue> : IEnumerable<(TKey, TValue)>
    {
        Node root;
        readonly Comparer<TKey> comparer;

        public BinarySearchTree()
        {
            root = null;
            comparer = Comparer<TKey>.Default;
        }

        public BinarySearchTree(Comparer<TKey> comparer)
        {
            root = null;
            this.comparer = comparer;
        }

        class Node
        {
            public TKey key;
            public TValue val;
            public Node left, right;

            public int Count { get; set; }

            public Node(TKey key, TValue val, Node left = null, Node right = null)
            {
                this.key = key;
                this.val = val;
                this.left = left;
                this.right = right;
                Count = 1;
                if (this.left is object) Count += this.left.Count;
                if (this.right is object) Count += this.right.Count;
            }
        }

        public int Size() => Size(root);

        int Size(Node node) => node is null ? 0 : node.Count;

        public TValue Get(TKey key) => Get(root, key);

        TValue Get(Node node, TKey key)
        {
            if (node is null) throw new ArgumentException(nameof(key));
            var cmp = comparer.Compare(node.key, key);
            if (cmp == 0) return node.val;
            else if (cmp > 0) return Get(node.left, key);
            else return Get(node.right, key);
        }

        public void Put(TKey key, TValue val) => root = Put(root, key, val);

        Node Put(Node node, TKey key, TValue val)
        {
            if (node is null) return new Node(key, val);

            var cmp = comparer.Compare(node.key, key);
            if (cmp == 0) node.val = val;
            else if (cmp > 0) node.left = Put(node.left, key, val);
            else node.right = Put(node.right, key, val);
            node.Count = 1 + Size(node.left) + Size(node.right);
            return node;
        }

        public void Delete(TKey key)
        {
            if (Size() == 0)
                throw new InvalidOperationException();
            root = Delete(root, key);
        }

        Node Delete(Node node, TKey key)
        {
            if (node is null) return null;
            var cmp = comparer.Compare(node.key, key);
            if (cmp < 0) node.right = Delete(node.right, key);
            else if (cmp > 0) node.left = Delete(node.left, key);
            else
            {
                if (node.left is null) return node.right;
                if (node.right is null) return node.left;
                Node tmp = node;
                node = Min(tmp.right);
                node.left = tmp.left;
                node.right = DeleteMin(tmp.right);
            }
            node.Count = 1 + Size(node.left) + Size(node.right);
            return node;
        }

        public void DeleteMin()
        {
            if (Size() == 0)
                throw new InvalidOperationException();
            root = DeleteMin(root);
        }

        Node DeleteMin(Node node)
        {
            if (node.left is null) return node.right;
            node.left = DeleteMin(node.left);
            node.Count = 1 + Size(node.left) + Size(node.right);
            return node;
        }

        public void DeleteMax()
        {
            if (Size() == 0)
                throw new InvalidOperationException();
            root = DeleteMax(root);
        }

        Node DeleteMax(Node node)
        {
            if (node.right is null) return node.left;
            node.right = DeleteMax(node.right);
            node.Count = 1 + Size(node.left) + Size(node.right);
            return node;
        }

        public TKey Min()
        {
            if (Size() == 0)
                throw new InvalidOperationException();
            return Min(root).key;
        }

        Node Min(Node node)
        {
            while (node.left is object) node = node.left;
            return node;
        }

        public TKey Max()
        {
            if (Size() == 0)
                throw new InvalidOperationException();
            return Max(root).key;
        }

        Node Max(Node node)
        {
            while (node.right is object) node = node.right;
            return node;
        }

        /* the largest key in the BST less than or equal to key */
        public TValue Floor(TKey key)
        {
            if (Size() == 0)
                throw new InvalidOperationException();
            var node = Floor(root, key);
            if (node is null) throw new ArgumentException(nameof(key));
            return node.val;
        }

        Node Floor(Node node, TKey key)
        {
            if (node is null) return null;
            var cmp = comparer.Compare(node.key, key);
            if (cmp == 0) return node;
            if (cmp > 0) return Floor(node.left, key);
            Node x = Floor(node.right, key);
            return x is null ? node : x;
        }

        /* the smallest key in the BST bigger than or equal to key */
        public TValue Ceiling(TKey key)
        {
            if (Size() == 0)
                throw new InvalidOperationException();
            var node = Ceiling(root, key);
            if (node is null) throw new ArgumentException(nameof(key));
            return node.val;
        }

        Node Ceiling(Node node, TKey key)
        {
            if (node is null) return null;
            var cmp = comparer.Compare(node.key, key);
            if (cmp == 0) return node;
            if (cmp < 0) return Ceiling(node.right, key);
            Node x = Ceiling(node.left, key);
            return x is null ? node : x;
        }

        /* return Node containing key of rank k. */
        public TKey Select(int k)
        {
            if (Size() < k)
                throw new InvalidOperationException();
            return Select(root, k).key;
        }

        Node Select(Node node, int k)
        {
            int t = Size(node.left);
            if (t == k) return node;
            if (t > k) return Select(node.left, k);
            else return Select(node.right, k - t - 1);
        }

        /* Return number of keys less than key in the subtree rooted at x. */
        public int Rank(TKey key)
        {
            if (Size() == 0)
                throw new InvalidOperationException();
            return Rank(root, key);
        }

        int Rank(Node node, TKey key)
        {
            if (node is null) return 0;
            var cmp = comparer.Compare(node.key, key);
            if (cmp == 0) return node.left.Count;
            else if (cmp < 0) return 1 + node.left.Count + Rank(node.right, key);
            else return Rank(node.left, key);
        }

        public IEnumerator<(TKey, TValue)> GetEnumerator()
        {
            return GetRange(Min(), Max()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerable<(TKey, TValue)> GetRange(TKey lo, TKey hi)
        {
            if (comparer.Compare(lo, hi) <= 0)
            {
                var queue = new Queue<(TKey, TValue)>();
                GetRange(root, queue, lo, hi);
                return queue;
            }
            throw new InvalidOperationException();
        }

        void GetRange(Node node, Queue<(TKey, TValue)> queue, TKey lo, TKey hi)
        {
            if (node is null) return;
            var cmplo = comparer.Compare(node.key, lo);
            var cmphi = comparer.Compare(node.key, hi);
            if (cmplo < 0) GetRange(node.right, queue, lo, hi);
            else if (cmphi > 0) GetRange(node.left, queue, lo, hi);
            else
            {
                queue.Enqueue((node.key, node.val));
                GetRange(node.left, queue, lo, hi);
                GetRange(node.right, queue, lo, hi);
            }
        }
    }
}