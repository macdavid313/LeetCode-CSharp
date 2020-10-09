/*
 * File: 212WordSearchII.cs
 * Project: Backtracking
 * Created Date: Friday, 9th October 2020 12:32:29 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 408 ms, faster than 53.12% of C# online submissions for Word Search II.
 * Memory Usage: 51.8 MB, less than 5.15% of C# online submissions for Word Search II.
 * -----
 * Last Modified: Friday, 9th October 2020 1:23:50 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearchII
{
    public class Solution
    {
        static int m;
        static int n;
        static Trie trie;
        static char[][] _board;

        public IList<string> FindWords(char[][] board, string[] words)
        {
            if (words.Length == 0) return Array.Empty<string>();

            _board = board;
            m = board.Length;
            n = board[0].Length;

            trie = new Trie();
            foreach (var word in words) trie.Insert(word);
            var ans = new HashSet<string>();
            var marked = new bool[m * n];
            var prefix = new List<char>(words.Max(w => w.Length));
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Array.Fill(marked, false);
                    prefix.Clear();
                    Backtrack(ans, prefix, i, j, marked);
                }
            }
            return ans.ToArray();
        }

        void Backtrack(HashSet<string> ans, List<char> prefix, int i, int j, bool[] marked)
        {
            marked[i * n + j] = true;
            prefix.Add(_board[i][j]);

            if (!trie.StartsWith(prefix))
            {
                marked[i * n + j] = false;
                prefix.RemoveAt(prefix.Count - 1);
                return;
            }

            if (trie.Search(prefix))
            {
                ans.Add(new string(prefix.ToArray()));
            }

            foreach (var (p, q) in NextStep(i, j, marked))
            {
                Backtrack(ans, prefix, p, q, marked);
            }
            marked[i * n + j] = false;
            prefix.RemoveAt(prefix.Count - 1);
        }

        bool IsValidStep(int i, int j) => i >= 0 && i < m && j >= 0 && j < n;

        IEnumerable<ValueTuple<int, int>> NextStep(int i, int j, bool[] marked)
        {
            foreach (var (p, q) in new[] { (i - 1, j), (i + 1, j), (i, j - 1), (i, j + 1) })
            {
                if (IsValidStep(p, q) && !marked[p * n + q])
                    yield return (p, q);
            }
        }
    }

    public class Trie
    {
        readonly Node _root;
        const int _start = 97; // Convert.ToInt32('a')

        class Node
        {
            const int _R = 26;
            readonly Node[] _next;
            bool _anchor;

            public Node[] Next { get => _next; }
            public bool Achor { get => _anchor; set => _anchor = value; }

            public Node()
            {
                _next = new Node[_R];
                _anchor = false;
            }
        }

        /** Initialize your data structure here. */
        public Trie()
        {
            _root = new Node();
        }

        /** Inserts a word into the trie. */
        public void Insert(IEnumerable<char> word)
        {
            word = word ?? throw new ArgumentNullException(nameof(word));
            var node = _root;
            foreach (var r in ToRadix(word))
            {
                if (node.Next[r] is null) node.Next[r] = new Node();
                node = node.Next[r];
            }
            node.Achor = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(IEnumerable<char> word)
        {
            word = word ?? throw new ArgumentNullException(nameof(word));
            var node = _root;
            foreach (var r in ToRadix(word))
            {
                node = node.Next[r];
                if (node is null) return false;
            }
            return node.Achor;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(IEnumerable<char> prefix)
        {
            prefix = prefix ?? throw new ArgumentNullException(nameof(prefix));
            var node = _root;
            foreach (var r in ToRadix(prefix))
            {
                node = node.Next[r];
                if (node is null) return false;
            }
            return true;
        }

        IEnumerable<int> ToRadix(IEnumerable<char> word) => word.Select(c => Convert.ToInt32(c) - _start);
    }
}