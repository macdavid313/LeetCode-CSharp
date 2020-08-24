/*
 * File: 224BasicCalculator.cs
 * Project: Stack
 * Created Date: Monday, 24th August 2020 9:21:49 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 76 ms, faster than 95.27% of C# online submissions for Basic Calculator.
 * Memory Usage: 23.8 MB, less than 98.65% of C# online submissions for Basic Calculator.
 * Copyright (c) David Gu 2020
 */


namespace BasicCalculator
{
    using System;

    public class Solution
    {
        public int Calculate(string s)
        {
            var stack = new MyStackArray<int>();
            var num = 0;
            var result = 0;
            var sign = 1;

            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (char.IsDigit(c))
                {
                    num = num * 10 + Convert.ToInt32(c) - 48;
                }
                else if (c == '+')
                {
                    result += sign * num;
                    sign = 1;
                    num = 0;
                }
                else if (c == '-')
                {
                    result += sign * num;
                    sign = -1;
                    num = 0;
                }
                else if (c == '(')
                {
                    stack.Push(result);
                    stack.Push(sign);
                    sign = 1;
                    result = 0;
                }
                else if (c == ')')
                {
                    result += sign * num;
                    result *= stack.Pop();
                    result += stack.Pop();
                    num = 0;
                }
            }
            return result + (sign * num);
        }
    }

    public class MyStackArray<T>
    {
        T[] arr;
        int ptr;

        public MyStackArray()
        {
            arr = new T[1];
            ptr = 0;
        }

        public bool IsEmpty() => ptr == 0;

        public int Size() => ptr;

        public void Push(T item)
        {
            if (ptr == arr.Length)
            {
                Array.Resize(ref arr, arr.Length * 2);
            }
            arr[ptr] = item;
            ptr += 1;
        }

        public T Pop()
        {
            if (ptr == 0)
            {
                throw new InvalidProgramException("Can't pop from an empty stack");
            }
            ptr -= 1;
            var item = arr[ptr];
            arr[ptr] = default;
            if (ptr > 0 && ptr == arr.Length / 4)
            {
                Array.Resize(ref arr, arr.Length / 2);
            }
            return item;
        }
    }
}