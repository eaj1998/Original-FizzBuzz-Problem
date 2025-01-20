using System;
using System.Collections.Generic;
using TwistedFizzBuzz;

namespace TwistedFizzBuzzApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new FizzBuzzFactory();
            var divisors = new Dictionary<int, string>
        {
            { 3, "Fizz" },
            { 9, "Buzz" },
            { 27, "Bar" }
        };

            var results = generator.GenerateFizzBuzz(new List<int> { 3,6,9,27}, divisors);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
