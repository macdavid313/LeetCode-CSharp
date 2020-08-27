/*
 * File: 206ReverseLinkedList.cs
 * Project: LinkedList
 * Created Date: Thursday, 27th August 2020 5:20:10 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Iterative Solution
 * Runtime: 92 ms, faster than 87.09% of C# online submissions for Reverse Linked List.
 * Memory Usage: 24.2 MB, less than 84.59% of C# online submissions for Reverse Linked List.
 * Recursive Solution
 * Runtime: 100 ms, faster than 54.69% of C# online submissions for Reverse Linked List.
 * Memory Usage: 24.4 MB, less than 49.90% of C# online submissions for Reverse Linked List.
 * Copyright (c) David Gu 2020
 */


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