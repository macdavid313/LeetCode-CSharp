/*
 * File: 206.cs
 * Project: LinkedListTests
 * Created Date: Thursday, 27th August 2020 5:42:06 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using LinkedListHelper;
using ReverseLinkedList;

namespace LinkedListTests
{
    public class ReverseLinkedListTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestBase()
        {
            var head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };
            var expected = new ListNode(5)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(2)
                        {
                            next = new ListNode(1)
                        }
                    }
                }
            };
            var actual = sln.ReverseList(head);
            while (true)
            {
                if (expected == null) return;
                Assert.Equal(expected.val, actual.val);
                expected = expected.next;
                actual = actual.next;
            }
        }
    }

}