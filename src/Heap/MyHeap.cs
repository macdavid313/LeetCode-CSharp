/*
 * File: MyHeap.cs
 * Project: Heap
 * Created Date: Monday, 14th September 2020 9:15:28 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


namespace MyHeap
{
    public interface IHeap<T>
    {
        public bool IsEmpty();

        public void Insert(T item);

        public T FindM();

        public T DeleteM();

        public IHeap<T> Merge(IHeap<T> heap1, IHeap<T> heap2);
    }
}