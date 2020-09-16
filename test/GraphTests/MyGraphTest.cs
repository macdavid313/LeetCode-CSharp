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
}