/*
 * File: 21.cs
 * Project: LinkedListTests
 * Created Date: Monday, 24th August 2020 9:00:43 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using LinkedListHelper;
using MergeTwoSortedLists;

namespace LinkedListTests
{
    public class MergeTwoSortedListsTest
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
        public void TestBothEmpty()
        {
            var l1 = (ListNode)null;
            var l2 = (ListNode)null;
            var expected = (ListNode)null;
            var actual = sln.MergeTwoLists(l1, l2);
            Assert.True(LinkedListEquals(expected, actual));
        }

        [Fact]
        public void TestEqualLength()
        {
            var l1 = ListNode.FromArray(new int[] { 1, 2, 4 });
            var l2 = ListNode.FromArray(new int[] { 1, 3, 4 });
            var expected = ListNode.FromArray(new int[] { 1, 1, 2, 3, 4, 4 });
            var actual = sln.MergeTwoLists(l1, l2);
            Assert.True(LinkedListEquals(expected, actual));
        }

        [Fact]
        public void TestDifferentLength()
        {
            var l1 = ListNode.FromArray(new int[] { 1, 3, 5, 7 });
            var l2 = ListNode.FromArray(new int[] { 2, 4, 6 });
            var expected = ListNode.FromArray(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            var actual = sln.MergeTwoLists(l1, l2);
            Assert.True(LinkedListEquals(expected, actual));
        }
    }
}