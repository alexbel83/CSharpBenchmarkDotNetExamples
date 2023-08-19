using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CSharpBenchmarkDotNetExamples.Benchmarks
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ListAnyBenchmarks
    {
        private List<int> list;

        [Params(500000, 1000000)]
        public int count;

        [GlobalSetup]
        public void Setup()
        {
            list = Enumerable.Range(1, count).ToList();
        }

        [Benchmark]
        public bool EnumerableAny()
        {
            return list.Any(x => x == 999999);
        }

        [Benchmark]
        public bool ListExists()
        {
            return list.Exists(x => x == 999999);
        }
    }
}
