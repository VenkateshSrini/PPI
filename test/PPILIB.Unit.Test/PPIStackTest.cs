using System;
using Xunit;
using PPILib;
using Microsoft.Extensions.Logging;
namespace PPILIB.Unit.Test
{
    public class PPIStackTest
    {
        PPIStack<object> emptyStack;
        PPIStack<int> singleStack;
        PPIStack<string> manyStack;
        public PPIStackTest()
        {
            var loggerFactory = new LoggerFactory();
            emptyStack = new PPIStack<object>(loggerFactory);
            singleStack = new PPIStack<int>(loggerFactory);
            manyStack = new PPIStack<string>(loggerFactory);
            singleStack.Push(1);
            manyStack.Push("a");
            manyStack.Push("b");
        }
        [Fact]
        public void EmptyTest()
        {
            Assert.True(emptyStack.Empty);
            Assert.False(singleStack.Empty);
            Assert.False(manyStack.Empty);
        }
        [Fact]
        public void PeekTest()
        {
            Assert.Null(emptyStack.Peek());
            Assert.Equal(1, singleStack.Peek());
            Assert.Equal("b", manyStack.Peek());
        }
        [Fact]
        public void PopTest()
        {
            Assert.Equal(1, singleStack.Pop());
            Assert.Equal("b", manyStack.Pop());
            Assert.Equal("a", manyStack.Pop());
            Assert.Null(manyStack.Pop());
            Assert.Null(emptyStack.Pop());
        }
        [Fact]
        public void PopPeekTest()
        {
            Assert.Equal(1, singleStack.Pop());
            Assert.Equal(default(int),singleStack.Peek());
            Assert.True(singleStack.Empty);

            Assert.Equal("b", manyStack.Pop());
            Assert.Equal("a", manyStack.Peek());

        }
        [Fact]
        public void ContainTest()
        {
            Assert.True(singleStack.Contains(1));
            Assert.False(singleStack.Contains(2));

            Assert.False(emptyStack.Contains("anything"));

            Assert.True(manyStack.Contains("a"));
            Assert.True(manyStack.Contains("b"));
            Assert.False(manyStack.Contains("c"));
        }
        [Fact]
        public void SizeTest()
        {
            Assert.Equal(0, emptyStack.SizeOf);
            Assert.Equal(1, singleStack.SizeOf);
            Assert.Equal(2, manyStack.SizeOf);

            manyStack.Pop();
            Assert.Equal(1, manyStack.SizeOf);

            singleStack.Pop();
            Assert.Equal(0, singleStack.SizeOf);

            emptyStack.Pop();
            Assert.Equal(0, emptyStack.SizeOf);

        }
        [Fact]
        public void PeekNTest()
        {
            Assert.Equal(1, singleStack.PeekN(0));
            Assert.Equal("b", manyStack.PeekN(0));
            Assert.Equal("a", manyStack.PeekN(1));
            Assert.Equal(default(string), manyStack.PeekN(2));
        }
    }
}
