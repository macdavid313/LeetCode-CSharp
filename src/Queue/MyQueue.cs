/*
 * File: MyQueue.cs
 * Project: Queue
 * Created Date: Tuesday, 25th August 2020 12:20:55 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;

namespace MyQueue
{
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

    public class MyQueueLinkedList<T>
    {
        LinkedListNode<T> head;
        LinkedListNode<T> tail;

        public int Size { get; private set; }

        public MyQueueLinkedList()
        {
            head = null;
            tail = null;
            Size = 0;
        }

        public bool IsEmpty() => Size == 0;

        public void Enqueue(T item)
        {
            var next = new LinkedListNode<T>(item);
            if (Size == 0)
            {
                head = next;
                tail = next;
            }
            else
            {
                tail.Next = next;
                tail = next;
            }
            Size += 1;
        }

        public T Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Can't dequeue from an empty queue");
            }
            var item = head.Value;
            head = head.Next;
            if (head is null)
            {
                tail = null; // empty queue
            }
            Size -= 1;
            return item;
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