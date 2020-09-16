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
}