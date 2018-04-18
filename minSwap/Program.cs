using System;

namespace minSwap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[]{1, 3, 5, 4};
            int[] b = new int[]{1, 2, 3, 7};
            Console.WriteLine("Min Swap: {0}", MinSwap(a, b));
        }

        static int MinSwap(int[] A, int[] B) {
            int n = A.Length;
            int[] swap = new int[n];
            int[] no_swap = new int[n];
            swap[0] = 1;

            for(int i = 1; i < n; i++){
                swap[i] = no_swap[i] = n;
                if(A[i] > A[i-1] && B[i] > B[i-1]){
                    swap[i] = swap[i-1] + 1;
                    no_swap[i] = no_swap[i-1];
                }

                if(B[i] > A[i-1] && A[i] > B[i-1]){
                    swap[i] = Math.Min(swap[i], no_swap[i-1] + 1);
                    no_swap[i] = Math.Min(no_swap[i], swap[i-1]);
                }
            }

            return Math.Min(swap[n-1], no_swap[n-1]);
        }
    }
}
