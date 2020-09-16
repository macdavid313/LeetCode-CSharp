/*
 * File: 841.cs
 * Project: GraphTests
 * Created Date: Monday, 31st August 2020 7:10:31 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using KeysAndRooms;

namespace GraphTests
{
    public class KeysAndRoomsTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var rooms = new int[4][]
            {
                new int[] { 1 },
                new int[] { 2 },
                new int[] { 3 },
                System.Array.Empty<int>()
            };
            var expected = true;
            var actual = sln.CanVisitAllRooms(rooms);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var rooms = new int[4][]
            {
                new int[] { 1, 3 },
                new int[] { 3, 0, 1 },
                new int[] { 2 },
                new int[] { 0 }
            };
            var expected = false;
            var actual = sln.CanVisitAllRooms(rooms);
            Assert.Equal(expected, actual);
        }
    }
}