/*
 * File: MyQueueTest.cs
 * Project: QueueTests
 * Created Date: Tuesday, 25th August 2020 5:32:53 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using System;
using Xunit;
using MyQueue;
using System.Linq;
using System.Collections.Generic;

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

    public class MyPriorityQueueTest
    {
        readonly Random random = new Random();

        struct Foo
        {
            readonly int val;
            readonly static Comparer<Foo> defaultFooComparer = new FooComparer();

            public int Val { get => val; }
            public static Comparer<Foo> DefaultFooComparer { get => defaultFooComparer; }

            public Foo(int val)
            {
                this.val = val;
            }

            class FooComparer : Comparer<Foo>
            {
                public override int Compare(Foo x, Foo y)
                {
                    return x.Val.CompareTo(y.Val);
                }
            }
        }

        #region MinPriorityTest
        [Fact]
        public void TestMinPriorityQueueWithoutCapacity()
        {
            var minPQ = PriorityQueue<int>.MinPQ();
            Assert.Equal(0, minPQ.Count);
            Assert.Throws<InvalidOperationException>(() => minPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => minPQ.Peek());
            for (var i = 9; i >= 0; i--)
            {
                minPQ.Enqueue(i);
                Assert.Equal(10 - i, minPQ.Count);
            }
            for (var i = 0; i < 10; i++)
            {
                Assert.Equal(10 - i, minPQ.Count);
                Assert.Equal(i, minPQ.Peek());
                Assert.Equal(i, minPQ.Dequeue());
            }
            Assert.Throws<InvalidOperationException>(() => minPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => minPQ.Peek());
        }

        [Fact]
        public void TestMinPriorityQueueWithoutCapacityRandom()
        {
            var arr = new int[10000];
            var minPQ = PriorityQueue<int>.MinPQ();
            for (var i = 0; i < arr.Length; i++)
            {
                var x = random.Next(arr.Length);
                arr[i] = x;
                minPQ.Enqueue(x);
                Assert.Equal(i + 1, minPQ.Count);
            }
            Array.Sort(arr);
            for (var i = 0; i < arr.Length; i++)
            {
                Assert.Equal(arr[i], minPQ.Dequeue());
                Assert.Equal(arr.Length - i - 1, minPQ.Count);
            }
        }

        [Fact]
        public void TestMinPriorityQueueWithCapacity()
        {
            var minPQ = PriorityQueue<int>.MinPQ(10);
            Assert.Equal(0, minPQ.Count);
            Assert.Throws<InvalidOperationException>(() => minPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => minPQ.Peek());
            for (var i = 9; i >= 0; i--)
            {
                minPQ.Enqueue(i);
                Assert.Equal(10 - i, minPQ.Count);
            }
            for (var i = 0; i < 10; i++)
            {
                Assert.Equal(10 - i, minPQ.Count);
                Assert.Equal(i, minPQ.Peek());
                Assert.Equal(i, minPQ.Dequeue());
            }
            Assert.Throws<InvalidOperationException>(() => minPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => minPQ.Peek());
        }

        [Fact]
        public void TestMinPriorityQueueWithCapacityRandom()
        {
            var arr = new int[10000];
            var minPQ = PriorityQueue<int>.MinPQ(arr.Length);
            for (var i = 0; i < arr.Length; i++)
            {
                var x = random.Next(arr.Length);
                arr[i] = x;
                minPQ.Enqueue(x);
                Assert.Equal(i + 1, minPQ.Count);
            }
            Array.Sort(arr);
            for (var i = 0; i < arr.Length; i++)
            {
                Assert.Equal(arr[i], minPQ.Dequeue());
                Assert.Equal(arr.Length - i - 1, minPQ.Count);
            }
        }

        [Fact]
        public void TestMinPriorityQueueWithArray()
        {
            var arr = Enumerable.Range(0, 10).ToArray();
            var minPQ = PriorityQueue<int>.MinPQ(arr);
            Assert.Equal(arr.Length, minPQ.Count);
            foreach (var n in arr)
            {
                Assert.Equal(arr.Length - n, minPQ.Count);
                Assert.Equal(n, minPQ.Peek());
                Assert.Equal(n, minPQ.Dequeue());
            }
            Assert.Throws<InvalidOperationException>(() => minPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => minPQ.Peek());
        }

        [Fact]
        public void TestMinPriorityQueueWithArrayRandom()
        {
            var arr = new int[10000];
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                var x = random.Next(arr.Length);
                arr[i] = x;
            }
            var minPQ = PriorityQueue<int>.MinPQ(arr);
            Assert.Equal(arr.Length, minPQ.Count);
            Array.Sort(arr);
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                var n = arr[i];
                Assert.Equal(arr.Length - i, minPQ.Count);
                Assert.Equal(n, minPQ.Peek());
                Assert.Equal(n, minPQ.Dequeue());
            }
            Assert.Throws<InvalidOperationException>(() => minPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => minPQ.Peek());
        }

        [Fact]
        public void TestMinPriorityQueueWithGivenComparerOnly()
        {
            var arr = new Foo[10000];
            var minPQ = PriorityQueue<Foo>.MinPQ(Foo.DefaultFooComparer);
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                var foo = new Foo(random.Next(arr.Length));
                minPQ.Enqueue(foo);
                arr[i] = foo;
            }
            Assert.Equal(arr.Length, minPQ.Count);
            Array.Sort(arr, Foo.DefaultFooComparer);
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                Assert.Equal(arr[i].Val, minPQ.Peek().Val);
                Assert.Equal(arr[i].Val, minPQ.Dequeue().Val);
                Assert.Equal(arr.Length - i - 1, minPQ.Count);
            }
            Assert.Throws<InvalidOperationException>(() => minPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => minPQ.Peek());
        }

        [Fact]
        public void TestMinPriorityQueueWithGivenComparerAndCapacity()
        {
            var arr = new Foo[10000];
            var minPQ = PriorityQueue<Foo>.MinPQ(arr.Length, Foo.DefaultFooComparer);
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                var foo = new Foo(random.Next(arr.Length));
                minPQ.Enqueue(foo);
                arr[i] = foo;
            }
            Assert.Equal(arr.Length, minPQ.Count);
            Array.Sort(arr, Foo.DefaultFooComparer);
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                Assert.Equal(arr[i].Val, minPQ.Peek().Val);
                Assert.Equal(arr[i].Val, minPQ.Dequeue().Val);
                Assert.Equal(arr.Length - i - 1, minPQ.Count);
            }
            Assert.Throws<InvalidOperationException>(() => minPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => minPQ.Peek());
        }

        [Fact]
        public void TestMinPriorityQueueWithGivenComparerAndArray()
        {
            var arr = new Foo[10000];
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                var val = random.Next(arr.Length);
                arr[i] = new Foo(val);
            }
            var minPQ = PriorityQueue<Foo>.MinPQ(arr, Foo.DefaultFooComparer);
            Assert.Equal(arr.Length, minPQ.Count);
            Array.Sort(arr, Foo.DefaultFooComparer);
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                Assert.Equal(arr[i].Val, minPQ.Peek().Val);
                Assert.Equal(arr[i].Val, minPQ.Dequeue().Val);
                Assert.Equal(arr.Length - i - 1, minPQ.Count);
            }
            Assert.Throws<InvalidOperationException>(() => minPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => minPQ.Peek());
        }
        #endregion

        #region MaxPriorityTest
        [Fact]
        public void TestMaxPriorityQueueWithoutCapacity()
        {
            var maxPQ = PriorityQueue<int>.MaxPQ();
            Assert.Equal(0, maxPQ.Count);
            Assert.Throws<InvalidOperationException>(() => maxPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => maxPQ.Peek());
            for (var i = 0; i < 10; i++)
            {
                maxPQ.Enqueue(i);
                Assert.Equal(i + 1, maxPQ.Count);
            }
            for (var i = 9; i >= 0; i--)
            {
                Assert.Equal(i + 1, maxPQ.Count);
                Assert.Equal(i, maxPQ.Peek());
                Assert.Equal(i, maxPQ.Dequeue());
            }
            Assert.Throws<InvalidOperationException>(() => maxPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => maxPQ.Peek());
        }

        [Fact]
        public void TestMaxPriorityQueueWithoutCapacityRandom()
        {
            var arr = new int[10000];
            var maxPQ = PriorityQueue<int>.MaxPQ();
            for (var i = 0; i < arr.Length; i++)
            {
                var x = random.Next(arr.Length);
                arr[i] = x;
                maxPQ.Enqueue(x);
                Assert.Equal(i + 1, maxPQ.Count);
            }
            Array.Sort(arr);
            Array.Reverse(arr);
            for (var i = 0; i < arr.Length; i++)
            {
                Assert.Equal(arr[i], maxPQ.Dequeue());
                Assert.Equal(arr.Length - i - 1, maxPQ.Count);
            }
        }

        [Fact]
        public void TestMaxPriorityQueueWithCapacity()
        {
            var maxPQ = PriorityQueue<int>.MaxPQ(10);
            Assert.Equal(0, maxPQ.Count);
            Assert.Throws<InvalidOperationException>(() => maxPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => maxPQ.Peek());
            for (var i = 0; i < 10; i++)
            {
                maxPQ.Enqueue(i);
                Assert.Equal(i + 1, maxPQ.Count);
            }
            for (var i = 9; i >= 0; i--)
            {
                Assert.Equal(i + 1, maxPQ.Count);
                Assert.Equal(i, maxPQ.Peek());
                Assert.Equal(i, maxPQ.Dequeue());
            }
            Assert.Throws<InvalidOperationException>(() => maxPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => maxPQ.Peek());
        }

        [Fact]
        public void TestMaxPriorityQueueWithCapacityRandom()
        {
            var arr = new int[10000];
            var maxPQ = PriorityQueue<int>.MaxPQ(arr.Length);
            for (var i = 0; i < arr.Length; i++)
            {
                var x = random.Next(arr.Length);
                arr[i] = x;
                maxPQ.Enqueue(x);
                Assert.Equal(i + 1, maxPQ.Count);
            }
            Array.Sort(arr);
            Array.Reverse(arr);
            for (var i = 0; i < arr.Length; i++)
            {
                Assert.Equal(arr[i], maxPQ.Dequeue());
                Assert.Equal(arr.Length - i - 1, maxPQ.Count);
            }
        }

        [Fact]
        public void TestMaxPriorityQueueWithArray()
        {
            var arr = Enumerable.Range(0, 10).ToArray();
            var maxPQ = PriorityQueue<int>.MaxPQ(arr);
            Assert.Equal(arr.Length, maxPQ.Count);
            for (var i = 9; i >= 0; i--)
            {
                Assert.Equal(i + 1, maxPQ.Count);
                Assert.Equal(i, maxPQ.Peek());
                Assert.Equal(i, maxPQ.Dequeue());
            }
            Assert.Throws<InvalidOperationException>(() => maxPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => maxPQ.Peek());
        }

        [Fact]
        public void TestMaxPriorityQueueWithArrayRandom()
        {
            var arr = new int[10000];
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                var x = random.Next(arr.Length);
                arr[i] = x;
            }
            var maxPQ = PriorityQueue<int>.MaxPQ(arr);
            Assert.Equal(arr.Length, maxPQ.Count);
            Array.Sort(arr, new Comparison<int>((x, y) => y.CompareTo(x)));
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                var n = arr[i];
                Assert.Equal(arr.Length - i, maxPQ.Count);
                Assert.Equal(n, maxPQ.Peek());
                Assert.Equal(n, maxPQ.Dequeue());
            }
            Assert.Throws<InvalidOperationException>(() => maxPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => maxPQ.Peek());
        }

        [Fact]
        public void TestMaxPriorityQueueWithGivenComparerOnly()
        {
            var arr = new Foo[10000];
            var maxPQ = PriorityQueue<Foo>.MaxPQ(Foo.DefaultFooComparer);
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                var foo = new Foo(random.Next(arr.Length));
                maxPQ.Enqueue(foo);
                arr[i] = foo;
            }
            Assert.Equal(arr.Length, maxPQ.Count);
            Array.Sort(arr, new Comparison<Foo>((x, y) => Foo.DefaultFooComparer.Compare(y, x)));
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                Assert.Equal(arr[i].Val, maxPQ.Peek().Val);
                Assert.Equal(arr[i].Val, maxPQ.Dequeue().Val);
                Assert.Equal(arr.Length - i - 1, maxPQ.Count);
            }
            Assert.Throws<InvalidOperationException>(() => maxPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => maxPQ.Peek());
        }

        [Fact]
        public void TestMaxPriorityQueueWithGivenComparerAndCapacity()
        {
            var arr = new Foo[10000];
            var maxPQ = PriorityQueue<Foo>.MaxPQ(arr.Length, Foo.DefaultFooComparer);
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                var foo = new Foo(random.Next(arr.Length));
                maxPQ.Enqueue(foo);
                arr[i] = foo;
            }
            Assert.Equal(arr.Length, maxPQ.Count);
            Array.Sort(arr, new Comparison<Foo>((x, y) => Foo.DefaultFooComparer.Compare(y, x)));
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                Assert.Equal(arr[i].Val, maxPQ.Peek().Val);
                Assert.Equal(arr[i].Val, maxPQ.Dequeue().Val);
                Assert.Equal(arr.Length - i - 1, maxPQ.Count);
            }
            Assert.Throws<InvalidOperationException>(() => maxPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => maxPQ.Peek());
        }

        [Fact]
        public void TestMaxPriorityQueueWithGivenComparerAndArray()
        {
            var arr = new Foo[10000];
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                var val = random.Next(arr.Length);
                arr[i] = new Foo(val);
            }
            var maxPQ = PriorityQueue<Foo>.MaxPQ(arr, Foo.DefaultFooComparer);
            Assert.Equal(arr.Length, maxPQ.Count);
            Array.Sort(arr, new Comparison<Foo>((x, y) => Foo.DefaultFooComparer.Compare(y, x)));
            foreach (var i in Enumerable.Range(0, arr.Length))
            {
                Assert.Equal(arr[i].Val, maxPQ.Peek().Val);
                Assert.Equal(arr[i].Val, maxPQ.Dequeue().Val);
                Assert.Equal(arr.Length - i - 1, maxPQ.Count);
            }
            Assert.Throws<InvalidOperationException>(() => maxPQ.Dequeue());
            Assert.Throws<InvalidOperationException>(() => maxPQ.Peek());
        }
        #endregion
    }

    public class MyIndexPriorityQueueTest
    {
        static readonly string[] strings = new string[] { "it", "was", "the", "best", "of", "times", "it", "was", "the", "worst" };

        #region IndexMinPQTest
        [Fact]
        public void TestIndexMinPQBase()
        {
            var minPQ = IndexPriorityQueue<string>.IndexMinPQ(strings.Length);
            foreach (var i in Enumerable.Range(0, strings.Length))
            {
                minPQ.Enqueue(i, strings[i]);
                Assert.Equal(i + 1, minPQ.Count);
            }
            var stringsCopy = new string[strings.Length];
            Array.Copy(strings, stringsCopy, strings.Length);
            Array.Sort(stringsCopy);
            foreach (var i in Enumerable.Range(0, stringsCopy.Length))
            {
                (var idx, var key) = minPQ.Peek();
                Assert.Equal(stringsCopy[i], key);
                (idx, key) = minPQ.Dequeue();
                Assert.Equal(stringsCopy[i], key);
                Assert.Equal(stringsCopy.Length - i - 1, minPQ.Count);
            }
            Assert.Throws<InvalidOperationException>(() => minPQ.Peek());
            Assert.Throws<InvalidOperationException>(() => minPQ.Dequeue());
        }

        [Fact]
        public void TestIndexMinPQDecreaseKey()
        {
            var minPQ = IndexPriorityQueue<string>.IndexMinPQ(strings.Length);
            foreach (var i in Enumerable.Range(0, strings.Length))
            {
                minPQ.Enqueue(i, strings[i]);
                Assert.Equal(i + 1, minPQ.Count);
            }
            Assert.Throws<ArgumentException>(() => minPQ.DecreaseKey(strings.Length - 1, "zzz"));
            minPQ.DecreaseKey(strings.Length - 1, "best");
            (var _, var key) = minPQ.Dequeue();
            Assert.Equal("best", key);
            (_, key) = minPQ.Dequeue();
            Assert.Equal("best", key);
        }

        [Fact]
        public void TestIndexMinPQIncreaseKey()
        {
            var minPQ = IndexPriorityQueue<string>.IndexMinPQ(strings.Length);
            foreach (var i in Enumerable.Range(0, strings.Length))
            {
                minPQ.Enqueue(i, strings[i]);
                Assert.Equal(i + 1, minPQ.Count);
            }
            Assert.Throws<ArgumentException>(() => minPQ.IncreaseKey(3, "aaa"));
            minPQ.IncreaseKey(3, "worst");
            while (!minPQ.IsEmpty)
            {
                (var _, var key) = minPQ.Dequeue();
                if (minPQ.Count < 2)
                {
                    Assert.Equal("worst", key);
                }
            }
        }

        [Fact]
        public void TestIndexMinPQChangeKey()
        {
            var minPQ = IndexPriorityQueue<string>.IndexMinPQ(strings.Length);
            foreach (var i in Enumerable.Range(0, strings.Length))
            {
                minPQ.Enqueue(i, strings[i]);
                Assert.Equal(i + 1, minPQ.Count);
            }
            minPQ.ChangeKey(strings.Length - 1, "best");
            (var _, var key) = minPQ.Dequeue();
            Assert.Equal("best", key);
            (_, key) = minPQ.Dequeue();
            Assert.Equal("best", key);
        }

        [Fact]
        public void TestIndexMinPQDeleteKey()
        {
            var minPQ = IndexPriorityQueue<string>.IndexMinPQ(strings.Length);
            foreach (var i in Enumerable.Range(0, strings.Length))
            {
                minPQ.Enqueue(i, strings[i]);
                Assert.Equal(i + 1, minPQ.Count);
            }
            minPQ.DeleteKey(3);
            Assert.Equal(strings.Length - 1, minPQ.Count);
            (var _, var key) = minPQ.Dequeue();
            Assert.Equal("it", key);
        }
        #endregion

        #region IndexMaxPQTest
        [Fact]
        public void TestIndexMaxPQBase()
        {
            var maxPQ = IndexPriorityQueue<string>.IndexMaxPQ(strings.Length);
            foreach (var i in Enumerable.Range(0, strings.Length))
            {
                maxPQ.Enqueue(i, strings[i]);
                Assert.Equal(i + 1, maxPQ.Count);
            }
            var stringsCopy = new string[strings.Length];
            Array.Copy(strings, stringsCopy, strings.Length);
            Array.Sort(stringsCopy, new Comparison<string>((x, y) => y.CompareTo(x)));
            foreach (var i in Enumerable.Range(0, stringsCopy.Length))
            {
                (var idx, var key) = maxPQ.Peek();
                Assert.Equal(stringsCopy[i], key);
                (idx, key) = maxPQ.Dequeue();
                Assert.Equal(stringsCopy[i], key);
                Assert.Equal(stringsCopy.Length - i - 1, maxPQ.Count);
            }
            Assert.Throws<InvalidOperationException>(() => maxPQ.Peek());
            Assert.Throws<InvalidOperationException>(() => maxPQ.Dequeue());
        }

        [Fact]
        public void TestIndexMaxPQDecreaseKey()
        {
            var maxPQ = IndexPriorityQueue<string>.IndexMaxPQ(strings.Length);
            foreach (var i in Enumerable.Range(0, strings.Length))
            {
                maxPQ.Enqueue(i, strings[i]);
                Assert.Equal(i + 1, maxPQ.Count);
            }
            Assert.Throws<ArgumentException>(() => maxPQ.DecreaseKey(strings.Length - 1, "zzzzzzzz"));
            maxPQ.DecreaseKey(strings.Length - 1, "best");
            (var _, var key) = maxPQ.Dequeue();
            Assert.Equal("was", key);
            (_, key) = maxPQ.Dequeue();
            Assert.Equal("was", key);
        }

        [Fact]
        public void TestIndexMaxPQIncreaseKey()
        {
            var maxPQ = IndexPriorityQueue<string>.IndexMaxPQ(strings.Length);
            foreach (var i in Enumerable.Range(0, strings.Length))
            {
                maxPQ.Enqueue(i, strings[i]);
                Assert.Equal(i + 1, maxPQ.Count);
            }
            Assert.Throws<ArgumentException>(() => maxPQ.IncreaseKey(strings.Length - 1, "aaa"));
            maxPQ.IncreaseKey(strings.Length - 1, "zzzzz");
            (var _, var key) = maxPQ.Dequeue();
            Assert.Equal("zzzzz", key);
        }

        [Fact]
        public void TestIndexMaxPQChangeKey()
        {
            var maxPQ = IndexPriorityQueue<string>.IndexMaxPQ(strings.Length);
            foreach (var i in Enumerable.Range(0, strings.Length))
            {
                maxPQ.Enqueue(i, strings[i]);
                Assert.Equal(i + 1, maxPQ.Count);
            }
            maxPQ.ChangeKey(strings.Length - 1, "best");
            (var _, var key) = maxPQ.Dequeue();
            Assert.Equal("was", key);
            (_, key) = maxPQ.Dequeue();
            Assert.Equal("was", key);
        }

        [Fact]
        public void TestIndexMaxPQDeleteKey()
        {
            var maxPQ = IndexPriorityQueue<string>.IndexMaxPQ(strings.Length);
            foreach (var i in Enumerable.Range(0, strings.Length))
            {
                maxPQ.Enqueue(i, strings[i]);
                Assert.Equal(i + 1, maxPQ.Count);
            }
            maxPQ.DeleteKey(strings.Length - 1);
            Assert.Equal(strings.Length - 1, maxPQ.Count);
            (var _, var key) = maxPQ.Dequeue();
            Assert.Equal("was", key);
        }
        #endregion
    }
}