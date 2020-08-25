/*
 * File: 933NumberOfRecentCalls.cs
 * Project: Queue
 * Created Date: Tuesday, 25th August 2020 6:06:00 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 332 ms, faster than 86.67% of C# online submissions for Number of Recent Calls.
 * Memory Usage: 47.2 MB, less than 72.22% of C# online submissions for Number of Recent Calls.
 * Copyright (c) David Gu 2020
 */


using System;

namespace NumberOfRecentCalls
{
    public class RecentCounter
    {
        readonly MyQueueArray<int> q;

        public RecentCounter()
        {
            q = new MyQueueArray<int>();
        }

        public int Ping(int t)
        {
            q.Enqueue(t);
            while (q.Peek() < t - 3000 && q.Size != 0)
            {
                q.Dequeue();
            }
            return q.Size;
        }
    }

    public class MyQueueArray<T>
    {
        T[] arr;
        int head;
        int tail;

        public int Size { get => tail - head; }

        public MyQueueArray()
        {
            arr = new T[1];
            head = 0;
            tail = 0;
        }

        public bool IsEmpty() => Size == 0;

        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
            return arr[head];
        }

        void Resize(int newSize)
        {
            T[] newArr = new T[newSize];
            for (var i = head; i < tail; i++)
            {
                // int offset = i - head;
                newArr[i - head] = arr[i];
            }
            tail -= head;
            head = 0;
            arr = newArr;
        }

        public void Enqueue(T item)
        {
            if (tail == arr.Length)
            {
                // shrink            
                if (Size == arr.Length / 4)
                {
                    Resize(arr.Length / 2);
                }
                else // extend
                {
                    Resize(arr.Length * 2);
                }
            }
            arr[tail] = item;
            tail += 1;
        }

        public T Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Can't dequeue from an empty queue");
            }
            // shrink
            if (Size == arr.Length / 4)
            {
                Resize(arr.Length / 2);
            }
            var item = arr[head];
            arr[head] = default;
            head += 1;
            return item;
        }
    }
}