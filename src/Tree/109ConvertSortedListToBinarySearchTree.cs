/*
 * File: 109ConvertSortedListToBinarySearchTree.cs
 * Project: Tree
 * Created Date: Thursday, 1st October 2020 7:03:54 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 96 ms, faster than 88.81% of C# online submissions for Convert Sorted List to Binary Search Tree.
 * Memory Usage: 27.5 MB, less than 15.30% of C# online submissions for Convert Sorted List to Binary Search Tree.
 * -----
 * Last Modified: Thursday, 1st October 2020 7:37:07 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using TreeHelper;

namespace ConvertSortedListToBinarySearchTree
{

    public class Solution
    {
        public TreeNode SortedListToBST(ListNode head) => SortedListToBST(head, null);

        TreeNode SortedListToBST(ListNode head, ListNode tail)
        {
            if (head == tail) return null;
            var mid = GetMid(head, tail);
            var root = new TreeNode(mid.val)
            {
                left = SortedListToBST(head, mid),
                right = SortedListToBST(mid.next, tail)
            };
            return root;
        }

        ListNode GetMid(ListNode head, ListNode tail)
        {
            var slow = head;
            var fast = head;
            while (fast != tail && fast.next != tail)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
    }

    /*
    * Runtime: 104 ms, faster than 58.96% of C# online submissions for Convert Sorted List to Binary Search Tree.
    * Memory Usage: 27.7 MB, less than 11.57% of C# online submissions for Convert Sorted List to Binary Search Tree.
    public class Solution
    {
        public TreeNode SortedListToBST(ListNode head) => SortedListToBST(ref head, 0, GetLength(head) - 1);

        TreeNode SortedListToBST(ref ListNode head, int lo, int hi)
        {
            if (lo > hi) return null;
            var mid = lo + (hi - lo) / 2;
            var root = new TreeNode();
            root.left = SortedListToBST(ref head, lo, mid - 1);
            root.val = head.val;
            head = head.next;
            root.right = SortedListToBST(ref head, mid + 1, hi);
            return root;
        }

        int GetLength(ListNode head)
        {
            var count = 0;
            while (head is object)
            {
                count += 1;
                head = head.next;
            }
            return count;
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
