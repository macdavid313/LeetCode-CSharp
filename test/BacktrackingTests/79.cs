/*
 * File: 79.cs
 * Project: BacktrackingTests
 * Created Date: Sunday, 13th September 2020 4:05:04 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using WordSearch;

namespace BacktrackingTests
{
    public class WordSearchTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var board = new char[][]
            {
                new char[] {'A', 'B', 'C', 'E' },
                new char[] {'S', 'F', 'C', 'S' },
                new char[] {'A', 'D', 'E', 'E' }
            };
            var word = "ABCCED";
            var expected = true;
            var actual = sln.Exist(board, word);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var board = new char[][]
            {
                new char[] {'A', 'B', 'C', 'E' },
                new char[] {'S', 'F', 'C', 'S' },
                new char[] {'A', 'D', 'E', 'E' }
            };
            var word = "FCSX";
            var expected = false;
            var actual = sln.Exist(board, word);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var board = new char[][]
            {
                new char[] {'A', 'B', 'C', 'E' },
                new char[] {'S', 'F', 'C', 'S' },
                new char[] {'A', 'D', 'E', 'E' }
            };
            var word = "SEE";
            var expected = true;
            var actual = sln.Exist(board, word);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase4()
        {
            var board = new char[][]
            {
                new char[] {'A', 'B', 'C', 'E' },
                new char[] {'S', 'F', 'C', 'S' },
                new char[] {'A', 'D', 'E', 'E' }
            };
            var word = "ABCB";
            var expected = false;
            var actual = sln.Exist(board, word);
            Assert.Equal(expected, actual);
        }
    }
}