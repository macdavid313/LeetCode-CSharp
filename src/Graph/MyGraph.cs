/*
 * File: MyGraph.cs
 * Project: Graph
 * Created Date: Wednesday, 16th September 2020 8:05:21 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


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
}