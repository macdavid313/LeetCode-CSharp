/*
 * File: 703KthLargestElementInAStream.cs
 * Project: Heap
 * Created Date: Tuesday, 15th September 2020 6:19:41 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 160 ms, faster than 94.48% of C# online submissions for Kth Largest Element in a Stream.
 * Memory Usage: 39.6 MB, less than 91.71% of C# online submissions for Kth Largest Element in a Stream.
 * Copyright (c) David Gu 2020
 */


using System;

namespace KthLargestElementInAStream
{
    public class KthLargest
    {
        readonly MinIntPQSpan pq;

        public KthLargest(int k, int[] nums)
        {
            pq = new MinIntPQSpan(k);
            foreach (var n in nums) pq.Enqueue(n);
        }

        public int Add(int val)
        {
            pq.Enqueue(val);
            return pq.Peek();
        }
    }

    class MinIntPQSpan
    {
        readonly int[] arr;
        public int Capacity { get => arr.Length; }
        public int Count { get; private set; }

        public MinIntPQSpan(int capacity)
        {
            if (capacity > 0)
            {
                arr = new int[capacity];
                Count = 0;
            }
            else throw new ArgumentException(nameof(arr));
        }

        public void Enqueue(int item)
        {
            if (Count < Capacity)
            {
                arr[Count] = item;
                Count += 1;
                Swim();
            }
            else if (Peek() < item)
            {
                Dequeue();
                Enqueue(item);
            }
        }

        public int Peek() => Count == 0 ? throw new ArgumentException() : arr[0];

        public int Dequeue()
        {
            if (Count == 0) throw new ArgumentOutOfRangeException();
            var min = arr[0];
            arr[0] = arr[Count - 1];
            Count -= 1;
            Sink();
            return min;
        }

        void Swim()
        {
            var child = Count - 1;
            while (child > 0)
            {
                var parent = child % 2 == 0 ? child / 2 - 1 : child / 2;
                if (arr[parent] > arr[child])
                {
                    var tmp = arr[parent];
                    arr[parent] = arr[child];
                    arr[child] = tmp;
                    child = parent;
                }
                else return;
            }
        }

        void Sink()
        {
            var parent = 0;
            while (parent * 2 + 1 < Count)
            {
                var child = parent * 2 + 1;
                if (child + 1 < Count && arr[child] > arr[child + 1]) child += 1;
                if (arr[parent] < arr[child]) return;
                var tmp = arr[parent];
                arr[parent] = arr[child];
                arr[child] = tmp;
                parent = child;
            }
        }
    }
}