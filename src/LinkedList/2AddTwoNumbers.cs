/*
 * File: 2AddTwoNumbers.cs
 * Project: LinkedList
 * Created Date: Monday, 24th August 2020 11:07:57 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 104 ms, faster than 91.34% of C# online submissions for Add Two Numbers.
 * Memory Usage: 27.3 MB, less than 95.53% of C# online submissions for Add Two Numbers.
 * Copyright (c) David Gu 2020
 */


using LinkedListHelper;

namespace AddTwoNumbers
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 is null) return l2;
            if (l2 is null) return l1;

            var shift = 0;
            ListNode l1Head = l1;
            ListNode l1Prev = l1;
            while (true)
            {
                if (l1 is null)
                {
                    if (shift != 0)
                    {
                        l1Prev.next = AddTwoNumbers(new ListNode(shift), l2);
                        return l1Head;
                    }
                    l1Prev.next = l2;
                    return l1Head;
                }
                if (l2 is null)
                {
                    if (shift != 0)
                    {
                        l1Prev.next = AddTwoNumbers(new ListNode(shift), l1);
                    }
                    return l1Head;
                }
                l1.val += l2.val + shift;
                if (l1.val >= 10)
                {
                    l1.val -= 10;
                    shift = 1;
                }
                else
                {
                    shift = 0;
                }
                l1Prev = l1;
                l1 = l1.next;
                l2 = l2.next;
            }
        }
    }
}