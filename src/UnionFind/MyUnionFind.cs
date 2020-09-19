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
        readonly int[] rank;
        public int Count { get; private set; }

        public UF(int n)
        {
            if (n > 0)
            {
                id = new int[n];
                rank = new int[n];
                Count = n;
                for (var i = 0; i < n; i++)
                {
                    id[i] = i;
                    rank[i] = 1;
                }
            }
            else throw new ArgumentException(null, nameof(n));
        }

        public void Union(int p, int q)
        {
            p = Find(p);
            q = Find(q);
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
                Count -= 1;
            }
        }

        int Root(int i)
        {
            if (id[i] != i) id[i] = Root(id[i]);
            return id[i];
        }

        public int Find(int i) => Root(i);

        public bool Connected(int p, int q) => Find(p) == Find(q);
    }

    public ref struct SpanUF
    {
        readonly Span<int> id;
        readonly Span<int> rank;
        public int Count { get; private set; }

        public SpanUF(Span<int> id, Span<int> rank)
        {
            if (id.Length > 0)
            {
                this.id = id;
                this.rank = rank;
                Count = id.Length;
                for (var i = 0; i < Count; i++)
                {
                    id[i] = i;
                    rank[i] = 1;
                }
            }
            else throw new ArgumentException(null, nameof(id));
        }

        public void Union(int p, int q)
        {
            p = Find(p);
            q = Find(q);
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
                Count -= 1;
            }
        }

        int Root(int i)
        {
            if (id[i] != i) id[i] = Root(id[i]);
            return id[i];
        }

        public int Find(int i) => Root(i);

        public bool Connected(int p, int q) => Find(p) == Find(q);
    }
}