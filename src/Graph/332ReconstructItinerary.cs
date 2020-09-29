/*
 * File: 332ReconstructItinerary.cs
 * Project: Graph
 * Created Date: Tuesday, 29th September 2020 8:34:19 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 296 ms, faster than 78.13% of C# online submissions for Reconstruct Itinerary.
 * Memory Usage: 34.4 MB, less than 5.63% of C# online submissions for Reconstruct Itinerary.
 * -----
 * Last Modified: Tuesday, 29th September 2020 10:12:20 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace ReconstructItinerary
{
    public class Solution
    {
        static Dictionary<string, PriorityQueue<string>> _map;

        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            _map = new Dictionary<string, PriorityQueue<string>>();
            foreach (var ticket in tickets)
            {
                var from = ticket[0];
                var to = ticket[1];
                if (!_map.ContainsKey(from))
                    _map.Add(from, PriorityQueue<string>.MinPQ());
                _map[from].Enqueue(to);
            }
            var path = new Stack<string>();
            DFS("JFK", path);
            return path.ToArray();
        }

        void DFS(string v, Stack<string> path)
        {
            while (_map.ContainsKey(v) && _map[v].Count > 0)
            {
                var w = _map[v].Dequeue();
                DFS(w, path);
            }
            path.Push(v);
        }
    }

    public class PriorityQueue<T>
    {
        T[] keys;
        int ptr;
        readonly IComparer<T> comparer;
        readonly static IComparer<T> defaultComparer = Comparer<T>.Default;
        readonly static IComparer<T> defaultComplementComparer = GetComplementComparer(Comparer<T>.Default);

        public int Count { get => ptr; }

        public bool IsEmpty { get => ptr == 0; }

        PriorityQueue(IComparer<T> comparer)
        {
            keys = new T[1];
            ptr = 0;
            this.comparer = comparer ?? defaultComparer;
        }

        private PriorityQueue(int capacity, IComparer<T> comparer)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be positive");
            keys = new T[capacity];
            ptr = 0;
            this.comparer = comparer ?? defaultComparer;
        }

        private PriorityQueue(T[] keys, IComparer<T> comparer)
        {
            keys = keys ?? throw new ArgumentNullException(nameof(keys));
            if (keys.Length == 0) throw new ArgumentException("Empty array");
            this.keys = new T[keys.Length];
            Array.Copy(keys, this.keys, keys.Length);
            this.comparer = comparer ?? defaultComparer;
            ptr = keys.Length;
            // sink all parents in reverse order
            for (var parent = ptr / 2; parent >= 0; parent -= 1)
            {
                Sink(parent);
            }
        }

        public static PriorityQueue<T> MinPQ(IComparer<T> comparer = null) => new PriorityQueue<T>(comparer);

        public static PriorityQueue<T> MinPQ(int capacity, IComparer<T> comparer = null) => new PriorityQueue<T>(capacity, comparer);

        public static PriorityQueue<T> MinPQ(T[] keys, IComparer<T> comparer = null) => new PriorityQueue<T>(keys, comparer);

        public static PriorityQueue<T> MaxPQ(IComparer<T> comparer = null) => new PriorityQueue<T>(GetComplementComparer(comparer));

        public static PriorityQueue<T> MaxPQ(int capacity, IComparer<T> comparer = null) => new PriorityQueue<T>(capacity, GetComplementComparer(comparer));

        public static PriorityQueue<T> MaxPQ(T[] keys, IComparer<T> comparer = null) => new PriorityQueue<T>(keys, GetComplementComparer(comparer));

        public void Enqueue(T key)
        {
            if (ptr == keys.Length) ResizeKeys(keys.Length * 2);
            keys[ptr] = key;
            Swim(ptr);
            ptr += 1;
        }

        public T Peek() => Count > 0 ? keys[0] : throw new InvalidOperationException("Priority queue underflow");

        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException("Priority queue underflow");
            var m = keys[0];
            ptr -= 1;
            SwapKeys(0, ptr);
            keys[ptr] = default;
            Sink(0);
            if (Count > 0 && Count == (keys.Length / 4)) ResizeKeys(keys.Length / 2);
            return m;
        }

        void Swim(int k)
        {
            while (k > 0)
            {
                var parent = k % 2 == 0 ? k / 2 - 1 : k / 2;
                if (Greater(parent, k))
                {
                    SwapKeys(parent, k);
                    k = parent;
                }
                else return;
            }
        }

        void Sink(int k)
        {
            while (k < ptr)
            {
                var child = 2 * k + 1;
                if (child >= ptr) return;
                if (child + 1 < ptr && Greater(child, child + 1)) child += 1;
                if (!Greater(k, child)) return;
                SwapKeys(k, child);
                k = child;
            }
        }

        bool Greater(int i, int j) => comparer.Compare(keys[i], keys[j]) > 0;

        static IComparer<T> GetComplementComparer(IComparer<T> comparer) => comparer is null ? defaultComplementComparer : Comparer<T>.Create(new Comparison<T>((x, y) => comparer.Compare(y, x)));

        void ResizeKeys(int newSize)
        {
            var newKeys = new T[newSize];
            Array.Copy(keys, newKeys, ptr);
            keys = newKeys;
        }

        void SwapKeys(int i, int j)
        {
            T tmp = keys[i];
            keys[i] = keys[j];
            keys[j] = tmp;
        }
    }
}