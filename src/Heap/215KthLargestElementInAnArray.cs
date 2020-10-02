/*
 * File: 215KthLargestElementInAnArray.cs
 * Project: Heap
 * Created Date: Saturday, 3rd October 2020 9:22:31 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 96 ms, faster than 92.39% of C# online submissions for Kth Largest Element in an Array.
 * Memory Usage: 25.8 MB, less than 26.90% of C# online submissions for Kth Largest Element in an Array.
 * -----
 * Last Modified: Saturday, 3rd October 2020 9:37:44 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;

namespace KthLargestElementInAnArray
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            var pq = new MinIntPQSpan(stackalloc int[k]);
            foreach (var n in nums) pq.Enqueue(n);
            return pq.Peek();
        }
    }

    ref struct MinIntPQSpan
    {
        readonly Span<int> _arr;
        public int Capacity { get => _arr.Length; }
        public int Count { get; private set; }

        public MinIntPQSpan(Span<int> memory)
        {
            if (memory.Length > 0)
            {
                _arr = memory;
                Count = 0;
            }
            else throw new ArgumentException(nameof(_arr));
        }

        public void Enqueue(int item)
        {
            if (Count < Capacity)
            {
                _arr[Count] = item;
                Count += 1;
                Swim();
            }
            else if (Peek() < item)
            {
                Dequeue();
                Enqueue(item);
            }
        }

        public int Peek() => Count == 0 ? throw new ArgumentException() : _arr[0];

        public int Dequeue()
        {
            if (Count == 0) throw new ArgumentOutOfRangeException();
            var min = _arr[0];
            _arr[0] = _arr[Count - 1];
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
                if (_arr[parent] > _arr[child])
                {
                    var tmp = _arr[parent];
                    _arr[parent] = _arr[child];
                    _arr[child] = tmp;
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
                if (child + 1 < Count && _arr[child] > _arr[child + 1]) child += 1;
                if (_arr[parent] < _arr[child]) return;
                var tmp = _arr[parent];
                _arr[parent] = _arr[child];
                _arr[child] = tmp;
                parent = child;
            }
        }
    }
}