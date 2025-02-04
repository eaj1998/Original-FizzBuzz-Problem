﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TwistedFizzBuzz
{
    public class FizzBuzzFactory
    {
       
        public IEnumerable<string> GenerateFizzBuzz(IEnumerable<int> numbers, Dictionary<int, string> divisors)
        {
            foreach (var number in numbers)
            {
                var result = string.Join("", divisors
                    .Where(d => number % d.Key == 0)
                    .Select(d => d.Value));

                yield return string.IsNullOrEmpty(result) ? number.ToString() : result;
            }
        }

        public IEnumerable<string> GenerateFizzBuzzRange(int start, int end, Dictionary<int, string> divisors)
        {           
            if(start > end)
            {
                return Enumerable.Empty<string>();
            }

            var range = Enumerable.Range(start, end - start + 1);
            return GenerateFizzBuzz(range, divisors);
        }
    }
}
