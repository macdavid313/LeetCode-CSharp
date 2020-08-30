/*
 * File: 264UglyNumberII.cs
 * Project: DynamicProgramming
 * Created Date: Friday, 28th August 2020 9:28:37 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 40 ms, faster than 98.53% of C# online submissions for Ugly Number II.
 * Memory Usage: 14.6 MB, less than 98.38% of C# online submissions for Ugly Number II.
 * Copyright (c) David Gu 2020
 */


using System;

namespace UglyNumberII
{
    public class Solution
    {
        public int NthUglyNumber(int n)
        {
            return UglyNumberSequence.NumAt(n);
        }
    }

    class UglyNumberSequence
    {
        readonly static int maxLen = 1690;
        readonly static int[] sequence = new int[maxLen];

        static UglyNumberSequence()
        {
            /*
            * 一开始，丑数只有{1}，1可以同2，3，5相乘，取最小的1×2=2添加到丑数序列中。
            * 现在丑数中有{1，2}，在上一步中，1已经同2相乘过了，所以今后没必要再比较1×2了，我们说1失去了同2相乘的资格。
            * 现在1有与3，5相乘的资格，2有与2，3，5相乘的资格，但是2×3和2×5是没必要比较的，因为有比它更小的1可以同3，5相乘，所以我们只需要比较1×3，1×5，2×2。
            * 依此类推，每次我们都分别比较有资格同2，3，5相乘的最小丑数，选择最小的那个作为下一个丑数，假设选择到的这个丑数是同i（i=2，3，5）相乘得到的，所以它失去了同i相乘的资格，把对应的pi++，让pi指向下一个丑数即可。

            * 作者：zzxn
            * 链接：https://leetcode-cn.com/problems/ugly-number-ii/solution/san-zhi-zhen-fang-fa-de-li-jie-fang-shi-by-zzxn/
            * 来源：力扣（LeetCode）
            * 著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
            */
            sequence[0] = 1;
            var i2 = 0;
            var i3 = 0;
            var i5 = 0;
            for (var idx = 1; idx < maxLen; idx++)
            {
                var factor = Min(sequence[i2] * 2, sequence[i3] * 3, sequence[i5] * 5);
                sequence[idx] = factor;
                if (factor == sequence[i2] * 2) i2 += 1;
                if (factor == sequence[i3] * 3) i3 += 1;
                if (factor == sequence[i5] * 5) i5 += 1;
            }
        }

        public static int NumAt(int nth)
        {
            if (nth < 1)
                throw new InvalidOperationException(nameof(nth));
            return sequence[nth - 1];
        }

        static int Min(int x, int y, int z) => x < y ? Math.Min(x, z) : Math.Min(y, z);
    }
}