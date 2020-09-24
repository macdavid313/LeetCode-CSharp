/*
 * File: MyGraphTest.cs
 * Project: GraphTests
 * Created Date: Wednesday, 16th September 2020 3:21:16 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System.Linq;
using Xunit;
using MyGraph;
using System.Collections.Generic;

namespace GraphTests
{
    public class DepthFirstPathsTest
    {
        [Fact]
        public void TestCase1()
        {
            var g = new Graph(6);
            g.AddEdge(0, 5);
            g.AddEdge(2, 4);
            g.AddEdge(2, 3);
            g.AddEdge(1, 2);
            g.AddEdge(0, 1);
            g.AddEdge(3, 4);
            g.AddEdge(3, 5);
            g.AddEdge(0, 2);
            var dfsPaths = new DepthFirstPaths(g, 0);
            var expected = new int[] { 0, 5, 3 };
            var actual = dfsPaths.PathTo(3).ToArray();
            Assert.Equal(expected, actual);
        }
    }

    public class BreadthFirstPathsTest
    {
        [Fact]
        public void TestCase1()
        {
            var g = new Graph(6);
            g.AddEdge(0, 5);
            g.AddEdge(2, 4);
            g.AddEdge(2, 3);
            g.AddEdge(1, 2);
            g.AddEdge(0, 1);
            g.AddEdge(3, 4);
            g.AddEdge(3, 5);
            g.AddEdge(0, 2);
            var bfsPaths = new BreadthFirstPaths(g, 0);
            var expected = new int[] { 0, 2, 4 };
            var actual = bfsPaths.PathTo(4).ToArray();
            Assert.Equal(expected, actual);
        }
    }

    public class ConnectedComponentsTest
    {
        [Fact]
        public void TestCase1()
        {
            var g = new Graph(13);
            g.AddEdge(0, 6);
            g.AddEdge(0, 2);
            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(3, 5);
            g.AddEdge(3, 4);
            g.AddEdge(4, 5);
            g.AddEdge(4, 6);
            g.AddEdge(7, 8);
            g.AddEdge(9, 11);
            g.AddEdge(9, 10);
            g.AddEdge(9, 12);
            g.AddEdge(11, 12);
            var cc = new ConnectedComponents(g);
            var expected = new int[][]
            {
                new int[] { 0, 1, 2, 3, 4, 5, 6 },
                new int[] { 7, 8 },
                new int[] { 9, 10, 11, 12 }
            };
            var actual = new int[3][];
            Assert.Equal(3, cc.Count);
            var ids = new List<int>[cc.Count];
            foreach (var v in Enumerable.Range(0, g.V))
            {
                var id = cc.ID(v);
                if (ids[id] is null)
                {
                    ids[id] = new List<int>() { v };
                }
                else
                {
                    ids[id].Add(v);
                }
            }
            foreach (var i in Enumerable.Range(0, cc.Count))
            {
                actual[i] = ids[i].ToArray();
            }
            Assert.Equal(expected, actual);
        }
    }

    public class CycleDetectTest
    {
        [Fact]
        public void TestCase1()
        {
            var g = new Graph(13);
            g.AddEdge(0, 6);
            g.AddEdge(0, 2);
            g.AddEdge(0, 1);
            g.AddEdge(0, 5);
            g.AddEdge(3, 5);
            g.AddEdge(3, 4);
            g.AddEdge(4, 5);
            g.AddEdge(4, 6);
            g.AddEdge(7, 8);
            g.AddEdge(9, 11);
            g.AddEdge(9, 10);
            g.AddEdge(9, 12);
            g.AddEdge(11, 12);
            var cycleDetect = new CycleDetect(g);
            Assert.True(cycleDetect.HasCycle);
        }
    }

    public class DirectedCycleDetectTest
    {
        [Fact]
        public void TestCase1()
        {
            var g = new DirectedGraph(6);
            g.AddEdge(0, 5);
            g.AddEdge(3, 5);
            g.AddEdge(5, 4);
            g.AddEdge(4, 3);
            var cycleDetect = new DirectedCycleDetect(g);
            var expectedCycle = new int[] { 3, 5, 4, 3 };
            var actualCycle = cycleDetect.Cycle.ToArray();
            Assert.True(cycleDetect.HasCycle);
            Assert.Equal(expectedCycle, actualCycle);
        }
    }

    static class TinyEdgeDirectedGraph
    {
        static readonly EdgeWeightedGraph _g;

        public static EdgeWeightedGraph G { get => _g; }

        static TinyEdgeDirectedGraph()
        {
            _g = new EdgeWeightedGraph(8);
            _g.AddEdge(new Edge(4, 5, 0.35));
            _g.AddEdge(new Edge(4, 7, 0.37));
            _g.AddEdge(new Edge(5, 7, 0.28));
            _g.AddEdge(new Edge(0, 7, 0.16));
            _g.AddEdge(new Edge(1, 5, 0.32));
            _g.AddEdge(new Edge(0, 4, 0.38));
            _g.AddEdge(new Edge(2, 3, 0.17));
            _g.AddEdge(new Edge(1, 7, 0.19));
            _g.AddEdge(new Edge(0, 2, 0.26));
            _g.AddEdge(new Edge(1, 2, 0.36));
            _g.AddEdge(new Edge(1, 3, 0.29));
            _g.AddEdge(new Edge(2, 7, 0.34));
            _g.AddEdge(new Edge(6, 2, 0.40));
            _g.AddEdge(new Edge(3, 6, 0.52));
            _g.AddEdge(new Edge(6, 0, 0.58));
            _g.AddEdge(new Edge(6, 4, 0.93));
        }
    }

    public class PrimMSTTest
    {
        readonly EdgeWeightedGraph g = TinyEdgeDirectedGraph.G;
        readonly Edge[] expectedEdges = new Edge[]
            {
                new Edge(0, 7, 0.16),
                new Edge(2, 3, 0.17),
                new Edge(1, 7, 0.19),
                new Edge(0, 2, 0.26),
                new Edge(5, 7, 0.28),
                new Edge(4, 5, 0.35),
                new Edge(6, 2, 0.40),
            };
        readonly double expectedWeight = 1.81;

        [Fact]
        public void TestLazyCase()
        {
            var primLazy = new PrimLazyMST(g);
            var actualEdges = primLazy.Edges.ToArray();
            var actualWeight = primLazy.Weight;
            Assert.Equal(g.V - 1, actualEdges.Length);
            foreach (var actualEdge in actualEdges) Assert.Contains(actualEdge, expectedEdges);
            Assert.Equal(expectedWeight, actualWeight);
        }

        [Fact]
        public void TestEagerCase()
        {
            var primEager = new PrimEagerMST(g);
            var actualEdges = primEager.Edges.ToArray();
            var actualWeight = primEager.Weight;
            Assert.Equal(g.V - 1, actualEdges.Length);
            foreach (var actualEdge in actualEdges) Assert.Contains(actualEdge, expectedEdges);
            Assert.Equal(expectedWeight, actualWeight);
        }
    }

    public class KurskalMSTTest
    {
        readonly EdgeWeightedGraph g = TinyEdgeDirectedGraph.G;
        readonly Edge[] expectedEdges = new Edge[]
            {
                new Edge(0, 7, 0.16),
                new Edge(2, 3, 0.17),
                new Edge(1, 7, 0.19),
                new Edge(0, 2, 0.26),
                new Edge(5, 7, 0.28),
                new Edge(4, 5, 0.35),
                new Edge(6, 2, 0.40),
            };
        readonly double expectedWeight = 1.81;

        [Fact]
        public void TestCase1()
        {
            var kruskalMST = new KruskalMST(g);
            var actualEdges = kruskalMST.Edges.ToArray();
            var actualWeight = kruskalMST.Weight;
            Assert.Equal(g.V - 1, actualEdges.Length);
            foreach (var actualEdge in actualEdges) Assert.Contains(actualEdge, expectedEdges);
            Assert.Equal(expectedWeight, actualWeight);
        }
    }
}