/*
 * File: 23.cs
 * Project: DivideAndConquerTests
 * Created Date: Friday, 4th September 2020 8:41:37 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using MergeKSortedLists;

namespace DivideAndConquerTests
{
    public class MergeKSortedListsTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var lst1 = new ListNode(1)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(5)
                }
            };
            var lst2 = new ListNode(1)
            {
                next = new ListNode(3)
                {
                    next = new ListNode(4)
                }
            };
            var lst3 = new ListNode(2)
            {
                next = new ListNode(6)
            };
            var lists = new ListNode[] { lst1, lst2, lst3 };
            var expected = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(3)
                        {
                            next = new ListNode(4)
                            {
                                next = new ListNode(4)
                                {
                                    next = new ListNode(5)
                                    {
                                        next = new ListNode(6)
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var actual = sln.MergeKLists(lists);
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