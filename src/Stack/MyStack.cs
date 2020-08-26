/*
 * File: MyStack.cs
 * Project: Stack
 * Created Date: Monday, 24th August 2020 4:26:37 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 112 ms, faster than 47.72% of C# online submissions for Trapping Rain Water.
 * Memory Usage: 25.3 MB, less than 19.37% of C# online submissions for Trapping Rain Water.
 * Copyright (c) David Gu 2020
 */


using System;

namespace MyStack
{
    /* interface IMyStack<T>
    {
        bool IsEmpty();
        int Size();
        void Push(T item);
        T Pop();
    } */

    class LinkedListNode<T>
    {
        public T Value { get; private set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T value)
        {
            this.Value = value;
            Next = null;
        }
    }

    public class MyStackLinkedList<T>
    {
        LinkedListNode<T> top;

        public int Size { get; private set; }

        public MyStackLinkedList() { }

        public bool IsEmpty() => Size == 0;

        public void Push(T item)
        {
            var oldTop = top;
            top = new LinkedListNode<T>(item)
            {
                Next = oldTop
            };
            Size += 1;
        }

        public T Pop()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Can't pop from an empty stack");
            }
            T item = top.Value;
            top = top.Next;
            Size -= 1;
            return item;
        }
    }

    public class MyStackArray<T>
    {
        T[] arr;
        int ptr;

        public int Size { get => ptr; }

        public MyStackArray()
        {
            arr = new T[1];
            ptr = 0;
        }

        public bool IsEmpty() => Size == 0;

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