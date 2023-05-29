using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Tests
{
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void Execute_ShouldApplyFiltersToInputData()
        {
            // Arrange
            var uppercaseFilter = new UppercaseFilter();
            var lengthFilter = new LengthFilter();

            var pipeline = new Pipeline<string>();
            pipeline.AddFilter(lengthFilter);
            pipeline.AddFilter(uppercaseFilter);

            var inputData = new List<string> { "hello", "world" };

            // Act
            IEnumerable<string> result = pipeline.Execute(inputData);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("LENGTH: 5", result.ElementAt(0));
            Assert.AreEqual("LENGTH: 5", result.ElementAt(1));
        }
    }
}
