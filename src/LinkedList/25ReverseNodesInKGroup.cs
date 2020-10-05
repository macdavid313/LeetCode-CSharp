/*
 * File: 25ReverseNodesInKGroup.cs
 * Project: LinkedList
 * Created Date: Monday, 5th October 2020 5:00:29 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 92 ms, faster than 97.21% of C# online submissions for Reverse Nodes in k-Group.
 * Memory Usage: 26.8 MB, less than 10.62% of C# online submissions for Reverse Nodes in k-Group.
 * -----
 * Last Modified: Monday, 5th October 2020 5:01:45 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using LinkedListHelper;

namespace ReverseNodesInKGroup
{
    public class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head is null) return null;
            if (k == 1) return head;

            var nextHead = GetNextHead(head, k);
            if (head == nextHead) return head;
            else
            {
                var group = ReverseList(head);
                head.next = ReverseKGroup(nextHead, k);
                return group;
            }
        }

        ListNode GetNextHead(ListNode head, int k)
        {
            var headCopy = head;
            ListNode prev = null;
            while (k != 0 && head is object)
            {
                k -= 1;
                prev = head;
                head = head.next;
            }
            if (k == 0)
            {
                prev.next = null;
                return head;
            }
            else
            {
                return headCopy;
            }
        }

        ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            while (head is object)
            {
                var next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }
    }
}