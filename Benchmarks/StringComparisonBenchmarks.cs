using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarkDotNetExamples.Benchmarks
{
    public class StringComparisonBenchmarks
    {
        private const string SourceString = "Hello, World!";
        private const string TargetString = "hello, world!";

        [Benchmark]
        public bool StringEqualsBenchmark()
        {
            return string.Equals(SourceString, TargetString, StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark]
        public bool CustomStringComparisonBenchmark()
        {
            return CustomStringComparison(SourceString, TargetString);
        }

        [Benchmark]
        public bool UpperCaseComparisonBenchmark()
        {
            return SourceString.ToUpper() == TargetString.ToUpper();
        }

        private bool CustomStringComparison(string str1, string str2)
        {
            // Custom case-insensitive string comparison implementation
            return string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}