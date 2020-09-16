/*
 * File: MyGraph.cs
 * Project: Graph
 * Created Date: Wednesday, 16th September 2020 8:05:21 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace MyGraph
{
    public interface IGraph
    {
        int V { get; } // number of vectices
        int E { get; } // number of edges
        void AddEdge(int v, int w);
        IEnumerable<int> Adj(int v);
    }

    public class Graph : IGraph
    {
        readonly HashSet<int>[] adj;

        public Graph(int v)
        {
            V = v;
            E = 0;
            adj = new HashSet<int>[V];
            Enumerable.Range(0, V).ToList().ForEach(i => adj[i] = new HashSet<int>());
        }

        public int V { get; private set; }

        public int E { get; private set; }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
            E += 1;
        }

        public IEnumerable<int> Adj(int v) => adj[v];

        public override string ToString() => $"<Graph, {V} Vertices, {E} edges>";

        public static int Degree(Graph g, int v) => g.Adj(v).Count();

        public static int MaxDegree(Graph g)
        {
            int max = int.MinValue;
            Enumerable.Range(0, g.V).ToList().ForEach(v =>
            {
                var degree = g.Adj(v).Count();
                if (max < degree) max = degree;
            });
            return max;
        }
    }

    public class DirectedGraph : IGraph
    {
        readonly HashSet<int>[] adj;

        public int V { get; private set; }

        public int E { get; private set; }

        public DirectedGraph(int v)
        {
            V = v;
            E = 0;
            adj = new HashSet<int>[V];
            foreach (var i in Enumerable.Range(0, V))
            {
                adj[i] = new HashSet<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            E += 1;
        }

        public IEnumerable<int> Adj(int v) => adj[v];

        public DirectedGraph Reverse()
        {
            var rg = new DirectedGraph(V);
            foreach (var v in Enumerable.Range(0, V))
            {
                foreach (var w in adj[v])
                {
                    rg.AddEdge(w, v);
                }
            }
            return rg;
        }
    }

    public class DepthFirstPaths
    {
        readonly bool[] marked;
        readonly int[] edgeTo;
        readonly int s;

        public DepthFirstPaths(IGraph g, int s)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            this.s = s;
            DFS(g, s);
        }

        void DFS(IGraph g, int v)
        {
            marked[v] = true;
            foreach (var w in g.Adj(v).Where(w => !marked[w]))
            {
                edgeTo[w] = v;
                DFS(g, w);
            }
        }

        public bool HasPathTo(int v) => marked[v];

        public IEnumerable<int> PathTo(int v)
        {
            if (HasPathTo(v))
            {
                var paths = new Stack<int>();
                while (v != s)
                {
                    paths.Push(v);
                    v = edgeTo[v];
                }
                paths.Push(s);
                return paths;
            }
            else return null;
        }
    }

    public class BreadthFirstPaths
    {
        readonly bool[] marked;
        readonly int[] edgeTo;
        readonly int s;

        public BreadthFirstPaths(IGraph g, int s)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            this.s = s;
            BFS(g, s);
        }

        void BFS(IGraph g, int s)
        {
            var queue = new Queue<int>();
            queue.Enqueue(s);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                while (count != 0)
                {
                    var v = queue.Dequeue();
                    foreach (var w in g.Adj(v).Where(w => !marked[w]))
                    {
                        marked[w] = true;
                        edgeTo[w] = v;
                        queue.Enqueue(w);
                    }
                    count -= 1;
                }
            }
        }

        public bool HasPathTo(int v) => marked[v];

        public IEnumerable<int> PathTo(int v)
        {
            if (HasPathTo(v))
            {
                var paths = new Stack<int>();
                while (v != s)
                {
                    paths.Push(v);
                    v = edgeTo[v];
                }
                paths.Push(s);
                return paths;
            }
            else return null;
        }
    }

    public class ConnectedComponents
    {
        readonly bool[] marked;
        readonly int[] id;
        readonly int count;

        public int Count { get => count; }

        public ConnectedComponents(IGraph g)
        {
            marked = new bool[g.V];
            id = new int[g.V];
            count = 0;
            foreach (var v in Enumerable.Range(0, g.V))
            {
                if (!marked[v])
                {
                    DFS(g, v);
                    count += 1; // iterate to the next cc
                }
            }
        }

        void DFS(IGraph g, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (var w in g.Adj(v).Where(w => !marked[w]))
            {
                DFS(g, w);
            }
        }

        public bool Connected(int v, int w) => id[v] == id[w];

        public int ID(int v) => id[v];
    }

    public class CycleDetect
    {
        readonly bool[] marked;

        public bool HasCycle { get; private set; }

        public CycleDetect(IGraph g)
        {
            marked = new bool[g.V];
            foreach (var v in Enumerable.Range(0, g.V))
            {
                if (!marked[v])
                {
                    if (DFS(g, v, v))
                    {
                        HasCycle = true;
                        return;
                    }
                }
            }
            HasCycle = false;
        }

        bool DFS(IGraph g, int v, int source)
        {
            marked[v] = true;
            if (v == source) return true;
            foreach (var w in g.Adj(v).Where(w => !marked[w]))
            {
                if (DFS(g, w, source)) return true;
            }
            return false;
        }
    }

    public class DirectedCycleDetect
    {
        readonly bool[] marked;
        readonly bool[] onStack;
        readonly int[] edgeTo;

        Stack<int> cycle;

        public bool HasCycle { get => cycle is object; }

        public IEnumerable<int> Cycle { get => cycle; }

        public DirectedCycleDetect(DirectedGraph g)
        {
            marked = new bool[g.V];
            onStack = new bool[g.V];
            edgeTo = new int[g.V];
            cycle = null;
            foreach (var v in Enumerable.Range(0, g.V).Where(v => !marked[v]))
            {
                DFS(g, v);
            }
        }

        void DFS(DirectedGraph g, int v)
        {
            marked[v] = true;
            onStack[v] = true;
            foreach (var w in g.Adj(v))
            {
                if (HasCycle) return;
                else if (!marked[w])
                {
                    edgeTo[w] = v;
                    DFS(g, w);
                }
                else if (onStack[w])
                {
                    cycle = new Stack<int>();
                    var x = v;
                    while (x != w)
                    {
                        cycle.Push(x);
                        x = edgeTo[x];
                    }
                    cycle.Push(w);
                    cycle.Push(v);
                }
            }
            onStack[v] = false;
        }
    }

}