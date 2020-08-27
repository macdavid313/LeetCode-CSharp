/*
 * File: 547FriendCircles.cs
 * Project: UnionFind
 * Created Date: Sunday, 23rd August 2020 6:40:31 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 116 ms, faster than 86.96% of C# online submissions for Friend Circles.
 * Memory Usage: 27.9 MB, less than 99.52% of C# online submissions for Friend Circles.
 * Copyright (c) David Gu 2020
 */


using System;

namespace FriendCircles
{
    public class Solution
    {
        public int FindCircleNum(int[][] M)
        {
            int n = M.Length;
            if (n <= 1) return n;
            var uf = new SpanUF(stackalloc int[n], stackalloc int[n]);
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (M[i][j] == 1)
                    {
                        uf.Union(i, j);
                    }
                }
            }
            return uf.Count;
        }
    }

    ref struct SpanUF
    {
        readonly Span<int> id;
        readonly Span<int> sz;
        public int Count { get; private set; }

        public SpanUF(Span<int> id, Span<int> sz)
        {
            this.id = id;
            this.sz = sz;
            Count = id.Length;
            for (var i = 0; i < Count; i++)
            {
                id[i] = i;
                sz[i] = 1;
            }
        }

        public void Union(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);
            if (pRoot != qRoot)
            {
                if (sz[pRoot] < sz[qRoot])
                {
                    id[pRoot] = qRoot;
                    sz[qRoot] += sz[pRoot];
                }
                else
                {
                    id[qRoot] = pRoot;
                    sz[pRoot] += sz[qRoot];
                }
                Count -= 1;
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
    }
}