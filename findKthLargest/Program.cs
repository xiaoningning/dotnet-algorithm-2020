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
            var o = new Solution();
            Console.WriteLine("result for {0}: {1}", k, o.FindKthLargest(nums, k));
        }
    }
    public class Solution {
        public int FindKthLargest(int[] nums, int k) {
            int left = 0, right = nums.Length - 1;
            while (true) {
                int pos = Partition(nums, left, right);
                if (pos == k - 1) return nums[pos];
                else if (pos > k - 1) right = pos - 1;
                else left = pos + 1;
            }
        }

        int Partition1(int[] nums, int left, int right){
            int pivot = nums[right], l = left, r = right;
            while (l <= r) {
                while (nums[l] > pivot) l++;
                while (nums[r] < pivot) r--;
                if (l <= r) {
                    Swap(nums, l, r);
                    l++;
                    r--;
                }
            }
            return l;
        }

        int Partition(int[] A, int start, int end) {            
            int i = start - 1, pivot = A[end];
            for (int j = start; j <= end; ++j) {
                if (A[j] >= pivot) {
                    // i need to be start - 1 for the first time
                    ++i; 
                    Swap(A, i, j);
                }
            }            
            return i;
        }

        void Swap(int[] arr, int i, int j){
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
