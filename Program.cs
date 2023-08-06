using BenchmarkDotNet.Running;
using CSharpBenchmarkDotNetExamples.Benchmarks;

internal class Program
{
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ExponentiationBenchmarks>();
    }
}