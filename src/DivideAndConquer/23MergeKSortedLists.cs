/*
 * File: 23MergeKSortedLists.cs
 * Project: DivideAndConquer
 * Created Date: Friday, 4th September 2020 8:38:23 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 128 ms, faster than 72.24% of C# online submissions for Merge k Sorted Lists.
 * Memory Usage: 30 MB, less than 10.84% of C# online submissions for Merge k Sorted Lists.
 * Copyright (c) David Gu 2020
 */


using System.Threading.Tasks;

namespace MergeKSortedLists
{
    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists is null || lists.Length == 0) return null;
            if (lists.Length == 1) return lists[0];
            if (lists.Length == 2) return Merge2Lists(lists[0], lists[1]);

            var n = lists.Length;
            var last = n % 2 == 0 ? null : lists[n - 1];
            var mergedLists = new ListNode[n / 2];

            Parallel.For(0, n / 2, i =>
              {
                  mergedLists[i] = Merge2Lists(lists[2 * i], lists[2 * i + 1]);
              });
            var head = MergeKLists(mergedLists);
            if (last is null) return head;
            else return Merge2Lists(head, last);
        }

        ListNode Merge2Lists(ListNode l1, ListNode l2)
        {
            if (l1 is null) return l2;
            if (l2 is null) return l1;
            if (l1.val < l2.val)
            {
                l1.next = Merge2Lists(l1.next, l2);
                return l1;
            }
            l2.next = Merge2Lists(l1, l2.next);
            return l2;
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