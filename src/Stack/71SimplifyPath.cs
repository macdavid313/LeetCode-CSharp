/*
 * File: 71SimplifyPath.cs
 * Project: Stack
 * Created Date: Wednesday, 26th August 2020 7:03:06 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 108 ms, faster than 42.92% of C# online submissions for Simplify Path.
 * Memory Usage: 24.5 MB, less than 99.54% of C# online submissions for Simplify Path.
 * Copyright (c) David Gu 2020
 */


using System;
using System.Text;

namespace SimplifyPath
{
    public class Solution
    {
        /* A shorter solution by using String.Split
         * potentially with worse performance
         * Runtime: 192 ms, faster than 5.02% of C# online submissions for Simplify Path.
         * Memory Usage: 25 MB, less than 72.15% of C# online submissions for Simplify Path.
         * using System.Linq;
        public string SimplifyPath(string path)
        {
            if (path.Length == 1) return "/";
            var stack = new MyStackArray<string>();
            var files = path.Split('/').Where(file => file.Length != 0 && file != ".");
            foreach (var file in files)
            {
                if (file == "..")
                {
                    if (!stack.IsEmpty())
                        stack.Pop();
                }
                else
                {
                    stack.Push(file);
                }
            }
            return "/" + String.Join("/", stack.AsReversedArray());
        } */

        public string SimplifyPath(string path)
        {
            if (path.Length == 1) return "/";

            var stack = new MyStackArray<string>();
            var sb = new StringBuilder();
            var i = 0;
            while (i != path.Length)
            {
                switch (path[i])
                {
                    case '.':
                        i += 1;
                        sb.Append('.');
                        continue;
                    case '/':
                        i += 1;
                        while (i != path.Length && path[i] == '/')
                            i += 1;
                        PushDir(stack, sb);
                        continue;
                    default:
                        sb.Append(path[i]);
                        i += 1;
                        continue;
                }
            }
            if (sb.Length != 0)
                PushDir(stack, sb);
            return "/" + String.Join("/", stack.AsReversedArray());
        }

        void PushDir(MyStackArray<string> stack, StringBuilder sb)
        {
            var dir = sb.ToString();
            sb.Clear();
            switch (dir)
            {
                case "":
                    return;
                case ".":
                    return;
                case "..":
                    if (!stack.IsEmpty())
                        stack.Pop();
                    return;
                default:
                    stack.Push(dir);
                    return;
            }
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

        public bool IsEmpty() => ptr == 0;

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

        public T[] AsReversedArray()
        {
            var res = new T[Size];
            Array.Copy(arr, res, Size);
            return res;
        }
    }
}