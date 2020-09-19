/*
 * File: 261GraphValidTree.cs
 * Project: UnionFind
 * Created Date: Saturday, 19th September 2020 3:36:59 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 120 ms, faster than 100.00% of C# online submissions for Number of Islands.
 * Memory Usage: 27.5 MB, less than 100.00% of C# online submissions for Number of Islands.
 * -----
 * Last Modified: Saturday, 19th September 2020 3:56:05 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Linq;

namespace GraphValidTree
{
    public class Solution
    {
        public bool ValidTree(int n, int[][] edges)
        {
            var uf = new SpanUF(stackalloc int[n], stackalloc int[n]);
            foreach (var edge in edges)
            {
                if (!uf.Union(edge[0], edge[1])) return false;
            }
            return uf.Count == 1;
        }
    }

    ref struct SpanUF
    {
        readonly Span<int> id;
        readonly Span<int> rank;
        public int Count { get; private set; }

        public SpanUF(Span<int> id, Span<int> rank)
        {
            this.id = id;
            this.rank = rank;
            foreach (var i in Enumerable.Range(0, id.Length))
            {
                this.id[i] = i;
                this.rank[i] = 1;
            }
            Count = id.Length;
        }

        public bool Union(int u, int v)
        {
            u = Root(u);
            v = Root(v);

            if (u == v) return false;
            if (rank[u] < rank[v])
            {
                id[u] = v;
                rank[v] += 1;
            }
            else
            {
                id[v] = u;
                rank[u] += 1;
            }
            Count -= 1;
            return true;
        }

        int Root(int u)
        {
            if (id[u] != u) id[u] = Root(id[u]);
            return id[u];
        }

        public int Find(int u) => Root(u);
    }
}