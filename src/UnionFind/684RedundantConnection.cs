/*
 * File: 684RedundantConnection.cs
 * Project: UnionFind
 * Created Date: Sunday, 23rd August 2020 7:46:16 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 304 ms, faster than 27.91% of C# online submissions for Redundant Connection.
 * Memory Usage: 31.1 MB, less than 84.88% of C# online submissions for Redundant Connection.
 * Copyright (c) David Gu 2020
 */


namespace RedundantConnection
{
    public class Solution
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            if (edges.Length == 1) return new int[0];
            var uf = new UF(edges.Length);
            foreach (var edge in edges)
            {
                uf.Union(edge[0], edge[1]);
            }
            return uf.GetRedundantConnection();
        }
    }

    class UF
    {
        readonly int[] id;
        readonly int[] sz;

        int u, v;

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
            int pRoot = Find(p - 1);
            int qRoot = Find(q - 1);
            if (pRoot == qRoot)
            {
                u = p;
                v = q;
            }
            else
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

        public int[] GetRedundantConnection()
        {
            return new int[2] { u, v };
        }
    }
}