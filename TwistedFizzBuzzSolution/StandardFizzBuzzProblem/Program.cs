using System;
using System.Collections.Generic;
using TwistedFizzBuzz;

namespace StandardFizzBuzzProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fizzbuzzFactory = new FizzBuzzFactory();
            var divisors = new Dictionary<int, string>
        {
            { 3, "Fizz" },
            { 5, "Buzz" }
        };
            Console.WriteLine("Standard FizzBuzz Problem");

            var results = fizzbuzzFactory.GenerateFizzBuzzRange(1, 100, divisors);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
