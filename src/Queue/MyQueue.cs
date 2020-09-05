/*
 * File: MyQueue.cs
 * Project: Queue
 * Created Date: Tuesday, 25th August 2020 12:20:55 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;

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

    public class MyMaxPQ<T> where T : IComparable
    {
        readonly T[] pq;
        int ptr;
        public int Capacity { get; private set; }
        public int Size { get => ptr; }

        public MyMaxPQ(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity can't be negative.");
            }
            Capacity = capacity;
            pq = new T[Capacity];
            ptr = 0;
        }

        public bool IsEmpty() => Size == 0;

        public void Insert(T item)
        {
            if (ptr == Capacity)
            {
                throw new InvalidOperationException("Can't insert when Capacity is full.");
            }
            pq[ptr] = item;
            Swim(ptr);
            ptr += 1;
        }

        public T DelMax()
        {
            if (ptr == 0)
            {
                throw new InvalidOperationException("Can't delete Max from an empty Priority Queue");
            }
            T max = pq[0];
            Swap(0, ptr - 1);
            ptr -= 1;
            pq[ptr] = default;
            Sink(0);
            return max;
        }

        void Swim(int k)
        {
            while (k > 0)
            {
                var parentIdx = ParentIdx(k);
                if (!Less(parentIdx, k)) break;
                Swap(parentIdx, k);
                k = parentIdx;
            }
        }

        void Sink(int k)
        {
            while (k * 2 + 1 < ptr)
            {
                var childIdx = 2 * k + 1;
                if (childIdx + 1 < Size && Less(childIdx, childIdx + 1)) childIdx += 1;
                if (!Less(k, childIdx)) break;
                Swap(k, childIdx);
                k = childIdx;
            }
        }

        int ParentIdx(int k) => k % 2 == 1 ? k / 2 : k / 2 - 1;

        bool Less(int i, int j) => pq[i].CompareTo(pq[j]) == -1;

        void Swap(int i, int j)
        {
            T tmp = pq[i];
            pq[i] = pq[j];
            pq[j] = tmp;
        }
    }
}