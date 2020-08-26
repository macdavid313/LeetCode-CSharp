/*
 * File: 20ValidParentheses.cs
 * Project: Stack
 * Created Date: Wednesday, 26th August 2020 12:30:16 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 72 ms, faster than 89.18% of C# online submissions for Valid Parentheses.
 * Memory Usage: 21.6 MB, less than 90.66% of C# online submissions for Valid Parentheses.
 * Copyright (c) David Gu 2020
 */


using System;

namespace ValidParentheses
{
    public class Solution
    {
        public bool IsValid(string s)
        {
            if (s.Length == 0) return true;
            if (s.Length % 2 == 1) return false;

            Span<char> chars = stackalloc char[s.Length / 2 + 1];
            var stack = new MyStackSpan<char>(chars);
            foreach (char c in s)
            {
                switch (c)
                {
                    case ')':
                        if (!stack.IsEmpty() && stack.Pop() != '(')
                            return false;
                        continue;
                    case '}':
                        if (!stack.IsEmpty() && stack.Pop() != '{')
                            return false;
                        continue;
                    case ']':
                        if (!stack.IsEmpty() && stack.Pop() != '[')
                            return false;
                        continue;
                    default:
                        stack.Push(c);
                        continue;
                }
            }
            return stack.IsEmpty();
        }
    }

    ref struct MyStackSpan<T>
    {
        readonly Span<T> memory;
        int ptr;

        public int Size { get => ptr; }

        public int MaxCapacity { get => memory.Length; }

        public MyStackSpan(Span<T> memory)
        {
            this.memory = memory;
            ptr = 0;
        }

        public bool IsEmpty() => ptr == 0;

        public void Push(T item)
        {
            if (Size == MaxCapacity)
            {
                throw new InvalidOperationException("Stack is full, can't push anymore.");
            }
            memory[ptr] = item;
            ptr += 1;
        }

        public T Pop()
        {
            if (Size == 0)
            {
                throw new InvalidProgramException("Can't pop from an empty stack");
            }
            ptr -= 1;
            var item = memory[ptr];
            memory[ptr] = default;
            return item;
        }
    }
}