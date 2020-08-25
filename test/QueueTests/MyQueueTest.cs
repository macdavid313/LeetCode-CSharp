/*
 * File: MyQueueTest.cs
 * Project: QueueTests
 * Created Date: Tuesday, 25th August 2020 5:32:53 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using MyQueue;

namespace QueueTests
{
    public class MyQueueTest
    {
        [Fact]
        public void TestEmptyQueue()
        {
            var myQueueLinkedList = new MyQueueLinkedList<object>();
            Assert.Equal(0, myQueueLinkedList.Size);
            var myQueueArray = new MyQueueArray<object>();
            Assert.Equal(0, myQueueArray.Size);
        }

        [Fact]
        public void TestLinkedListImplementation()
        {
            // data -> to be or not to - be - - that - - - is
            var queue = new MyQueueLinkedList<string>();
            queue.Enqueue("to");
            queue.Enqueue("be");
            queue.Enqueue("or");
            queue.Enqueue("not");
            queue.Enqueue("to");
            Assert.Equal("to", queue.Dequeue());
            queue.Enqueue("be");
            Assert.Equal("be", queue.Dequeue());
            Assert.Equal("or", queue.Dequeue());
            queue.Enqueue("that");
            Assert.Equal("not", queue.Dequeue());
            Assert.Equal("to", queue.Dequeue());
            Assert.Equal("be", queue.Dequeue());
            queue.Enqueue("is");
            Assert.Equal(2, queue.Size);
            Assert.Equal("that", queue.Dequeue());
            Assert.Equal("is", queue.Dequeue());
        }

        [Fact]
        public void TestArrayImplementation()
        {
            // data -> to be or not to - be - - that - - - is
            var queue = new MyQueueArray<string>();
            queue.Enqueue("to");
            queue.Enqueue("be");
            queue.Enqueue("or");
            queue.Enqueue("not");
            queue.Enqueue("to");
            Assert.Equal("to", queue.Dequeue());
            queue.Enqueue("be");
            Assert.Equal("be", queue.Dequeue());
            Assert.Equal("or", queue.Dequeue());
            queue.Enqueue("that");
            Assert.Equal("not", queue.Dequeue());
            Assert.Equal("to", queue.Dequeue());
            Assert.Equal("be", queue.Dequeue());
            queue.Enqueue("is");
            Assert.Equal(2, queue.Size);
            Assert.Equal("that", queue.Dequeue());
            Assert.Equal("is", queue.Dequeue());
        }
    }
}