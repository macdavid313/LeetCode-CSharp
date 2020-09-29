/*
 * File: 332.cs
 * Project: GraphTests
 * Created Date: Tuesday, 29th September 2020 8:35:18 am
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Tuesday, 29th September 2020 9:46:00 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using ReconstructItinerary;

namespace GraphTests
{
    public class ReconstructItineraryTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var tickets = new string[][]
            {
                new string[] { "MUC", "LHR" },
                new string[] { "JFK", "MUC" },
                new string[] { "SFO", "SJC" },
                new string[] { "LHR", "SFO" }
            };
            var expected = new string[] { "JFK", "MUC", "LHR", "SFO", "SJC" };
            var actual = sln.FindItinerary(tickets);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var tickets = new string[][]
            {
                new string[] { "JFK", "SFO" },
                new string[] { "JFK", "ATL" },
                new string[] { "SFO", "ATL" },
                new string[] { "ATL", "JFK" },
                new string[] { "ATL", "SFO" }
            };
            var expected = new string[] { "JFK", "ATL", "JFK", "SFO", "ATL", "SFO" };
            var actual = sln.FindItinerary(tickets);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var tickets = new string[][]
            {
                new string[] { "EZE", "AXA" },
                new string[] { "TIA", "ANU" },
                new string[] { "ANU", "JFK" },
                new string[] { "JFK", "ANU" },
                new string[] { "ANU", "EZE" },
                new string[] { "TIA", "ANU" },
                new string[] { "AXA", "TIA" },
                new string[] { "TIA", "JFK" },
                new string[] { "ANU", "TIA" },
                new string[] { "JFK", "TIA" }
            };
            var expected = new string[] { "JFK", "ANU", "EZE", "AXA", "TIA", "ANU", "JFK", "TIA", "ANU", "TIA", "JFK" };
            var actual = sln.FindItinerary(tickets);
            Assert.Equal(expected, actual);
        }
    }
}