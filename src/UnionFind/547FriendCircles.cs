/*
 * File: 547FriendCircles.cs
 * Project: UnionFind
 * Created Date: Sunday, 23rd August 2020 6:40:31 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 176 ms, faster than 19.15% of C# online submissions for Friend Circles.
 * Memory Usage: 27.9 MB, less than 100.00% of C# online submissions for Friend Circles.
 * Copyright (c) David Gu 2020
 */


namespace FriendCircles
{
    public class Solution
    {
        public int FindCircleNum(int[][] M)
        {
            int n = M.Length;
            if (n <= 1) return n;
            var uf = new UF(n);
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
            return uf.Count();
        }
    }

    class UF
    {
        readonly int[] id;
        readonly int[] sz;
        int count;

        public UF(int n)
        {
            id = new int[n];
            sz = new int[n];
            count = n;
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
                count -= 1;
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

        public int Count() => count;
    }
}