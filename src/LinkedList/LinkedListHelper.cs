/*
 * File: LinkedListHelper.cs
 * Project: LinkedList
 * Created Date: Monday, 5th October 2020 3:31:14 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Monday, 5th October 2020 3:31:40 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;

namespace LinkedListHelper
{
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

        public static ListNode FromArray(int[] vals)
        {
            if (vals is null)
            {
                throw new ArgumentNullException(nameof(vals));
            }
            if (vals.Length == 0)
            {
                return null;
            }
            var head = new ListNode(vals[0]);
            var node = head;
            for (var i = 1; i < vals.Length; i++)
            {
                var newNode = new ListNode(vals[i]);
                node.next = newNode;
                node = newNode;
            }
            return head;
        }
    }
}