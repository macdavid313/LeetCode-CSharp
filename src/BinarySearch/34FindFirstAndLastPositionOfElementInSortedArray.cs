/*
 * File: 34FindFirstAndLastPositionOfElementInSortedArray.cs
 * Project: BinarySearch
 * Created Date: Wednesday, 9th September 2020 3:11:14 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 * Runtime: 240 ms, faster than 93.29% of C# online submissions for Find First and Last Position of Element in Sorted Array.
 * Memory Usage: 31.6 MB, less than 84.29% of C# online submissions for Find First and Last Position of Element in Sorted Array.
 */


namespace FindFirstAndLastPositionOfElementInSortedArray
{
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            BinarySearch(nums, target, out int left, out int right);
            return new int[] { left, right };
        }

        static void BinarySearch(int[] nums, int target, out int left, out int right)
        {
            left = 0;
            right = nums.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] > target) right = mid - 1;
                else if (nums[mid] < target) left = mid + 1;
                else
                {
                    left = SearchLeft(nums, target, 0, mid);
                    right = SearchRight(nums, target, mid, nums.Length - 1);
                    return;
                }
            }
            left = -1;
            right = -1;
        }

        static int SearchLeft(int[] nums, int target, int lo, int hi)
        {
            while (lo < hi)
            {
                var mid = lo + (hi - lo) / 2;
                if (nums[mid] == target) hi = mid;
                else lo = mid + 1;
            }
            return lo;
        }

        static int SearchRight(int[] nums, int target, int lo, int hi)
        {
            while (lo < hi)
            {
                var mid = lo + (hi - lo) / 2;
                // really strange corner case ...
                if (lo == mid && lo + 1 == hi) return nums[hi] == target ? hi : lo;
                if (nums[mid] == target) lo = mid;
                else hi = mid - 1;
            }
            return lo;
        }
    }

    /* 
    * Runtime: 244 ms, faster than 85.73% of C# online submissions for Find First and Last Position of Element in Sorted Array.
    * Memory Usage: 31.6 MB, less than 82.49% of C# online submissions for Find First and Last Position of Element in Sorted Array.
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var l = BinarySearchLeftMost(nums, target);
            if (l == -1) return new int[] { -1, -1 };
            return new int[] { l, BinarySearchRightMost(nums, target) };
        }

        int BinarySearchLeftMost(int[] nums, int target)
        {
            var lo = 0;
            var hi = nums.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                if (nums[mid] < target) lo = mid + 1;
                else hi = mid - 1;
            }
            if (lo < nums.Length && nums[lo] == target) return lo;
            return -1;
        }

        int BinarySearchRightMost(int[] nums, int target)
        {
            var lo = 0;
            var hi = nums.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                if (nums[mid] > target) hi = mid - 1;
                else lo = mid + 1;
            }
            if (hi >= 0 && nums[hi] == target) return hi;
            return -1;
        }
    } */
}