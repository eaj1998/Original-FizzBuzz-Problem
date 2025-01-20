using TwistedFizzBuzz;

namespace TwistedFizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzFactoryTests
    {
        private FizzBuzzFactory _fizzbuzzFactory;

        [TestInitialize]
        public void Setup()
        {
            _fizzbuzzFactory = new FizzBuzzFactory();
        }

        [TestMethod]
        public void GenerateFizzBuzzRange_StandardFizzBuzz_ReturnsExpectedOutput()
        {
            var divisors = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 5, "Buzz" }
            };

            var result = _fizzbuzzFactory.GenerateFizzBuzzRange(1, 15, divisors);

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

            var result = _fizzbuzzFactory.GenerateFizzBuzzRange(1, 50, divisors);

            // Assert
            Assert.IsTrue(result.Contains("Foo"));
            Assert.IsTrue(result.Contains("Bar"));
            Assert.IsFalse(result.Contains("FooBar"));
        }

        [TestMethod]
        public void GenerateFizzBuzzRange_EmptyRange_ReturnsEmptyList()
        {
            var result = _fizzbuzzFactory.GenerateFizzBuzzRange(10, 5, new Dictionary<int, string>());

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GenerateFizzBuzzRange_NegativeRange_ReturnsExpectedOutput()
        {
            var divisors = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 5, "Buzz" }
            };

            var result = _fizzbuzzFactory.GenerateFizzBuzzRange(-10, 5, divisors);

            Assert.IsTrue(result.Contains("Fizz"));
            Assert.IsTrue(result.Contains("Buzz"));
        }

        [TestMethod]
        public void GenerateFizzBuzz_NonSequentialNumbers_ReturnsExpectedOutput()
        {
            var numbers = new[] { 3, 5, 15, 8 };
            var divisors = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 5, "Buzz" }
            };

            var result = _fizzbuzzFactory.GenerateFizzBuzz(numbers, divisors);

            CollectionAssert.AreEqual(
                new List<string> { "Fizz", "Buzz", "FizzBuzz", "8" },
                result.ToList()
                );
        }
    }
}
