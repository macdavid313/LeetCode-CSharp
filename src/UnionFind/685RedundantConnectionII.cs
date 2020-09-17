/*
 * File: 685RedundantConnectionII.cs
 * Project: UnionFind
 * Created Date: Thursday, 17th September 2020 9:29:11 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 248 ms, faster than 83.33% of C# online submissions for Redundant Connection II.
 * Memory Usage: 31.8 MB, less than 58.33% of C# online submissions for Redundant Connection II.
 * -----
 * Last Modified: Thursday, 17th September 2020 10:05:49 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Linq;

namespace RedundantConnectionII
{
    public class Solution
    {
        public int[] FindRedundantDirectedConnection(int[][] edges)
        {
            int n = edges.Length;
            Span<int> parent = stackalloc int[n + 1];
            foreach (var i in Enumerable.Range(0, n + 1)) parent[i] = i;
            var uf = new SpanUF(stackalloc int[n + 1], stackalloc int[n + 1]);
            var conflict = -1;
            var cycle = -1;
            foreach (var i in Enumerable.Range(0, n))
            {
                var p = edges[i][0];
                var q = edges[i][1];
                if (parent[q] != q)
                {
                    conflict = i;
                }
                else
                {
                    parent[q] = p;
                    if (uf.Find(p) == uf.Find(q)) cycle = i;
                    else uf.Union(p, q);
                }
            }
            if (conflict == -1)
            {
                return edges[cycle];
            }
            else
            {
                var conflictEdge = edges[conflict];
                if (cycle == -1)
                {
                    return conflictEdge;
                }
                else
                {
                    return new int[] { parent[conflictEdge[1]], conflictEdge[1] };
                }
            }
        }
    }

    ref struct SpanUF
    {
        readonly Span<int> id;
        readonly Span<int> sz;

        public SpanUF(Span<int> id, Span<int> sz)
        {
            this.id = id;
            this.sz = sz;
            foreach (var i in Enumerable.Range(0, id.Length))
            {
                id[i] = i;
                sz[i] = 1;
            }
        }

        public void Union(int p, int q)
        {
            p = Root(p);
            q = Root(q);
            if (p != q)
            {
                if (sz[p] < sz[q])
                {
                    id[p] = q;
                    sz[q] = sz[p] + sz[q];
                }
                else
                {
                    id[q] = p;
                    sz[p] = sz[p] + sz[q];
                }
            }
        }

        int Root(int p)
        {
            if (id[p] != p) id[p] = Root(id[p]);
            return id[p];
        }

        public int Find(int p) => Root(p);
    }
}