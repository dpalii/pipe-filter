using System;
using System.Collections.Generic;

namespace YourNamespace
{
    // Interface representing a filter in the Pipe-Filter pattern
    public interface IFilter<T>
    {
        IEnumerable<T> Process(IEnumerable<T> input);
    }

    // Example filter implementation
    public class UppercaseFilter : IFilter<string>
    {
        public IEnumerable<string> Process(IEnumerable<string> input)
        {
            foreach (string item in input)
            {
                yield return item.ToUpper();
            }
        }
    }

    // Example filter implementation
    public class LengthFilter : IFilter<string>
    {
        public IEnumerable<string> Process(IEnumerable<string> input)
        {
            foreach (string item in input)
            {
                yield return $"Length: {item.Length}";
            }
        }
    }

    // Pipeline class that connects filters together
    public class Pipeline<T>
    {
        private readonly List<IFilter<T>> _filters = new List<IFilter<T>>();

        public void AddFilter(IFilter<T> filter)
        {
            _filters.Add(filter);
        }

        public IEnumerable<T> Execute(IEnumerable<T> input)
        {
            IEnumerable<T> output = input;

            foreach (IFilter<T> filter in _filters)
            {
                output = filter.Process(output);
            }

            return output;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create filters
            var uppercaseFilter = new UppercaseFilter();
            var lengthFilter = new LengthFilter();

            // Create pipeline
            var pipeline = new Pipeline<string>();
            pipeline.AddFilter(uppercaseFilter);
            pipeline.AddFilter(lengthFilter);

            // Input data
            var inputData = new List<string> { "hello", "world" };

            // Execute pipeline
            IEnumerable<string> result = pipeline.Execute(inputData);

            // Output results
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
