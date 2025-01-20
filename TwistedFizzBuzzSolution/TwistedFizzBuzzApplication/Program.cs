using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwistedFizzBuzz;

namespace TwistedFizzBuzzApplication
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var fizzBuzzFactory = new FizzBuzzFactory();
            var divisors = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 9, "Buzz" },
                { 27, "Bar" }
            };

            var results = fizzBuzzFactory.GenerateFizzBuzzRange(-20, 127, divisors);
            
            Console.WriteLine("Custom FizzBuzz Output:");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }            
        }
    }
}
