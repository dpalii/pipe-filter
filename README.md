# Pipe-filter

In this example, we have an IFilter\<T> interface that represents a filter in the Pipe-Filter pattern. Each filter implements this interface and processes the data according to its specific logic.

Two example filters are implemented: UppercaseFilter, which converts the input strings to uppercase, and LengthFilter, which appends the length of each input string to the result.

The Pipeline\<T> class represents the pipeline that connects the filters together. It allows adding filters to the pipeline and executing the data through each filter in sequence.

In the Program class, we create instances of the filters (uppercaseFilter and lengthFilter) and add them to the pipeline. We provide input data (inputData) as a list of strings. We then execute the pipeline using the Execute method, passing in the input data. The result is obtained and printed to the console.

When executed, the program will process the input data through each filter in the pipeline, resulting in the desired transformations being applied to the data.

This example demonstrates how the Pipe-Filter pattern can be used to create modular and reusable processing components, allowing for flexible and scalable data processing pipelines.