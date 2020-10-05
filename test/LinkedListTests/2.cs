/*
 * File: 2.cs
 * Project: LinkedListTests
 * Created Date: Monday, 24th August 2020 11:59:44 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using LinkedListHelper;
using AddTwoNumbers;

namespace LinkedListTests
{
    public class AddTwoNumbersTest
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
            var l1 = ListNode.FromArray(new int[] { 2, 4, 3 });
            var l2 = ListNode.FromArray(new int[] { 5, 6, 4 });
            var expected = ListNode.FromArray(new int[] { 7, 0, 8 });
            var actual = sln.AddTwoNumbers(l1, l2);
            Assert.True(LinkedListEquals(expected, actual));
        }

        [Fact]
        public void TestCase2()
        {
            var l1 = ListNode.FromArray(new int[] { 0, 3 });
            var l2 = ListNode.FromArray(new int[] { 5, 6, 4 });
            var expected = ListNode.FromArray(new int[] { 5, 9, 4 });
            var actual = sln.AddTwoNumbers(l1, l2);
            Assert.True(LinkedListEquals(expected, actual));
        }

        [Fact]
        public void TestCase3()
        {
            var l1 = ListNode.FromArray(new int[] { 5, 6, 4 });
            var l2 = ListNode.FromArray(new int[] { 0, 3 });
            var expected = ListNode.FromArray(new int[] { 5, 9, 4 });
            var actual = sln.AddTwoNumbers(l1, l2);
            Assert.True(LinkedListEquals(expected, actual));
        }

        [Fact]
        public void TestCase4()
        {
            var l1 = ListNode.FromArray(new int[] { 9, 9, 9, 9 });
            var l2 = ListNode.FromArray(new int[] { 9, 9, 9, 9 });
            var expected = ListNode.FromArray(new int[] { 8, 9, 9, 9, 1 });
            var actual = sln.AddTwoNumbers(l1, l2);
            Assert.True(LinkedListEquals(expected, actual));
        }
    }
}