/*
 * File: 148.cs
 * Project: LinkedListTests
 * Created Date: Friday, 18th September 2020 5:59:33 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Monday, 5th October 2020 3:35:37 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using LinkedListHelper;
using SortList;

namespace LinkedListTests
{
    public class SortListTest
    {
        readonly Solution sln = new Solution();

        static bool LinkedListEquals(ListNode l1, ListNode l2)
        {
            while (true)
            {
                if (l1 is null && l2 is null) return true;
                if (l1 is null && l2 != null) return false;
                if (l1 != null && l2 is null) return false;
                if (l1.val != l2.val)
                {
                    return false;
                }
                l1 = l1.next;
                l2 = l2.next;
            }
        }

        [Fact]
        public void TestCase1()
        {
            var head = ListNode.FromArray(new int[] { 4, 2, 1, 3 });
            var expected = ListNode.FromArray(new int[] { 1, 2, 3, 4 });
            var actual = sln.SortList(head);
            Assert.True(LinkedListEquals(expected, actual));
        }

        [Fact]
        public void TestCase2()
        {
            var head = ListNode.FromArray(new int[] { -1, 5, 3, 4, 0 });
            var expected = ListNode.FromArray(new int[] { -1, 0, 3, 4, 5 });
            var actual = sln.SortList(head);
            Assert.True(LinkedListEquals(expected, actual));
        }
    }
}