using System;
using NUnit.Framework;

namespace CountOfOccurrences.Tests
{
    [TestFixture]
    public class CountOfOccurrencesTests
    {
        [Test]
        public void Should_Return_Correct_Value_Test1()
        {
            // Arrange
            var countOfOccurrences = new CountOfOccurrences();

            // Act
            var result = countOfOccurrences.GetCount("3 4 4 2 3 3 4 3 2");

            // Assert
            Assert.AreEqual(
                "2 -> 2 times" + Environment.NewLine + "3 -> 4 times" + Environment.NewLine + "4 -> 3 times",
                result);
        }

        [Test]
        public void Should_Return_Correct_Value_Test2()
        {
            // Arrange
            var countOfOccurrences = new CountOfOccurrences();

            // Act
            var result = countOfOccurrences.GetCount("1000");

            // Assert
            Assert.AreEqual(
                "1000 -> 1 times",
                result);
        }

        [Test]
        public void Should_Return_Correct_Value_Test3()
        {
            // Arrange
            var countOfOccurrences = new CountOfOccurrences();

            // Act
            var result = countOfOccurrences.GetCount("0 0 0");

            // Assert
            Assert.AreEqual(
                "0 -> 3 times",
                result);
        }

        [Test]
        public void Should_Return_Correct_Value_Test4()
        {
            // Arrange
            var countOfOccurrences = new CountOfOccurrences();

            // Act
            var result = countOfOccurrences.GetCount("7 6 5 5 6");

            // Assert
            Assert.AreEqual(
                "5 -> 2 times" + Environment.NewLine + "6 -> 2 times" + Environment.NewLine + "7 -> 1 times",
                result);
        }
    }
}
