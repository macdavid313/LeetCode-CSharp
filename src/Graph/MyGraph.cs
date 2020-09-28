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

using MyQueue;

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

    public class DepthFirstOrder
    {
        readonly bool[] marked;
        readonly Queue<int> pre;
        readonly Queue<int> post;
        readonly Stack<int> reversePost;

        public IEnumerable<int> PreOrder { get => pre; }

        public IEnumerable<int> PostOrder { get => post; }

        public IEnumerable<int> ReversePostOrder { get => reversePost; }
        public DepthFirstOrder(IGraph g)
        {
            marked = new bool[g.V];
            pre = new Queue<int>(g.V);
            post = new Queue<int>(g.V);
            reversePost = new Stack<int>(g.V);
            foreach (var v in Enumerable.Range(0, g.V).Where(v => !marked[v]))
            {
                DFS(g, v);
            }
        }

        void DFS(IGraph g, int v)
        {
            marked[v] = true;
            pre.Enqueue(v);
            foreach (var w in g.Adj(v).Where(w => !marked[w]))
            {
                DFS(g, w);
            }
            post.Enqueue(v);
            reversePost.Push(v);
        }
    }

    public class Topological
    {
        readonly IEnumerable<int> order;

        public IEnumerable<int> Order { get; }

        public bool IsDAG { get => order is object; }

        public Topological(DirectedGraph g)
        {
            var directedCycleDetect = new DirectedCycleDetect(g);
            if (!directedCycleDetect.HasCycle)
            {
                var dfsOrder = new DepthFirstOrder(g);
                order = dfsOrder.ReversePostOrder;
            }
        }
    }

    public class KosarajuSharirScc
    {
        readonly bool[] marked;
        readonly int[] id;
        readonly int count;

        public int Count { get => count; }

        public KosarajuSharirScc(DirectedGraph g)
        {
            marked = new bool[g.V];
            id = new int[g.V];
            var order = new DepthFirstOrder(g);
            foreach (var v in order.ReversePostOrder)
            {
                if (!marked[v])
                {
                    DFS(g, v);
                    count += 1;
                }
            }
        }

        void DFS(DirectedGraph g, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (var w in g.Adj(v).Where(w => !marked[w]))
            {
                DFS(g, w);
            }
        }
    }

    public readonly struct Edge : IComparable<Edge>, IEquatable<Edge>
    {
        readonly int _v;
        readonly int _w;
        readonly double _weight;

        public readonly double Weight { get => _weight; }

        public static Comparer<Edge> DefaultComparer
        {
            get => Comparer<Edge>.Create(new Comparison<Edge>((e1, e2) => e1.Weight.CompareTo(e2.Weight)));
        }

        public Edge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            _weight = weight;
        }

        int IComparable<Edge>.CompareTo(Edge other) => Weight.CompareTo(other.Weight);

        public void Deconstruct(out int v, out int w, out double weight)
        {
            v = _v;
            w = _w;
            weight = _weight;
        }

        public bool Equals(Edge other)
        {
            (var v2, var w2, var weight2) = other;
            if (_weight != weight2) return false;
            return (_v == v2 && _w == w2) || (_v == w2 && _w == v2);
        }

        public override string ToString() => string.Format("<Edge {0} -> {1}, {2}>", _v, _w, _weight);

        public override bool Equals(object obj) => obj is Edge edge && Equals(edge);

        public override int GetHashCode() => (_v, _w, _weight).GetHashCode();

        public static bool operator ==(Edge left, Edge right) => left.Equals(right);

        public static bool operator !=(Edge left, Edge right) => !(left == right);
    }

    public class EdgeWeightedGraph
    {
        readonly int _V;
        int _E;
        readonly List<Edge>[] _adj;

        public int V { get => _V; }
        public int E { get => _E; }

        public EdgeWeightedGraph(int v)
        {
            _V = v;
            _E = 0;
            _adj = new List<Edge>[V];
            foreach (var i in Enumerable.Range(0, V))
            {
                _adj[i] = new List<Edge>();
            }
        }

        public void AddEdge(Edge e)
        {
            (var v, var w, var weight) = e;
            _adj[v].Add(e);
            _adj[w].Add(new Edge(w, v, weight));
            _E += 1;
        }

        public IEnumerable<Edge> Adj(int v) => _adj[v];

        public IEnumerable<Edge> Edges
        {
            get
            {
                foreach (var v in Enumerable.Range(0, V))
                {
                    foreach (var edge in _adj[v])
                    {
                        (var _, var w, var _) = edge;
                        if (w > v) yield return edge;
                    }
                }
            }
        }
    }

    interface IMinimumSpanningTree
    {
        IEnumerable<Edge> Edges { get; }
        double Weight { get; }
    }

    public class PrimLazyMST : IMinimumSpanningTree
    {
        readonly Queue<Edge> _mst;
        readonly double _weight;

        public IEnumerable<Edge> Edges { get => _mst; }
        public double Weight { get => _weight; }

        public PrimLazyMST(EdgeWeightedGraph g)
        {
            g = g ?? throw new ArgumentNullException(nameof(g));
            var marked = new bool[g.V];
            _mst = new Queue<Edge>(g.V);
            _weight = 0.0;
            var minPQ = PriorityQueue<Edge>.MinPQ(g.V, Edge.DefaultComparer);
            Visit(g, 0, marked, minPQ);
            while (!minPQ.IsEmpty)
            {
                var edge = minPQ.Dequeue();
                (var v, var w, var weight) = edge;
                if (marked[v] && marked[w]) continue;
                _mst.Enqueue(edge);
                _weight += weight;
                if (!marked[v]) Visit(g, v, marked, minPQ);
                if (!marked[w]) Visit(g, w, marked, minPQ);
            }
        }

        void Visit(EdgeWeightedGraph g, int v, bool[] marked, PriorityQueue<Edge> minPQ)
        {
            marked[v] = true;
            foreach (var edge in g.Adj(v))
            {
                (var _, var w, var _) = edge;
                if (!marked[w]) minPQ.Enqueue(edge);
            }
        }
    }

    public class PrimEagerMST : IMinimumSpanningTree
    {
        readonly int[] _edgeTo;
        readonly double[] _distTo;

        public IEnumerable<Edge> Edges
        {
            get
            {
                var marked = new bool[_edgeTo.Length];
                var edges = new List<Edge>(_edgeTo.Length - 1);
                CollectEdgesDFS(0, marked, edges);
                return edges;
            }
        }

        void CollectEdgesDFS(int v, bool[] marked, List<Edge> edges)
        {
            marked[v] = true;
            foreach (var w in Enumerable.Range(0, _edgeTo.Length).Where(w => w != v && !marked[w] && _edgeTo[w] == v))
            {
                edges.Add(new Edge(v, w, _distTo[w]));
                CollectEdgesDFS(w, marked, edges);
            }
        }

        public double Weight { get => Edges.Select(edge => edge.Weight).Sum(); }

        public PrimEagerMST(EdgeWeightedGraph g)
        {
            var marked = new bool[g.V];
            _edgeTo = new int[g.V];
            _distTo = Enumerable.Repeat(double.PositiveInfinity, g.V).ToArray();

            var indexMinPQ = IndexPriorityQueue<double>.IndexMinPQ(g.V);
            _distTo[0] = 0.0;
            indexMinPQ.Enqueue(0, 0.0);
            while (!indexMinPQ.IsEmpty)
            {
                (var v, var _) = indexMinPQ.Dequeue();
                Visit(g, v, marked, indexMinPQ);
            }

        }

        void Visit(EdgeWeightedGraph g, int v, bool[] marked, IndexPriorityQueue<double> indexMinPQ)
        {
            marked[v] = true;
            foreach (var edge in g.Adj(v))
            {
                (var _, var w, var weight) = edge;
                if (marked[w]) continue;
                if (weight < _distTo[w])
                {
                    _edgeTo[w] = v;
                    _distTo[w] = weight;
                    if (indexMinPQ.Contains(w)) indexMinPQ.DecreaseKey(w, weight);
                    else indexMinPQ.Enqueue(w, weight);
                }
            }
        }
    }

    public class KruskalMST : IMinimumSpanningTree
    {
        readonly Edge[] _mst;
        readonly double _weight;

        public IEnumerable<Edge> Edges { get => _mst; }

        public double Weight { get => _weight; }

        public KruskalMST(EdgeWeightedGraph g)
        {
            g = g ?? throw new ArgumentNullException(nameof(g));
            _mst = new Edge[g.V - 1];
            _weight = 0.0;
            var fill = 0;

            var uf = new UF(g.V);
            foreach (var edge in g.Edges.OrderBy(edge => edge.Weight))
            {
                if (fill == _mst.Length) return;

                (var v, var w, var weight) = edge;
                if (uf.Connected(v, w)) continue;
                uf.Union(v, w);
                _mst[fill++] = edge;
                _weight += weight;
            }
        }

        class UF
        {
            readonly int[] _id;
            readonly int[] _rank;

            public UF(int n)
            {
                _id = new int[n];
                _rank = new int[n];
                foreach (var i in Enumerable.Range(0, n))
                {
                    _id[i] = i;
                    _rank[i] = 1;
                }
            }

            public void Union(int v, int w)
            {
                v = Find(v);
                w = Find(w);
                if (v != w)
                {
                    if (_rank[v] < _rank[w])
                    {
                        _id[v] = w;
                        _rank[w] += 1;
                    }
                    else
                    {
                        _id[w] = v;
                        _rank[v] += 1;
                    }
                }
            }

            public int Find(int v)
            {
                if (_id[v] != v)
                    _id[v] = Find(_id[v]);
                return _id[v];
            }

            public bool Connected(int v, int w) => Find(v) == Find(w);
        }
    }

    public class EdgeWeightedDirectedGraph
    {
        readonly int _V;
        int _E;
        readonly List<Edge>[] _adj;

        public int V { get => _V; }

        public int E { get => _E; }

        public List<Edge> Adj(int v) => _adj[v];

        public EdgeWeightedDirectedGraph(int V)
        {
            _V = V;
            _E = 0;
            _adj = new List<Edge>[_V];
        }

        public void AddEdge(Edge edge)
        {
            (var from, var _, var _) = edge;
            _adj[from].Add(edge);
            _E += 1;
        }

        public IEnumerable<Edge> Edges
        {
            get
            {
                foreach (var from in Enumerable.Range(0, _V))
                {
                    foreach (var edge in _adj[from]) yield return edge;
                }
            }
        }
    }

    interface IShortestPath
    {
        double DistTo(int v);
        bool HasPathTo(int v);
        IEnumerable<Edge> PathTo(int v);
    }

    public class DijkstraShortestPath : IShortestPath
    {
        readonly EdgeWeightedDirectedGraph _g;
        readonly Edge[] _edgeTo;
        readonly double[] _distTo;
        readonly IndexPriorityQueue<double> _pq;

        public double DistTo(int v) => _distTo[v];
        public bool HasPathTo(int v) => _edgeTo[v] != null;
        public IEnumerable<Edge> PathTo(int v)
        {
            while (_edgeTo[v] is Edge edge)
            {
                (var from, var _, var _) = edge;
                yield return edge;
                v = from;
            }
        }

        public DijkstraShortestPath(EdgeWeightedDirectedGraph g, int s)
        {
            _g = g;
            _edgeTo = new Edge[g.V];
            _distTo = new double[g.V];
            Array.Fill(_distTo, double.PositiveInfinity);
            _distTo[s] = 0.0;
            _pq = IndexPriorityQueue<double>.IndexMinPQ(g.V);

            _pq.Enqueue(s, 0.0);
            while (!_pq.IsEmpty)
            {
                (var v, var _) = _pq.Dequeue();
                Relax(v);
            }
        }

        void Relax(int v)
        {
            foreach (var edge in _g.Adj(v))
            {
                (var _, var w, var weight) = edge;
                var newWeight = weight + _distTo[v];
                if (_distTo[w] > newWeight)
                {
                    _distTo[w] = newWeight;
                    _edgeTo[w] = edge;
                    if (_pq.Contains(w)) _pq.ChangeKey(w, _distTo[w]);
                    else _pq.Enqueue(w, _distTo[w]);
                }
            }
        }
    }
}