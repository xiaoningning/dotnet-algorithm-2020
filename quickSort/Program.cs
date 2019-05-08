using System;

namespace quickSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var o = new Solution();
            int[] n = new int[]{3, 2, 1, 4, 5};
            o.QuickSort(n, 0, n.Length-1);
            Console.WriteLine("Quick Sort: {0}", string.Join(',', n));
        }
    }

    public class Solution{
        public void QuickSort(int[] A, int start, int end) {
            if (start >= end) return;
            int pos = Partition(A, start, end);
            QuickSort(A, start, pos - 1);
            QuickSort(A, pos, end);
        }

        int Partition(int[] A, int start, int end) {            
            int i = start, j = end, pivot = A[end];
            while (i <= j) {
                while (A[i] < pivot) ++i;
                while (A[j] > pivot) --j;
                if (i <= j) {
                    Swap(A, i, j);
                    ++i; --j;
                }
            }            
            return i-1;
        }
        void Swap(int[] A, int i, int j) {
            int t = A[i];
            A[i] = A[j];
            A[j] = t;
        }
    }
}
