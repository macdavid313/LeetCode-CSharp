/*
 * File: 155MinStack.cs
 * Project: Stack
 * Created Date: Wednesday, 9th September 2020 8:43:29 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace MyMinStack
{
    public class MinStack
    {
        readonly Stack<int> stack;
        readonly Stack<int> minStack;
        public int Size { get; private set; }

        /** initialize your data structure here. */
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
            minStack.Push(int.MaxValue);
            Size = 0;
        }

        public void Push(int x)
        {
            stack.Push(x);
            minStack.Push(Math.Min(minStack.Peek(), x));
            Size += 1;
        }

        public void Pop()
        {
            if (Size == 0)
                throw new InvalidOperationException();
            stack.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            if (Size == 0)
                throw new InvalidOperationException();
            return stack.Peek();
        }

        public int GetMin()
        {
            if (Size == 0)
                throw new InvalidOperationException();
            return minStack.Peek();
        }
    }
}