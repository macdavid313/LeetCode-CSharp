/*
 * File: 933.cs
 * Project: QueueTests
 * Created Date: Tuesday, 25th August 2020 6:16:07 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using NumberOfRecentCalls;

namespace QueueTests
{
    public class NumberOfRecentCallsTest
    {
        [Fact]
        public void TestBase()
        {
            var recentCounter = new RecentCounter();
            Assert.Equal(1, recentCounter.Ping(1));
            Assert.Equal(2, recentCounter.Ping(100));
            Assert.Equal(3, recentCounter.Ping(3001));
            Assert.Equal(3, recentCounter.Ping(3002));
        }
    }
}