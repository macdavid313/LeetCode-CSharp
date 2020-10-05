/*
 * File: 19.cs
 * Project: LinkedListTests
 * Created Date: Monday, 31st August 2020 8:15:45 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using LinkedListHelper;
using RemoveNthNodeFromEndOfList;

namespace LinkedListTests
{
    public class RemoveNthNodeFromEndOfListTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
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
            var expected = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(5)
                    }
                }
            };
            var actual = sln.RemoveNthFromEnd(head, 2);
            while (true)
            {
                if (expected == null) return;
                Assert.Equal(expected.val, actual.val);
                expected = expected.next;
                actual = actual.next;
            }
        }

        [Fact]
        public void TestCase3()
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
            var expected = new ListNode(1)
            {
                next = new ListNode(3)
                {
                    next = new ListNode(4)
                    {
                        next = new ListNode(5)
                    }
                }
            };
            var actual = sln.RemoveNthFromEnd(head, 4);
            while (true)
            {
                if (expected == null) return;
                Assert.Equal(expected.val, actual.val);
                expected = expected.next;
                actual = actual.next;
            }
        }

        [Fact]
        public void TestCase2()
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
            var expected = new ListNode(2)
            {
                next = new ListNode(3)
                {
                    next = new ListNode(4)
                    {
                        next = new ListNode(5)
                    }
                }
            };
            var actual = sln.RemoveNthFromEnd(head, 5);
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