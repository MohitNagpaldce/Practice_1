using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapsLib
{
    public class Heap
    {
        public int heapSize;

        public void BuildMinHeap(int[] arr)
        {
            heapSize = arr.Length - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                MinHepify(arr, i);
            }
        }

        public void BuildMaxHeap(int[] arr)
        {
            heapSize = arr.Length - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                MaxHepify(arr, i);
            }
        }

        public void HeapSortMinHeap(int[] arr)
        {
            this.PrintArray(arr);
            this.BuildMinHeap(arr);

            // first element is min element.
            for(int i = 0; i< arr.Length-1; i++)
            {
                this.Swap(arr, 0, this.heapSize);
                this.heapSize--;
                this.MinHepify(arr, 0);
            }

            Console.WriteLine("after sorting using min heap");
            this.PrintArray(arr);
        }

        public void HeapSortMaxHeap(int[] arr)
        {
            this.PrintArray(arr);
            this.BuildMaxHeap(arr);

            // first element is min element.
            for (int i = 0; i < arr.Length - 1; i++)
            {
                this.Swap(arr, 0, this.heapSize);
                this.heapSize--;
                this.MaxHepify(arr, 0);
            }

            Console.WriteLine("after sorting using min heap");
            this.PrintArray(arr);
        }

        public void MinHepify(int[] arr, int index)
        {
            int length = this.heapSize;
            if(length-1 > index)
            {
                return;
            }

            int leftChild = this.GetLeftChildIndex(index);
            if (length - 1 > leftChild)
            {
                return;
            }

            int minChildIndex = index;
            int rightChild = this.GetRightChildIndex(index);
            if (arr[leftChild] < arr[index])
            {
                minChildIndex = leftChild;
            }

            if (length - 1 >= rightChild && arr[minChildIndex] > arr[rightChild])
            {
                minChildIndex = rightChild;
            }

            if(index != minChildIndex)
            {
                Swap(arr, index, minChildIndex);
                this.MinHepify(arr, minChildIndex);
            }
        }


        public void MaxHepify(int[] arr, int index)
        {
            int length = this.heapSize;

            int leftChild = this.GetLeftChildIndex(index);
            if (length - 1 < leftChild)
            {
                return;
            }

            int maxChildIndex = index;
            int rightChild = this.GetRightChildIndex(index);
            if (arr[leftChild] > arr[index])
            {
                maxChildIndex = leftChild;
            }

            if (length - 1 >= rightChild && arr[maxChildIndex] < arr[rightChild])
            {
                maxChildIndex = rightChild;
            }

            if (index != maxChildIndex)
            {
                Swap(arr, index, maxChildIndex);
                this.MaxHepify(arr, maxChildIndex);
            }
        }

        /// <summary>
        /// Returns the total number of heaps possible to make using n numbers.
        /// </summary>
        /// <param name="n">The total number to use to make heaps.</param>
        /// <returns>The total number of heaps created using passed numbers.</returns>
        public int CountHeaps(int n)
        {
            List<int> PreCompute = new List<int>();
            PreCompute.AddRange(Enumerable.Repeat<int>(-1, n + 1));
            Dictionary<Tuple<int, int>, int> preComputeNck = new Dictionary<Tuple<int, int>, int>();
            return CountHeapsUtil(PreCompute, preComputeNck, n);
        }

        public int CountHeapsUtil(List<int> PreCompute, Dictionary<Tuple<int, int>, int> preComputeNck, int n)
        {
            if(n<=1)
            {
                return 1;
            }

            if (PreCompute[n] != -1)
            {
                return PreCompute[n];
            }

            int left = this.GetLeftTreeCount(n);
            PreCompute[n] = this.ComputeNCK(preComputeNck, n - 1, left) * CountHeapsUtil(PreCompute, preComputeNck, left) * CountHeapsUtil(PreCompute, preComputeNck, n-1-left);
            return PreCompute[n];
        }
        private int GetLeftTreeCount(int n)
        {
            if(n == 1)
            {
                return 0;
            }

            int leftTreeCount = 0;
            int height = (int) Math.Log(n, 2);
            int maxNodeAtLastLevel = (int)Math.Pow(2, height);
            int nodeBeforeLastLevel = (int)Math.Pow(2, height) - 1;
            // actual number of nodes in left tree
            int lastLevelNodes = n - nodeBeforeLastLevel;
            leftTreeCount = (int)Math.Pow(2, height) - 1;
            if(lastLevelNodes > maxNodeAtLastLevel/2)
            {
                return leftTreeCount;
            }
            else
            {
                return leftTreeCount - (maxNodeAtLastLevel / 2 - lastLevelNodes);
            }
        }
        private int ComputeNCK(Dictionary<Tuple<int, int>, int> preCompute, int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if(n <= 1)
            {
                return 1;
            }

            if (k == 0)
            {
                return 1;
            }

            Tuple<int, int> key = Tuple.Create<int, int>(n, k);
            if (preCompute.ContainsKey(key))
            {
                return preCompute[key];
            }

            int answer = ComputeNCK(preCompute, n - 1, k - 1) + ComputeNCK(preCompute, n - 1, k);
            preCompute.Add(key, answer);
            return preCompute[key];
        }

        private void PrintArray(int[] arr)
        {
            Console.WriteLine("Printing Array");
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }

        private void Swap(int[] arr, int source, int target)
        {
            int sourceElement = arr[source];
            arr[source] = arr[target];
            arr[target] = sourceElement;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }
    }

    public class RunningMedianHelper
    {
        //int runningCount = 0;
        //List<int> MinHeapEntries = new List<int>();
        //public int RunningMedian(int currentInt)
        //{
        //    runningCount++;
        //    int 

        //    //// build first heap
        //    if (runningCount == 1)
        //    {
        //        Heap heap = new Heap();
        //        heap.BuildMinHeap(new int[])
        //    }
        //}
    }
}
