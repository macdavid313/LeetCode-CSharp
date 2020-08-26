/*
 * File: 42TrappingRainWater.cs
 * Project: Stack
 * Created Date: Wednesday, 26th August 2020 9:28:25 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 96 ms, faster than 76.83% of C# online submissions for Trapping Rain Water.
 * Memory Usage: 24.9 MB, less than 81.69% of C# online submissions for Trapping Rain Water.
 * Copyright (c) David Gu 2020
 */


using System;

namespace TrappingRainWater
{
    public class Solution
    {
        public int Trap(int[] height)
        {
            if (height.Length <= 0) return 0;
            var start = 0;
            var end = 0;
            var maxH = -1;
            var res = 0;
            while (end != height.Length)
            {
                var h = height[end];
                if (maxH == -1 && h == 0)
                {
                    end += 1;
                    continue;
                }
                if (maxH == -1)
                {
                    maxH = h;
                    start = end;
                    end += 1;
                }
                else if (h <= maxH)
                {
                    end += 1;
                    continue;
                }
                else
                {
                    maxH = -1;
                    res += ComputeTrap(height, start, end);
                }
            }
            res += ComputeTrap(height, start, end - 1);
            return res;
        }

        int ComputeTrap(int[] height, int start, int end)
        {
            if (start == end) return 0;
            var count = 0;
            if (height[end] >= height[start])
            {
                var h = height[start];
                for (var i = start + 1; i < end; i++)
                {
                    count += h - height[i];
                }
                return count;
            }
            else
            {
                while (end != start)
                {
                    if (height[end] > height[end - 1])
                        break;
                    end -= 1;
                }
                var slice = height[start..(end + 1)];
                Array.Reverse(slice);
                return Trap(slice);
            }
        }
    }
}