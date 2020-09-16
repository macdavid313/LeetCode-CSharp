/*
 * File: 128.cs
 * Project: UnionFindTests
 * Created Date: Saturday, 22nd August 2020 6:43:01 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using LongestConsecutiveSequence;

namespace UnionFindTests
{
    public class LongestConsecutiveSequenceTest
    {
        readonly Solution sln = new Solution();
        readonly Solution2 sln2 = new Solution2();

        [Fact]
        public void TestEmptyArray()
        {
            var nums = System.Array.Empty<int>();
            var len = sln.LongestConsecutive(nums);
            Assert.Equal(0, len);
            Assert.Equal(len, sln2.LongestConsecutive(nums));
        }

        [Fact]
        public void TestBase()
        {
            var nums = new int[] { 100, 4, 200, 1, 3, 2 };
            var len = sln.LongestConsecutive(nums);
            Assert.Equal(4, len);
            Assert.Equal(len, sln2.LongestConsecutive(nums));
        }

        [Fact]
        public void TestDuplicateElements()
        {
            var nums1 = new int[] { 0, 0 };
            var len1 = sln.LongestConsecutive(nums1);
            var nums2 = new int[] { 0, 0, -1 };
            var len2 = sln.LongestConsecutive(nums2);
            Assert.Equal(1, len1);
            Assert.Equal(len1, sln2.LongestConsecutive(nums1));
            Assert.Equal(2, len2);
            Assert.Equal(len2, sln2.LongestConsecutive(nums2));
        }
    }
}
