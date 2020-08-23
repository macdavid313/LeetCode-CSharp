/*
 * File: 60Pow_x_n.cs
 * Project: Math
 * Created Date: Monday, 24th August 2020 7:39:59 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 80 ms, faster than 15.96% of C# online submissions for Pow(x, n).
 * Memory Usage: 15 MB, less than 87.23% of C# online submissions for Pow(x, n).
 * Copyright (c) David Gu 2020
 */


namespace MyPow
{
    public class Solution
    {
        public double MyPow(double x, int n)
        {
            return n switch
            {
                0 => 1.0,
                1 => x,
                -1 => 1 / x,
                _ => n % 2 == 0 ? MyPow(x * x, n / 2) : x * MyPow(x, n - 1)
            };
        }
    }
}