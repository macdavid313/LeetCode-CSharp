/*
 * File: 268MissingNumber.cs
 * Project: Math
 * Created Date: Saturday, 29th August 2020 12:14:23 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 112 ms, faster than 78.68% of C# online submissions for Missing Number.
 * Memory Usage: 29.6 MB, less than 42.51% of C# online submissions for Missing Number.
 * Copyright (c) David Gu 2020
 */


namespace MissingNumber
{
    public class Solution
    {
        /*
        * Another good solution that avoids overflow
        * Runtime: 108 ms, faster than 90.20% of C# online submissions for Missing Number.
        * Memory Usage: 29.3 MB, less than 85.30% of C# online submissions for Missing Number.        
        public int MissingNumber(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var missing = nums.Length;
            for (var i = 0; i < nums.Length; i++)
            {
                missing += i - nums[i];
            }
            return missing;
        }
        */

        public int MissingNumber(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var missing = nums.Length;
            for (var i = 0; i < nums.Length; i++)
            {
                /* 
                * 异或运算（XOR）满足结合律
                * 对一个数进行两次完全相同的异或运算会得到原来的数                 
                */
                missing = missing ^ i ^ nums[i];
            }
            return missing;
        }
    }
}