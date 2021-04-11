using NUnit.Framework;

namespace RemoveOddOccurrences.Tests
{
    [TestFixture]
    public class RemoveOddOccurrencesTests
    {
        [Test]
        public void Should_Return_1_1 ()
        {
            var removeOddOccurrences = new RemoveOddOccurrences();
            var actual = removeOddOccurrences.GetEven("1 2 3 4 1");
            Assert.AreEqual("1 1", actual);
        }
        [Test]
        public void Should_Return_3_3_7_7 ()
        {
            var removeOddOccurrences = new RemoveOddOccurrences();
            var actual = removeOddOccurrences.GetEven("1 2 3 4 5 3 6 7 6 7 6");
            Assert.AreEqual("3 3 7 7", actual);
        }
        [Test]
        public void Should_Return_Empty_String ()
        {
            var removeOddOccurrences = new RemoveOddOccurrences();
            var actual = removeOddOccurrences.GetEven("1 2 1 2 1 2");
            Assert.AreEqual("", actual);
        }
        [Test]
        public void Should_Return_7_4_4_7 ()
        {
            var removeOddOccurrences = new RemoveOddOccurrences();
            var actual = removeOddOccurrences.GetEven("3 7 3 3 4 3 4 3 7");
            Assert.AreEqual("7 4 4 7", actual);
        }
        [Test]
        public void Should_Return_2_2 ()
        {
            var removeOddOccurrences = new RemoveOddOccurrences();
            var actual = removeOddOccurrences.GetEven("2 2");
            Assert.AreEqual("2 2", actual);
        }
    }
}