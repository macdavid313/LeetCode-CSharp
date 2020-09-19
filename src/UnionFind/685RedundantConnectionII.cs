/*
 * File: 685RedundantConnectionII.cs
 * Project: UnionFind
 * Created Date: Thursday, 17th September 2020 9:29:11 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 240 ms, faster than 86.36% of C# online submissions for Redundant Connection II.
 * Memory Usage: 31.3 MB, less than 100.00% of C# online submissions for Redundant Connection II.
 * -----
 * Last Modified: Saturday, 19th September 2020 4:23:19 pm
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
        readonly Span<int> rank;

        public SpanUF(Span<int> id, Span<int> rank)
        {
            this.id = id;
            this.rank = rank;
            foreach (var i in Enumerable.Range(0, id.Length))
            {
                id[i] = i;
                rank[i] = 1;
            }
        }

        public void Union(int p, int q)
        {
            p = Root(p);
            q = Root(q);
            if (p != q)
            {
                if (rank[p] < rank[q])
                {
                    id[p] = q;
                    rank[q] += 1;
                }
                else
                {
                    id[q] = p;
                    rank[p] += 1;
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