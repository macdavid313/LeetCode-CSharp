/*
 * File: 684RedundantConnection.cs
 * Project: UnionFind
 * Created Date: Sunday, 23rd August 2020 7:46:16 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 244 ms, faster than 70.09% of C# online submissions for Redundant Connection.
 * Memory Usage: 31 MB, less than 88.89% of C# online submissions for Redundant Connection.
 * Copyright (c) David Gu 2020
 */


using System;

namespace RedundantConnection
{
    public class Solution
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            if (edges.Length == 1) return Array.Empty<int>();
            Span<int> id = stackalloc int[edges.Length];
            Span<int> rank = stackalloc int[edges.Length];
            var uf = new SpanUF(id, rank);
            foreach (var edge in edges)
            {
                uf.Union(edge[0] - 1, edge[1] - 1);
            }
            return uf.GetRedundantConnection();
        }
    }

    ref struct SpanUF
    {
        readonly Span<int> id;
        readonly Span<int> rank;
        public int Count { get; private set; }

        int u, v;

        public SpanUF(Span<int> id, Span<int> rank)
        {
            this.id = id;
            this.rank = rank;
            Count = id.Length;
            for (var i = 0; i < Count; i++)
            {
                id[i] = i;
                rank[i] = 1;
            }
            u = 0;
            v = 0;
        }

        public void Union(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);
            if (pRoot != qRoot)
            {
                if (rank[pRoot] < rank[qRoot])
                {
                    id[pRoot] = qRoot;
                    rank[qRoot] += 1;
                }
                else
                {
                    id[qRoot] = pRoot;
                    rank[pRoot] += 1;
                }
                Count -= 1;
            }
            else
            {
                u = p;
                v = q;
            }
        }

        public int Find(int i)
        {
            while (id[i] != i)
            {
                id[i] = id[id[i]];
                i = id[i];
            }
            return i;
        }

        public bool Connected(int p, int q) => Find(p) == Find(q);

        public int[] GetRedundantConnection() => new int[2] { u + 1, v + 1 };
    }
}