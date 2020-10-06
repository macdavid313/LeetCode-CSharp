/*
 * File: 834SumOfDistancesInTree.cs
 * Project: Tree
 * Created Date: Tuesday, 6th October 2020 6:47:43 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 316 ms, faster than 83.33% of C# online submissions for Sum of Distances in Tree.
 * Memory Usage: 44.9 MB, less than 33.33% of C# online submissions for Sum of Distances in Tree.
 * -----
 * Last Modified: Tuesday, 6th October 2020 8:45:02 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfDistancesInTree
{
    public class Solution
    {
        public int[] SumOfDistancesInTree(int N, int[][] edges)
        {
            return new Tree834(N, edges).Sum;
        }

        class Tree834
        {
            readonly List<int>[] _adj;
            readonly bool[] _marked;
            readonly int[] _sz;
            readonly int[] _sum;

            public int[] Sum { get => _sum; }

            public Tree834(int N, int[][] edges)
            {
                _adj = new List<int>[N];
                foreach (var i in Enumerable.Range(0, N)) _adj[i] = new List<int>();
                foreach (var edge in edges)
                {
                    var u = edge[0];
                    var v = edge[1];
                    _adj[u].Add(v);
                    _adj[v].Add(u);
                }
                _marked = new bool[N];
                _sz = new int[N];
                Array.Fill(_sz, 1);
                PopulateSizes(0);
                Array.Fill(_marked, false);
                _sum = new int[N];
                _sum[0] = SumDistance();
                Array.Fill(_marked, false);
                DFS(0);
            }

            void PopulateSizes(int s)
            {
                _marked[s] = true;
                foreach (var w in _adj[s])
                {
                    if (!_marked[w])
                    {
                        PopulateSizes(w);
                        _sz[s] += _sz[w];
                    }
                }
            }

            int SumDistance()
            {
                var queue = new Queue<int>(_adj.Length);
                queue.Enqueue(0);
                var sum = 0;
                var level = 0;
                while (queue.Count != 0)
                {
                    var count = queue.Count;
                    sum += count * level;
                    level += 1;
                    while (count != 0)
                    {
                        var v = queue.Dequeue();
                        _marked[v] = true;
                        foreach (var w in _adj[v])
                        {
                            if (!_marked[w]) queue.Enqueue(w);
                        }
                        count -= 1;
                    }
                }
                return sum;
            }

            void DFS(int v)
            {
                _marked[v] = true;
                foreach (var w in _adj[v])
                {
                    if (!_marked[w])
                    {
                        _sum[w] = _sum[v] + _adj.Length - _sz[w] - _sz[w];
                        DFS(w);
                    }
                }
            }
        }
    }

    /* time limit exceeded
    public class Solution
    {
        public int[] SumOfDistancesInTree(int N, int[][] edges)
        {
            var g = new Graph(N, edges);
            return Enumerable.Range(0, N).Select(v => g.SumDistance(v)).ToArray();
        }

        class Graph
        {
            readonly List<int>[] _adj;
            public int V { get; private set; }
            public IEnumerable<int> Adj(int v) => _adj[v];

            public Graph(int N, int[][] edges)
            {
                V = N;
                _adj = new List<int>[V];
                foreach (var i in Enumerable.Range(0, V)) _adj[i] = new List<int>();
                foreach (var edge in edges)
                {
                    var v = edge[0];
                    var w = edge[1];
                    _adj[v].Add(w);
                    _adj[w].Add(v);
                }
            }

            public int SumDistance(int source)
            {
                Span<bool> marked = stackalloc bool[V];
                var sum = 0;
                var queue = new Queue<int>(V);
                queue.Enqueue(source);
                var dist = 0;
                while (queue.Count != 0)
                {
                    var count = queue.Count;
                    sum += count * dist;
                    dist += 1;
                    while (count != 0)
                    {
                        var v = queue.Dequeue();
                        marked[v] = true;
                        foreach (var w in _adj[v])
                        {
                            if (!marked[w]) queue.Enqueue(w);
                        }
                        count -= 1;
                    }
                }
                return sum;
            }
        }
    } */
}