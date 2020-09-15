/*
 * File: 23MergeKSortedLists.cs
 * Project: Heap
 * Created Date: Tuesday, 15th September 2020 5:33:53 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 108 ms, faster than 95.31% of C# online submissions for Merge k Sorted Lists.
 * Memory Usage: 28.9 MB, less than 86.61% of C# online submissions for Merge k Sorted Lists.
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace MergeKSortedLists
{
    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists is null || lists.Length == 0) return null;
            if (lists.Length == 1) return lists[0];

            var q = new ListNodeMinPQ(lists.Length);
            foreach (var l in lists)
            {
                q.Enqueue(l);
            }
            ListNode head = null;
            ListNode node = null;
            while (q.Size != 0)
            {
                if (head is null)
                {
                    head = q.Dequeue();
                    node = head;
                }
                else
                {
                    node.next = q.Dequeue();
                    node = node.next;
                }
            }
            return head;
        }
    }

    class ListNodeMinPQ
    {
        readonly ListNode[] arr;
        int ptr;
        readonly Comparer<ListNode> comparer;

        public int Size { get => ptr; }

        public int Capacity { get; private set; }

        public ListNodeMinPQ(int capacity)
        {
            Capacity = capacity;
            arr = new ListNode[Capacity];
            ptr = 0;
            comparer = new ListNodeComparer();
        }

        public void Enqueue(ListNode item)
        {
            if (Size == Capacity)
                throw new InvalidOperationException("Capacity if full");
            if (item is object)
            {
                arr[ptr] = item;
                ptr += 1;
                Swim();
            }
        }

        public ListNode Dequeue()
        {
            if (Size == 0)
                throw new InvalidOperationException("Cannot dequeue from an empty heap");
            ListNode res = arr[0];
            arr[0] = arr[0].next;
            if (arr[0] is null)
            {
                arr[0] = arr[ptr - 1];
                arr[ptr - 1] = default;
                ptr -= 1;
            }
            Sink();
            res.next = null;
            return res;
        }

        void Swim()
        {
            var k = ptr - 1;
            while (k > 0)
            {
                var parent = k % 2 == 0 ? k / 2 - 1 : k / 2;
                switch (comparer.Compare(arr[parent], arr[k]))
                {
                    case 1:
                        Swap(parent, k);
                        k = parent;
                        continue;
                    default:
                        return;
                }
            }
        }

        void Sink()
        {
            var k = 0;
            while (2 * k + 1 < ptr)
            {
                var child = 2 * k + 1;
                if (child + 1 < ptr && comparer.Compare(arr[child], arr[child + 1]) == 1) child += 1;
                if (comparer.Compare(arr[k], arr[child]) != 1) break;
                Swap(k, child);
                k = child;
            }
        }

        void Swap(int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }

    public class ListNodeComparer : Comparer<ListNode>
    {
        public override int Compare(ListNode x, ListNode y)
        {
            if (x is object && y is object)
            {
                return x.val.CompareTo(y.val);
            }
            else
                throw new InvalidOperationException("Cannot compare between null");
        }
    }

    /* Definition for singly-linked list. */
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}