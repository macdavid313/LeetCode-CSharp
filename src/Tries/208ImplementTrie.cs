/*
 * File: 208ImplementTrie.cs
 * Project: Tries
 * Created Date: Thursday, 1st October 2020 9:08:41 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 196 ms, faster than 97.07% of C# online submissions for Implement Trie (Prefix Tree).
 * Memory Usage: 44.4 MB, less than 97.46% of C# online submissions for Implement Trie (Prefix Tree).
 * -----
 * Last Modified: Thursday, 1st October 2020 4:52:42 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;

namespace ImplementTrie
{
    public class Trie
    {
        Node _root;

        class Node
        {
            readonly char _c;

            public char Char { get => _c; }

            public Node Left { get; set; }
            public Node Mid { get; set; }
            public Node Right { get; set; }

            public bool Anchor { get; set; }

            public Node() { }

            public Node(char c) { _c = c; Anchor = false; }
        }

        /** Initialize your data structure here. */
        public Trie()
        {
            _root = null;
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            word = word ?? throw new ArgumentNullException(nameof(word));
            if (word.Length == 0) return;
            _root = Insert(_root, word, 0);
        }

        Node Insert(Node node, string word, int idx)
        {
            node ??= new Node(word[idx]);
            if (node.Char > word[idx]) node.Left = Insert(node.Left, word, idx);
            else if (node.Char < word[idx]) node.Right = Insert(node.Right, word, idx);
            else if (idx < word.Length - 1) node.Mid = Insert(node.Mid, word, idx + 1);
            else node.Anchor = true;
            return node;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            word = word ?? throw new ArgumentNullException(nameof(word));
            if (word.Length == 0) return false;
            return Search(_root, word, 0);
        }

        bool Search(Node node, string word, int idx)
        {
            if (node is null) return false;
            if (node.Char > word[idx]) return Search(node.Left, word, idx);
            if (node.Char < word[idx]) return Search(node.Right, word, idx);
            else if (idx < word.Length - 1) return Search(node.Mid, word, idx + 1);
            else return node.Anchor;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            prefix = prefix ?? throw new ArgumentNullException(nameof(prefix));
            if (prefix.Length == 0) return false;
            return StartsWith(_root, prefix, 0);
        }

        bool StartsWith(Node node, string prefix, int idx)
        {
            if (node is null) return false;
            if (node.Char > prefix[idx]) return StartsWith(node.Left, prefix, idx);
            else if (node.Char < prefix[idx]) return StartsWith(node.Right, prefix, idx);
            else if (idx < prefix.Length - 1) return StartsWith(node.Mid, prefix, idx + 1);
            else return true;
        }
    }

    /* (26) R-Way
    * Runtime: 196 ms, faster than 97.07% of C# online submissions for Implement Trie (Prefix Tree).
    * Memory Usage: 49 MB, less than 17.39% of C# online submissions for Implement Trie (Prefix Tree).
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

        // Initialize your data structure here.
        public Trie()
        {
            _root = new Node();
        }

        // Inserts a word into the trie.
        public void Insert(string word)
        {
            word = word ?? throw new ArgumentNullException(nameof(word));
            var node = _root;
            foreach (var r in ToRadix(word))
            {
                if (node.Next[r] is null) node.Next[r] = new Node();
                node = node.Next[r];
            }
            node?.Achor = true;
        }

        // Returns if the word is in the trie.
        public bool Search(string word)
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

        // Returns if there is any word in the trie that starts with the given prefix.
        public bool StartsWith(string prefix)
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

        IEnumerable<int> ToRadix(string word) => word.Select(c => Convert.ToInt32(c) - _start);
    }*/
}