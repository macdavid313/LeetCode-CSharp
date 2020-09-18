/*
 * File: 207CourseSchedule.cs
 * Project: Graph
 * Created Date: Friday, 18th September 2020 9:20:11 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 104 ms, faster than 99.23% of C# online submissions for Course Schedule.
 * Memory Usage: 29.6 MB, less than 71.14% of C# online submissions for Course Schedule.
 * -----
 * Last Modified: Friday, 18th September 2020 9:38:19 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseSchedule
{
    public class Solution
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var g = new Graph(numCourses, prerequisites);
            var hasCycle = new CycleDetect(g).HasCycle;
            return !hasCycle;
        }

        class Graph
        {
            readonly List<int>[] adj;
            public int V { get; private set; }
            public List<int>[] Adj { get => adj; }

            public Graph(int numCourses, int[][] prerequisites)
            {
                V = numCourses;
                adj = new List<int>[V];
                foreach (var i in Enumerable.Range(0, V)) adj[i] = new List<int>();
                foreach (var edge in prerequisites)
                {
                    var p = edge[1];
                    var q = edge[0];
                    adj[p].Add(q);
                }
            }
        }

        class CycleDetect
        {
            readonly Graph g;
            public bool HasCycle { get; private set; }

            public CycleDetect(Graph g)
            {
                this.g = g;
                Span<bool> marked = stackalloc bool[g.V];
                Span<bool> onStack = stackalloc bool[g.V];
                HasCycle = false;
                foreach (var v in Enumerable.Range(0, g.V))
                {
                    if (!marked[v]) DFS(v, marked, onStack);
                    if (HasCycle) return;
                }
            }

            void DFS(int v, Span<bool> marked, Span<bool> onStack)
            {
                marked[v] = true;
                onStack[v] = true;
                foreach (var w in g.Adj[v])
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
            }
        }
    }
}