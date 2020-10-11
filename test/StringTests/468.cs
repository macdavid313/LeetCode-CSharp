/*
 * File: 468.cs
 * Project: StringTests
 * Created Date: Sunday, 11th October 2020 2:18:16 pm
 * Author: David Gu (macdavid313@gmail.com)
 * -----
 * Last Modified: Sunday, 11th October 2020 2:24:58 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using Xunit;
using ValidateIPAddress;

namespace StringTests
{
    public class ValidateIPAddressTest
    {
        readonly Solution sln = new Solution();

        [Fact]
        public void TestCase1()
        {
            var IP = "2001:0db8:85a3:0:0:8A2E:0370:7334";
            Assert.Equal("IPv6", sln.ValidIPAddress(IP));
        }

        [Fact]
        public void TestCase2()
        {
            var IP = "2001:0db8:85a3:0000:0:8A2E:0370:733a";
            Assert.Equal("IPv6", sln.ValidIPAddress(IP));
        }
    }
}