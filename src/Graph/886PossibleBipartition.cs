/*
 * File: 886PossibleBipartition.cs
 * Project: Graph
 * Created Date: Friday, 2nd October 2020 11:42:19 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 272 ms, faster than 100.00% of C# online submissions for Possible Bipartition.
 * Memory Usage: 44.9 MB, less than 100.00% of C# online submissions for Possible Bipartition.
 * -----
 * Last Modified: Friday, 2nd October 2020 12:21:55 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace PossibleBipartition
{
    public class Solution
    {
        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            return new Graph(N, dislikes, stackalloc bool[N], stackalloc bool[N]).Succ;
        }

        ref struct Graph
        {
            readonly int _v;
            readonly List<int>[] _adj;
            readonly Span<bool> _marked;
            readonly Span<bool> _likes;

            public bool Succ { get; private set; }

            public Graph(int V, int[][] dislikes, Span<bool> marked, Span<bool> likes)
            {
                _v = V;
                _adj = new List<int>[_v];
                foreach (var i in Enumerable.Range(0, _v)) _adj[i] = new List<int>();
                foreach (var dislike in dislikes)
                {
                    var v = dislike[0] - 1;
                    var w = dislike[1] - 1;
                    _adj[v].Add(w);
                    _adj[w].Add(v);
                }
                _marked = marked;
                _likes = likes;
                Succ = true;

                for (var v = 0; v < _v; v++)
                {
                    if (!Succ) return;
                    if (!_marked[v]) DFS(v);
                }
            }

            void DFS(int v)
            {
                if (!Succ) return;
                _marked[v] = true;
                foreach (var w in _adj[v])
                {
                    if (!_marked[w])
                    {
                        _likes[w] = !_likes[v];
                        DFS(w);
                    }
                    else if (_likes[v] == _likes[w])
                    {
                        Succ = false;
                        return;
                    }
                }
            }
        }
    }
}