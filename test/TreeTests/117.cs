/*
 * File: 117.cs
 * Project: TreeTests
 * Created Date: Monday, 28th September 2020 6:56:25 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Monday, 28th September 2020 7:00:48 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using PopulatingNextRightPointersInEachNodeII;

namespace TreeTests
{
    public class PopulatingNextRightPointersInEachNodeIITest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var root = new Node(1)
            {
                left = new Node(2)
                {
                    left = new Node(4)
                    {
                        left = new Node(7)
                    },
                    right = new Node(5)
                },
                right = new Node(3)
                {
                    right = new Node(6)
                    {
                        right = new Node(8)
                    }
                }
            };
            var actual = sln.Connect(root);
            Assert.Null(actual.next);
        }
    }
}