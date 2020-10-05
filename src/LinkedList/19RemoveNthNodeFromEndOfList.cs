/*
 * File: 19RemoveNthNodeFromEndOfList.cs
 * Project: LinkedList
 * Created Date: Monday, 31st August 2020 8:14:56 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 92 ms, faster than 84.15% of C# online submissions for Remove Nth Node From End of List.
 * Memory Usage: 24.2 MB, less than 99.83% of C# online submissions for Remove Nth Node From End of List.
 * Copyright (c) David Gu 2020
 */


using LinkedListHelper;

namespace RemoveNthNodeFromEndOfList
{
    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var slow = head;
            var fast = head;
            var steps = 0;
            while (steps != n)
            {
                fast = fast.next;
                if (fast == null) return head.next;
                steps += 1;
            }
            while (fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }
            slow.next = slow.next.next;
            return head;
        }
    }
}