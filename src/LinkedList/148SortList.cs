/*
 * File: 148SortList.cs
 * Project: LinkedList
 * Created Date: Friday, 18th September 2020 5:55:56 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 112 ms, faster than 77.54% of C# online submissions for Sort List.
 * Memory Usage: 29.8 MB, less than 59.89% of C# online submissions for Sort List.
 * -----
 * Last Modified: Monday, 5th October 2020 3:33:16 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using LinkedListHelper;

namespace SortList
{
    public class Solution
    {
        public ListNode SortList(ListNode head)
        {
            if (head is null || head.next is null) return head;
            // Partition
            var slow = head;
            var fast = head.next;
            while (fast is object && fast.next is object)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            var p1 = head;
            var p2 = slow.next;
            slow.next = null;
            // Merge
            p1 = SortList(p1);
            p2 = SortList(p2);
            return Merge2SortedList(p1, p2);
        }

        ListNode Merge2SortedList(ListNode l1, ListNode l2)
        {
            if (l1 is null) return l2;
            if (l2 is null) return l1;
            if (l1.val < l2.val)
            {
                l1.next = Merge2SortedList(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = Merge2SortedList(l1, l2.next);
                return l2;
            }
        }
    }
}