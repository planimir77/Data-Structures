namespace LongestSubsequence.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class LongestSubsequenceTests
    {
        [Test]
        public void Should_Return_3_3()
        {
            // Arrange
            var result = new LongestSubsequence();
            // Act
            var actual = result.Get("12 2 7 4 3 3 8");
            // Assert
            Assert.AreEqual("3 3", actual);
        }

        [Test]
        public void Should_Return_2_2()
        {
            // Arrange
            var result = new LongestSubsequence();
            // Act
            var actual = result.Get("2 2 2 3 3 3");
            // Assert
            Assert.AreEqual("2 2 2", actual);
        }

        [Test]
        public void Should_Return_1()
        {
            // Arrange
            var result = new LongestSubsequence();
            // Act
            var actual = result.Get("1 2 3");
            // Assert
            Assert.AreEqual("1", actual);
        }

        [Test]
        public void Should_Return_0()
        {
            // Arrange
            var result = new LongestSubsequence();
            // Act
            var actual = result.Get("0");
            // Assert
            Assert.AreEqual("0", actual);
        }

        [Test]
        public void Should_Return_4_4()
        {
            // Arrange
            var result = new LongestSubsequence();
            // Act
            var actual = result.Get("4 2 3 4 4");
            // Assert
            Assert.AreEqual("4 4", actual);
        }
    }
}
