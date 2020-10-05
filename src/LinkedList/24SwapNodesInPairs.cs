/*
 * File: 24SwapNodesInPairs.cs
 * Project: LinkedList
 * Created Date: Monday, 5th October 2020 3:30:44 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 88 ms, faster than 84.57% of C# online submissions for Swap Nodes in Pairs.
 * Memory Usage: 24.5 MB, less than 10.68% of C# online submissions for Swap Nodes in Pairs.
 * -----
 * Last Modified: Monday, 5th October 2020 3:52:08 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using LinkedListHelper;

namespace SwapNodesInPairs
{
    public class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head is null || head.next is null) return head;

            ListNode newHead = head.next;
            ListNode prev = null;
            while (head is ListNode first && head.next is ListNode second)
            {
                var tail = second.next;
                second.next = first;
                first.next = null;
                if (prev is object) prev.next = second;
                prev = first;
                head = tail;
            }
            prev.next = head;
            return newHead;
        }
    }

    /*
    * Runtime: 92 ms, faster than 63.06% of C# online submissions for Swap Nodes in Pairs.
    * Memory Usage: 24.8 MB, less than 5.04% of C# online submissions for Swap Nodes in Pairs.
    public class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head is null || head.next is null) return head;
            var tail = SwapPairs(head.next.next);
            var newHead = head.next;
            newHead.next = head;
            newHead.next.next = tail;
            return newHead;
        }
    } */
}