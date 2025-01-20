using System.Net.Http;
using System.Net;
using TwistedFizzBuzz;

namespace TwistedFizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzFactoryTests
    {
        private FizzBuzzFactory _generator;

        public FizzBuzzFactoryTests(FizzBuzzFactory generator)
        {
            _generator = generator;
        }

        // 1. Test GenerateFizzBuzzRange
        [TestMethod]
        public void GenerateFizzBuzzRange_StandardFizzBuzz_ReturnsExpectedOutput()
        {
            // Arrange
            var divisors = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 5, "Buzz" }
            };

            // Act
            var result = _generator.GenerateFizzBuzzRange(1, 15, divisors);

            // Assert
            CollectionAssert.AreEqual(new List<string>
            {
                "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz",
                "11", "Fizz", "13", "14", "FizzBuzz"
            }, result.ToList());
        }

        [TestMethod]
        public void GenerateFizzBuzzRange_CustomDivisors_ReturnsCustomOutput()
        {
            var divisors = new Dictionary<int, string>
            {
                { 7, "Foo" },
                { 11, "Bar" }
            };

            var result = _generator.GenerateFizzBuzzRange(1, 50, divisors);

            // Assert
            Assert.IsTrue(result.Contains("Foo"));
            Assert.IsTrue(result.Contains("Bar"));
            Assert.IsTrue(result.Contains("FooBar"));
        }

        [TestMethod]
        public void GenerateFizzBuzzRange_EmptyRange_ReturnsEmptyList()
        {
            // Act
            var result = _generator.GenerateFizzBuzzRange(10, 5, new Dictionary<int, string>());

            // Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GenerateFizzBuzzRange_NegativeRange_ReturnsExpectedOutput()
        {
            // Arrange
            var divisors = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 5, "Buzz" }
            };

            // Act
            var result = _generator.GenerateFizzBuzzRange(-10, 5, divisors);

            // Assert
            Assert.IsTrue(result.Contains("Fizz"));
            Assert.IsTrue(result.Contains("Buzz"));
        }

        // 2. Test GenerateFizzBuzz
        [TestMethod]
        public void GenerateFizzBuzz_NonSequentialNumbers_ReturnsExpectedOutput()
        {
            // Arrange
            var numbers = new[] { 3, 5, 15, 8 };
            var divisors = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 5, "Buzz" }
            };

            // Act
            var result = _generator.GenerateFizzBuzz(numbers, divisors);

            // Assert
            CollectionAssert.AreEqual(
                new List<string> { "Fizz", "Buzz", "FizzBuzz", "8" },
                result.ToList()
                );
        }
    }
}
