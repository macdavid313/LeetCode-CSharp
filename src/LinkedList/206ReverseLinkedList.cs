/*
 * File: 206ReverseLinkedList.cs
 * Project: LinkedList
 * Created Date: Thursday, 27th August 2020 5:20:10 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 92 ms, faster than 87.09% of C# online submissions for Reverse Linked List.
 * Memory Usage: 24.2 MB, less than 84.59% of C# online submissions for Reverse Linked List.
 * Copyright (c) David Gu 2020
 */


using LinkedListHelper;

namespace ReverseLinkedList
{
    /* iterative solution */
    public class Solution
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            while (head != null)
            {
                ListNode next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }
    }

    /* recursive solution
    * Runtime: 100 ms, faster than 54.69% of C# online submissions for Reverse Linked List.
    * Memory Usage: 24.4 MB, less than 49.90% of C# online submissions for Reverse Linked List.
    public class Solution
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode newHead = ReverseList(head.next);
            ListNode secondLast = head.next;
            secondLast.next = head;
            head.next = null;
            return newHead;
        }
    } */
}