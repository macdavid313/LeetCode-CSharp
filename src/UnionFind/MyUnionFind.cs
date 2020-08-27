/*
 * File: MyUnionFind.cs
 * Project: UnionFind
 * Created Date: Thursday, 27th August 2020 10:18:20 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;

namespace MyUnionFind
{
    public class UF
    {
        readonly int[] id;
        readonly int[] sz;
        public int Count { get; private set; }

        public UF(int n)
        {
            id = new int[n];
            sz = new int[n];
            for (var i = 0; i < n; i++)
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

        int Find(int i)
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

    public ref struct SpanUF
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