/*
 * File: 708IsGraphBipartite.cs
 * Project: Graph
 * Created Date: Friday, 2nd October 2020 11:09:56 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 116 ms, faster than 86.76% of C# online submissions for Is Graph Bipartite?.
 * Memory Usage: 29.4 MB, less than 8.09% of C# online submissions for Is Graph Bipartite?.
 * -----
 * Last Modified: Friday, 2nd October 2020 11:38:47 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Linq;

namespace IsGraphBipartite
{
    public class Solution
    {
        public bool IsBipartite(int[][] graph) => new Graph(graph).IsBipartite;

    }

    class Graph
    {
        readonly int _v;
        readonly int[][] _adj;
        public bool IsBipartite { get; private set; }

        public Graph(int[][] adj)
        {
            _v = adj.Length;
            _adj = adj;
            IsBipartite = true;

            Span<bool> marked = stackalloc bool[_v];
            Span<bool> colors = stackalloc bool[_v];
            foreach (var v in Enumerable.Range(0, _v))
            {
                if (!IsBipartite) return;
                if (!marked[v]) DFS(v, marked, colors);
            }
        }

        void DFS(int v, Span<bool> marked, Span<bool> colors)
        {
            if (!IsBipartite) return;
            marked[v] = true;
            foreach (var w in _adj[v])
            {
                if (!marked[w])
                {
                    colors[w] = !colors[v];
                    DFS(w, marked, colors);
                }
                else if (colors[v] == colors[w])
                {
                    IsBipartite = false;
                    return;
                }
            }
        }
    }
}