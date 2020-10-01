/*
 * File: 208.cs
 * Project: TriesTests
 * Created Date: Thursday, 1st October 2020 9:09:07 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Thursday, 1st October 2020 9:12:11 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using ImplementTrie;

namespace TriesTests
{
    public class ImplementTrieTest
    {
        [Fact]
        public void TestCase1()
        {
            var trie = new Trie();
            trie.Insert("apple");
            Assert.True(trie.Search("apple"));
            Assert.False(trie.Search("app"));
            Assert.True(trie.StartsWith("app"));
            trie.Insert("app");
            Assert.True(trie.Search("app"));
        }
    }
}