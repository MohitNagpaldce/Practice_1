using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapsLib
{
    class GenericHeap<T> where T : IComparable
    {
        public int heapSize;
        private T[] arr;

        public GenericHeap(int capacity)
        {
            T[] arr = new T[capacity];
            this.heapSize = 0;
        }

        public void InsertKey(T item)
        {
            this.arr[this.heapSize++] = item;
            int i = this.heapSize - 1;

            // Fix the min heap property if it is violated
            while (i != 0 && arr[GetParentIndex(i)].CompareTo(arr[i]) > 0)
            {
                Swap(this.arr, i, GetParentIndex(i));
                i = GetParentIndex(i);
            }
            
        }

        public void UpdateKey(int index, T newKey)
        {
            T oldKey = this.arr[index];
            if(oldKey.CompareTo(newKey) < 0)
            {
                this.arr[index] = newKey;
                this.MinHepify(index);
            }
            else if(oldKey.CompareTo(newKey) > 0)
            {
                while (index != 0 && arr[GetParentIndex(index)].CompareTo(arr[index]) > 0)
                {
                    Swap(this.arr, index, GetParentIndex(index));
                    index = GetParentIndex(index);
                }
            }
        }

        public void MinHepify(int index)
        {
            int length = this.heapSize;
            if (length - 1 < index)
            {
                return;
            }

            int leftChild = this.GetLeftChildIndex(index);
            if (length - 1 < leftChild)
            {
                return;
            }

            int minChildIndex = index;
            int rightChild = this.GetRightChildIndex(index);
            if (arr[leftChild].CompareTo(arr[index]) < 0)
            {
                minChildIndex = leftChild;
            }

            if (length - 1 >= rightChild && arr[minChildIndex].CompareTo(arr[rightChild]) > 0)
            {
                minChildIndex = rightChild;
            }

            if (index != minChildIndex)
            {
                Swap(arr, index, minChildIndex);
                this.MinHepify( minChildIndex);
            }
        }

        public T RemoveMin(T[] arr)
        {
            if (this.heapSize >= 0)
            {
                T val = arr[0];
                arr[0] = arr[this.heapSize];
                this.heapSize--;
                this.MinHepify(0);
                return val;
            }

            return default(T);
        }

        private void Swap(T[] arr, int source, int target)
        {
            T sourceElement = arr[source];
            arr[source] = arr[target];
            arr[target] = sourceElement;
        }

        
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
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
}
