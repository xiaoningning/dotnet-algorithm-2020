using System;

namespace findKthLargest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("int array: {0}", args[0]);
            int k = int.Parse(args[1]);
            int[] nums = Array.ConvertAll(args[0].Split(','), s => int.Parse(s)); 
            Console.WriteLine("result for {0}: {1}", k, FindKthLargest(nums, k));
        }

        static int FindKthLargest(int[] nums, int k) {
            int left = 0, right = nums.Length - 1;
            while (true) {
                int pos = Partition(nums, left, right);
                if (pos == k - 1) return nums[pos];
                else if (pos > k - 1) right = pos - 1;
                else left = pos + 1;
            }
        }

        static int Partition(int[] arr, int left, int right){
            int pivot = arr[left], l = left + 1, r = right;
            while (l <= r) {
                if (arr[l] < pivot && arr[r] > pivot) {
                    swapArray(arr, l, r);
                    l++;
                    r--;
                }
                if (arr[l] >= pivot) l++;
                if (arr[r] <= pivot) r--;
            }
            swapArray(arr, left, r);
            return r;
        }

        static void swapArray(int[] arr, int i, int j){
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
