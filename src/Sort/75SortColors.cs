/*
 * File: 75SortColors.cs
 * Project: Sort
 * Created Date: Wednesday, 7th October 2020 8:27:41 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 224 ms, faster than 98.70% of C# online submissions for Sort Colors.
 * Memory Usage: 30.3 MB, less than 19.85% of C# online submissions for Sort Colors.
 * -----
 * Last Modified: Wednesday, 7th October 2020 9:01:12 am
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


namespace SortColors
{
    public class Solution
    {
        static int[] _nums;
        public void SortColors(int[] nums)
        {
            _nums = nums;
            if (_nums.Length == 1) return;
            var (i, lo, hi) = (0, 0, _nums.Length - 1);
            var pivot = 1;
            while (i <= hi)
            {
                var cmp = nums[i].CompareTo(pivot);
                if (cmp < 0)
                {
                    Swap(i, lo);
                    i += 1;
                    lo += 1;
                }
                else if (cmp > 0)
                {
                    Swap(i, hi);
                    hi -= 1;
                }
                else i += 1;
            }
        }

        void Swap(int i, int j)
        {
            var tmp = _nums[i];
            _nums[i] = _nums[j];
            _nums[j] = tmp;
        }
    }
}