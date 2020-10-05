/*
 * File: 21MergeTwoSortedLists.cs
 * Project: LinkedList
 * Created Date: Monday, 24th August 2020 8:41:40 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 96 ms, faster than 75.77% of C# online submissions for Merge Two Sorted Lists.
 * Memory Usage: 25.4 MB, less than 96.65% of C# online submissions for Merge Two Sorted Lists.
 * Copyright (c) David Gu 2020
 */


using LinkedListHelper;

namespace MergeTwoSortedLists
{
    public class Solution
    {
        /*
        * A more clear solution
        * Runtime: 96 ms, faster than 75.77% of C# online submissions for Merge Two Sorted Lists.
        * Memory Usage: 25.9 MB, less than 20.88% of C# online submissions for Merge Two Sorted Lists.
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 is null) return l2;
            if (l2 is null) return l1;

            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            l2.next = MergeTwoLists(l1, l2.next);
            return l2;

        } */

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 is null) return l2;
            if (l2 is null) return l1;

            if (LinkedListLengthCompare(l1, l2) == 1)
            {
                return MergeTwoLists(l2, l1);
            }

            // corner cases
            var l2Last = LinkedListLastNode(l2);
            if (l1.val >= l2Last.val)
            {
                l2Last.next = l1;
                return l2;
            }
            var l1Last = LinkedListLastNode(l1);
            if (l1Last.val <= l2.val)
            {
                l1Last.next = l2;
                return l1;
            }

            l2 = Insert(new ListNode(l1.val), l2);
            return MergeTwoLists(l1.next, l2);
        }

        static int LinkedListLengthCompare(ListNode l1, ListNode l2)
        {
            while (true)
            {
                if (l1 is null && l2 is null) return 0;
                if (l1 is null && l2 != null) return -1;
                if (l1 != null && l2 is null) return 1;
                l1 = l1.next;
                l2 = l2.next;
            }
        }

        static ListNode LinkedListLastNode(ListNode l)
        {
            while (l.next != null)
            {
                l = l.next;
            }
            return l;
        }

        static ListNode Insert(ListNode sourceNode, ListNode targetList)
        {
            if (sourceNode.val <= targetList.val)
            {
                sourceNode.next = targetList;
                return sourceNode;
            }
            ListNode node = targetList;
            ListNode prevNode = targetList;
            while (node != null)
            {
                if (sourceNode.val <= node.val)
                {
                    prevNode.next = sourceNode;
                    sourceNode.next = node;
                    return targetList;
                }
                prevNode = node;
                node = node.next;
            }
            prevNode.next = sourceNode;
            return targetList;
        }
    }
}