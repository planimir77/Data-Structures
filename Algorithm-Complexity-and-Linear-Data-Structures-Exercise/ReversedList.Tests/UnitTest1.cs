using System;
using NUnit.Framework;

namespace ReversedList.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Should_Add_Element()
        {
            // Arrange
            var list = new ReversedList<int>();

            // Act 
            list.Add(2);
            var actual = list[0];

            // Assert
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void Should_Return_Correct_Count_Of_Elements()
        {
            // Arrange
            var list = new ReversedList<int>();

            // Act 
            list.Add(2);
            list.Add(3);

            // Assert
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void Should_Return_Correct_Capacity()
        {
            // Arrange
            var list = new ReversedList<int>();

            // Act 
            list.Add(2);
            list.Add(3);
            list.Add(1);

            // Assert
            Assert.AreEqual(4, list.Capacity);
        }

        [Test]
        public void Should_Throw_Error_When_Index_Is_Invalid()
        {
            // Arrange
            var list = new ReversedList<int>();

            // Act
            // Assert
            Assert.Catch<ArgumentOutOfRangeException>(() => { list.RemoveAt(0);});
        }

        [Test]
        public void Should_Remove_Element()
        {
            // Arrange
            var list = new ReversedList<int>();

            // Act 
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            var lastElement = list.RemoveAt(4);
            var middleElement = list.RemoveAt(2);
            var firstElement = list.RemoveAt(0);

            // Assert
            Assert.AreEqual(1, firstElement);
            Assert.AreEqual(3, middleElement);
            Assert.AreEqual(5, lastElement);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void Should_Return_In_A_Reversed_Order()
        {
            // Arrange
            var list = new ReversedList<int>();

            // Act 
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var actual = string.Join(" ", list);

            // Assert
            Assert.AreEqual("3 2 1", actual);
        }
    }
}