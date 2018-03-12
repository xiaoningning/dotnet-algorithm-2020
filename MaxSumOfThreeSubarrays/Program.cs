using System;
using System.Collections.Generic;

namespace MaxSumOfThreeSubarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{7,13,20,19,19,2,10,1,1,19};
            int k = 3;
            int[] res = MaxSumOfThreeSubarrays(nums, k);
            Console.WriteLine("Max Sum of three arrays indice: {0}", string.Join(",", res));
        }

        static int[] MaxSumOfThreeSubarrays(int[] nums, int k){
            int n = nums.Length;
            int mx = 0;
            int[] sums = new int[n + 1];
            int[] res = new int[3];
            int[] left = new int[n];
            int[] right = new int[n];
            
            for(int i = 0; i < n; i++){
                right[i] = n-k;
            }
            for(int i = 0; i < n; i++ ){
                sums[i+1] = sums[i] + nums[i];
            }
            // caution: the condition is ">= total" for right interval, and "> total" for left interval
            for (int i = k, total = sums[k] - sums[0]; i < n - 1; i++) {
                if (sums[i + 1] - sums[i + 1 - k] > total) {
                    left[i] = i + 1 - k;
                    total = sums[i + 1] - sums[i + 1 - k];
                } 
                else {
                    left[i] = left[i - 1];
                }
            }
            for (int i = n - k - 1, total = sums[n] - sums[n - k]; i >= 0 ; i--) {
                if (sums[i + k] - sums[i] >= total) {
                    right[i] = i;
                    total = sums[i + k] - sums[i];
                }
                 else {
                    right[i] = right[i + 1];
                }
            }

            // reset mx
            mx = 0;

            for (int i = k; i <= n - 2 * k; i++) {
                int l = left[i - 1], r = right[i + k];
                int total = (sums[i + k] - sums[i]) + (sums[l + k] - sums[l]) + (sums[r + k] - sums[r]);
                if (mx < total) {
                    mx = total;
                    res[0] = l;
                    res[1] = i;
                    res[2] = r;
                }
            }
            return res;
        }
    }
}
