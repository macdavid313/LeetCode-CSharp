/*
 * File: MyQueue.cs
 * Project: Queue
 * Created Date: Tuesday, 25th August 2020 12:20:55 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace MyQueue
{
    class LinkedListNode<T>
    {
        public T Value { get; private set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T value)
        {
            this.Value = value;
            Next = null;
        }
    }

    public class MyQueueLinkedList<T>
    {
        LinkedListNode<T> head;
        LinkedListNode<T> tail;

        public int Size { get; private set; }

        public MyQueueLinkedList()
        {
            head = null;
            tail = null;
            Size = 0;
        }

        public bool IsEmpty() => Size == 0;

        public void Enqueue(T item)
        {
            var next = new LinkedListNode<T>(item);
            if (Size == 0)
            {
                head = next;
                tail = next;
            }
            else
            {
                tail.Next = next;
                tail = next;
            }
            Size += 1;
        }

        public T Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Can't dequeue from an empty queue");
            }
            var item = head.Value;
            head = head.Next;
            if (head is null)
            {
                tail = null; // empty queue
            }
            Size -= 1;
            return item;
        }
    }

    public class MyQueueArray<T>
    {
        T[] arr;
        int head;
        int tail;

        public int Size { get => tail - head; }

        public MyQueueArray()
        {
            arr = new T[1];
            head = 0;
            tail = 0;
        }

        public bool IsEmpty() => Size == 0;

        void Resize(int newSize)
        {
            T[] newArr = new T[newSize];
            for (var i = head; i < tail; i++)
            {
                // int offset = i - head;
                newArr[i - head] = arr[i];
            }
            tail -= head;
            head = 0;
            arr = newArr;
        }

        public void Enqueue(T item)
        {
            if (tail == arr.Length)
            {
                // shrink
                if (Size == arr.Length / 4)
                {
                    Resize(arr.Length / 2);
                }
                else // extend
                {
                    Resize(arr.Length * 2);
                }
            }
            arr[tail] = item;
            tail += 1;
        }

        public T Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Can't dequeue from an empty queue");
            }
            // shrink
            if (Size == arr.Length / 4)
            {
                Resize(arr.Length / 2);
            }
            var item = arr[head];
            arr[head] = default;
            head += 1;
            return item;
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

    public class IndexPriorityQueue<T>
    {
        int ptr;
        readonly int capacity;
        readonly int[] pq; // the binary heap for indices
        readonly int[] qp; // inverse of pq, e.g. qp[pq[i]] = pq[qp[i]] = i
        readonly T[] keys; // array of keys, accessed by indices
        readonly IComparer<T> comparer;
        readonly IComparer<T> canonicalComparer;
        readonly static IComparer<T> defaultComparer = Comparer<T>.Default;
        readonly static IComparer<T> defaultComplementComparer = GetComplementComparer(Comparer<T>.Default);

        public int Count { get => ptr; }

        public bool IsEmpty { get => ptr == 0; }

        public int Capacity { get => capacity; }

        private IndexPriorityQueue(int capacity, IComparer<T> comparer, IComparer<T> canonicalComparer)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be positive");
            this.capacity = capacity;
            this.comparer = comparer ?? defaultComparer;
            this.canonicalComparer = canonicalComparer ?? defaultComparer;
            keys = new T[capacity];
            pq = new int[capacity];
            qp = new int[capacity];
            Array.Fill(qp, -1);
        }

        public static IndexPriorityQueue<T> IndexMinPQ(int capacity, IComparer<T> comparer = null) => new IndexPriorityQueue<T>(capacity, comparer, comparer);

        public static IndexPriorityQueue<T> IndexMaxPQ(int capacity, IComparer<T> comparer = null) => new IndexPriorityQueue<T>(capacity, GetComplementComparer(comparer), comparer);

        public bool Contains(int i)
        {
            ValidateIndex(i);
            return qp[i] != -1;
        }

        public void Enqueue(int i, T key)
        {
            ValidateIndex(i);
            if (Contains(i)) throw new ArgumentException("index is already in the priority queue");
            qp[i] = ptr;
            pq[ptr] = i;
            keys[i] = key;
            Swim(ptr);
            ptr += 1;
        }

        public ValueTuple<int, T> Peek()
        {
            if (ptr == 0) throw new InvalidOperationException("Priority queue underflow");
            return (pq[0], keys[pq[0]]);
        }

        public ValueTuple<int, T> Dequeue()
        {
            if (ptr == 0) throw new InvalidOperationException("Priority queue underflow");
            var mIdx = pq[0];
            var m = keys[mIdx];
            ptr -= 1;
            Swap(0, ptr);
            Sink(0);
            pq[ptr] = default;
            qp[mIdx] = -1;
            keys[mIdx] = default;
            return (mIdx, m);
        }

        public T GetKey(int i)
        {
            ValidateIndex(i);
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            return keys[i];
        }

        public void ChangeKey(int i, T key)
        {
            ValidateIndex(i);
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            keys[i] = key;
            Swim(qp[i]);
            Sink(qp[i]);
        }

        public void DecreaseKey(int i, T key)
        {
            ValidateIndex(i);
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            var cmp = canonicalComparer.Compare(keys[i], key);
            if (cmp == 0) throw new ArgumentException("Calling DecreaseKey() with a key equal to the key in the priority queue");
            if (cmp < 0) throw new ArgumentException("Calling DecreaseKey() with a key strictly greater than the key in the priority queue");
            keys[i] = key;
            Swim(qp[i]);
            Sink(qp[i]);
        }

        public void IncreaseKey(int i, T key)
        {
            ValidateIndex(i);
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            var cmp = canonicalComparer.Compare(keys[i], key);
            if (cmp == 0) throw new ArgumentException("Calling IncreaseKey() with a key equal to the key in the priority queue");
            if (cmp > 0) throw new ArgumentException("Calling IncreaseKey() with a key strictly less than the key in the priority queue");
            keys[i] = key;
            Swim(qp[i]);
            Sink(qp[i]);
        }

        public void DeleteKey(int i)
        {
            ValidateIndex(i);
            if (!Contains(i)) throw new ArgumentException("index is not in the priority queue");
            var index = qp[i];
            ptr -= 1;
            Swap(index, ptr);
            Swim(index);
            Sink(index);
            keys[i] = default;
            qp[i] = -1;
        }

        void Swim(int k)
        {
            while (k > 0)
            {
                var parent = k % 2 == 0 ? k / 2 - 1 : k / 2;
                if (Greater(parent, k))
                {
                    Swap(parent, k);
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
                Swap(k, child);
                k = child;
            }
        }

        bool Greater(int i, int j) => comparer.Compare(keys[pq[i]], keys[pq[j]]) > 0;

        static IComparer<T> GetComplementComparer(IComparer<T> comparer) => comparer is null ? defaultComplementComparer : Comparer<T>.Create(new Comparison<T>((x, y) => comparer.Compare(y, x)));

        void ValidateIndex(int i)
        {
            if (i < 0) throw new ArgumentException("Index is negative: " + i.ToString());
            if (i >= capacity) throw new ArgumentException("Index >= capacity: " + i.ToString());
        }

        void Swap(int i, int j)
        {
            int tmp = pq[i];
            pq[i] = pq[j];
            pq[j] = tmp;
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }
    }
}