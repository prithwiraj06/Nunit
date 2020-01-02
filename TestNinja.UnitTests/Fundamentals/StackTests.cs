using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class StackTests
    {
        Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Push_ArgumentIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArgument_AddItToTheStack()
        {
            _stack.Push("A");

            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnsZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_InvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackHasItem_ReturnObjectOnTop()
        {
            // Arrange
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");

            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo("C").IgnoreCase);
        }

        [Test]
        public void Pop_StackHasItem_RemoveObjectFromTop()
        {
            // Arrange
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");

            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_StackHasNoItem_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackHasItem_RetrunsTopElement()
        {
            // Arrange
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");

            var result = _stack.Peek();
            Assert.That(result, Is.EqualTo("C").IgnoreCase);
        }

    }
}
