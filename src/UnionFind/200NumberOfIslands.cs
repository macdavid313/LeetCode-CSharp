/*
 * File: 200NumberOfIslands.cs
 * Project: UnionFind
 * Created Date: Thursday, 27th August 2020 5:53:07 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 100 ms, faster than 98.86% of C# online submissions for Number of Islands.
 * Memory Usage: 27.9 MB, less than 37.96% of C# online submissions for Number of Islands.
 * Copyright (c) David Gu 2020
 */


using System;

namespace NumberOfIslands
{
    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            if (grid is null || grid.Length == 0) return 0;

            var rowCount = grid.Length;
            var colCount = grid[0].Length;
            var n = rowCount * colCount;

            // initialize UF
            Span<int> id = stackalloc int[n];
            Span<int> sz = stackalloc int[n];
            var count = 0;
            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < colCount; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        var idx = i * colCount + j;
                        id[idx] = idx;
                        sz[idx] = 1;
                        count += 1;
                    }
                }
            }
            var uf = new SpanUF(id, sz, count);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < colCount; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        // grid[i][j] = '0'; avoid duplicate Union action
                        var p = i * colCount + j;
                        uf.Union(p, grid, rowCount, colCount);
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

        public SpanUF(Span<int> id, Span<int> sz, int count)
        {
            this.id = id;
            this.sz = sz;
            Count = count;
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

        public void Union(int p, char[][] grid, int rowCount, int colCount)
        {
            var row = p / colCount;
            var col = p % colCount;

            if (row + 1 < rowCount && grid[row + 1][col] == '1')
                Union(p, (row + 1) * colCount + col);

            if (col + 1 < colCount && grid[row][col + 1] == '1')
                Union(p, row * colCount + col + 1);
        }

        public int Find(int i)
        {
            if (id[i] != i)
                id[i] = Find(id[i]);
            return id[i];
        }

        public bool Connected(int p, int q) => Find(p) == Find(q);
    }
}