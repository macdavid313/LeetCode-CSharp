/*
 * File: MyTreeTest.cs
 * Project: TreeTests
 * Created Date: Sunday, 6th September 2020 5:13:45 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;
using Xunit;
using MyTree;

namespace TreeTests
{
    public class BinarySearchTreeTest
    {
        static BinarySearchTree<char, char> GetBinarySearchTree()
        {
            var bst = new BinarySearchTree<char, char>();
            var chars = new char[] { 'S', 'E', 'X', 'A', 'R', 'C', 'H', 'M' };
            foreach (var c in chars)
            {
                bst.Put(c, c);
            }
            return bst;
        }

        [Fact]
        public void TestGet()
        {
            var bst = GetBinarySearchTree();
            var chars = new char[] { 'S', 'E', 'X', 'A', 'R', 'C', 'H', 'M' };
            foreach (var c in chars)
            {
                var expected = c;
                var actual = bst.Get(c);
                Assert.Equal(expected, actual);
            }
            Assert.Throws<ArgumentException>(() => bst.Get('G'));
        }

        [Fact]
        public void TestDelete()
        {
            var bst = GetBinarySearchTree();
            var chars = new char[] { 'S', 'E', 'X', 'A', 'R', 'C', 'H', 'M' };
            for (var i = chars.Length - 1; i >= 0; i--)
            {
                Assert.Equal(i + 1, bst.Size());
                bst.Delete(chars[i]);
                Assert.Equal(i, bst.Size());
            }
        }

        [Fact]
        public void TestSize()
        {
            var bst = GetBinarySearchTree();
            var expected = 8;
            var actual = bst.Size();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDeleteMin()
        {
            var bst = GetBinarySearchTree();
            var size = bst.Size();
            var chars = new char[] { 'S', 'E', 'X', 'A', 'R', 'C', 'H', 'M' };
            Array.Sort(chars);
            for (var i = 0; i < chars.Length; i++)
            {
                Assert.Equal(chars[i], bst.Min());
                bst.DeleteMin();
                Assert.Equal(size - i - 1, bst.Size());
            }
        }

        [Fact]
        public void TestDeleteMax()
        {
            var bst = GetBinarySearchTree();
            var size = bst.Size();
            var chars = new char[] { 'S', 'E', 'X', 'A', 'R', 'C', 'H', 'M' };
            Array.Sort(chars);
            Array.Reverse(chars);
            for (var i = 0; i < chars.Length; i++)
            {
                Assert.Equal(chars[i], bst.Max());
                bst.DeleteMax();
                Assert.Equal(size - i - 1, bst.Size());
            }
        }

        [Fact]
        public void TestMin()
        {
            var bst = GetBinarySearchTree();
            var expected = 'A';
            var actual = bst.Min();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMax()
        {
            var bst = GetBinarySearchTree();
            var expected = 'X';
            var actual = bst.Max();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestFloor()
        {
            var bst = GetBinarySearchTree();
            var expected = 'E';
            var actual = bst.Floor('G');
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCeiling()
        {
            var bst = GetBinarySearchTree();
            var expected = 'H';
            var actual = bst.Ceiling('G');
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSelect()
        {
            var bst = GetBinarySearchTree();
            var expected = 'H';
            var actual = bst.Select(3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRank()
        {
            var bst = GetBinarySearchTree();
            var expected = 2;
            var actual = bst.Rank('E');
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestEnumerator()
        {
            var bst = GetBinarySearchTree();
            var expected = new char[] { 'S', 'E', 'X', 'A', 'R', 'C', 'H', 'M' };
            var actual = new List<char>();
            foreach (var (k, _) in bst)
            {
                actual.Add(k);
            }
            Array.Sort(expected);
            actual.Sort();
            Assert.Equal(expected, actual.ToArray());
        }
    }

    public class LeftLeaningRedBlackTreeTest
    {
        static LeftLeaningRedBlackTree<char, char> GetLeftLeaningRedBlackTree()
        {
            var tree = new LeftLeaningRedBlackTree<char, char>();
            var elems = "MJRELPXCHSA";
            foreach (var c in elems)
            {
                tree.Put(c, c);
            }
            return tree;
        }

        [Fact]
        public void TestGet()
        {
            var tree = GetLeftLeaningRedBlackTree();
            Assert.Equal(11, tree.Size());
            var elems = "MJRELPXCHSA";
            foreach (var c in elems)
            {
                Assert.Equal(c, tree.Get(c));
            }
            Assert.Throws<KeyNotFoundException>(() => tree.Get('Z'));
        }
    }

}