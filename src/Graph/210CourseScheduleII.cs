/*
 * File: 210CourseScheduleII.cs
 * Project: Graph
 * Created Date: Friday, 18th September 2020 8:11:36 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 252 ms, faster than 98.17% of C# online submissions for Course Schedule II.
 * Memory Usage: 34.1 MB, less than 72.91% of C# online submissions for Course Schedule II.
 * -----
 * Last Modified: Friday, 18th September 2020 9:14:19 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseScheduleII
{
    public class Solution
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var g = new Graph(numCourses, prerequisites);
            return g.TopologicalOrder;
        }
    }

    class Graph
    {
        readonly List<int>[] adj;
        readonly Stack<int> reversePostOrder;

        public int V { get; private set; }
        public bool HasCycle { get; private set; }

        public int[] TopologicalOrder { get => HasCycle ? Array.Empty<int>() : reversePostOrder.ToArray(); }

        public Graph(int v, int[][] edges)
        {
            adj = new List<int>[v];
            foreach (var i in Enumerable.Range(0, v)) adj[i] = new List<int>();
            V = v;
            foreach (var edge in edges)
            {
                var p = edge[1];
                var q = edge[0];
                adj[p].Add(q);
            }
            reversePostOrder = new Stack<int>(V);
            Span<bool> marked = stackalloc bool[V];
            Span<bool> onStack = stackalloc bool[V];
            DFS(marked, onStack);
        }

        void DFS(Span<bool> marked, Span<bool> onStack)
        {
            for (var v = 0; v < V; v++)
            {
                if (!marked[v])
                {
                    DFS(v, marked, onStack);
                    if (HasCycle) return;
                }
            }
        }

        void DFS(int v, Span<bool> marked, Span<bool> onStack)
        {
            marked[v] = true;
            onStack[v] = true;
            foreach (var w in adj[v])
            {
                if (HasCycle) return;
                if (onStack[w])
                {
                    HasCycle = true;
                    return;
                }
                else if (!marked[w]) DFS(w, marked, onStack);
            }
            onStack[v] = false;
            reversePostOrder.Push(v);
        }
    }
}