/*
 * File: 155.cs
 * Project: StackTests
 * Created Date: Wednesday, 9th September 2020 8:45:32 am
 * Author: David Gu (macdavid313@gmail.com)
 * Copyright (c) David Gu 2020
 */


using Xunit;
using MyMinStack;

namespace StackTests
{
    public class MinStackTest
    {
        [Fact]
        public void TestCase1()
        {
            var minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Assert.Equal(-3, minStack.GetMin());
            minStack.Pop();
            Assert.Equal(0, minStack.Top());
            Assert.Equal(-2, minStack.GetMin());
        }
    }
}