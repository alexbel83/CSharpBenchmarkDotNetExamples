using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarkDotNetExamples.Benchmarks
{
    public class ExponentiationBenchmarks
    {
        private const double BaseValue = 2.0;
        private const int Exponent = 10;

        [Benchmark]
        public double MathPowBenchmark()
        {
            return Math.Pow(BaseValue, Exponent);
        }

        [Benchmark]
        public double CustomExponentiationBenchmark()
        {
            return CustomExponentiation(BaseValue, Exponent);
        }

        private static double CustomExponentiation(double x, int n)
        {
            double result = 1.0;
            for (int i = 0; i < n; i++)
            {
                result *= x;
            }
            return result;
        }
    }
}
