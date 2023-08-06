using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarkDotNetExamples.Benchmarks
{
    public class SortingBenchmarks
    {
        private int[] data;

        [Params(1000, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            // Initialize data with random numbers
            var random = new Random();
            data = new int[N];
            for (int i = 0; i < N; i++)
            {
                data[i] = random.Next();
            }
        }

        [Benchmark]
        public void BubbleSort()
        {
            Array.Sort(data);
        }

        [Benchmark]
        public void QuickSort()
        {
            // Custom QuickSort implementation
            QuickSort(data, 0, data.Length - 1);
        }

        [Benchmark]
        public void MergeSort()
        {
            // Custom MergeSort implementation
            MergeSort(data, 0, data.Length - 1);
        }

        private void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);

                // Sort the elements before and after the pivot
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private int Partition(int[] array, int left, int right)
        {
            int pivot = array[right]; // Choosing the last element as the pivot
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    // Swap array[i] and array[j]
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            // Swap array[i+1] and array[right] (put the pivot in its correct position)
            int temp2 = array[i + 1];
            array[i + 1] = array[right];
            array[right] = temp2;

            return i + 1; // Return the pivot index
        }

        private void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                // Sort the left and right halves
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);

                // Merge the sorted halves
                Merge(array, left, mid, right);
            }
        }

        private  void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            // Create temporary arrays to hold the left and right halves
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Copy data to temporary arrays
            for (int i = 0; i < n1; i++)
            {
                leftArray[i] = array[left + i];
            }

            for (int j = 0; j < n2; j++)
            {
                rightArray[j] = array[mid + 1 + j];
            }

            // Merge the temporary arrays back into the original array
            int k = left;
            int l = 0;
            int r = 0;

            while (l < n1 && r < n2)
            {
                if (leftArray[l] <= rightArray[r])
                {
                    array[k] = leftArray[l];
                    l++;
                }
                else
                {
                    array[k] = rightArray[r];
                    r++;
                }
                k++;
            }

            // Copy remaining elements from leftArray, if any
            while (l < n1)
            {
                array[k] = leftArray[l];
                l++;
                k++;
            }

            // Copy remaining elements from rightArray, if any
            while (r < n2)
            {
                array[k] = rightArray[r];
                r++;
                k++;
            }
        }
    }
}
