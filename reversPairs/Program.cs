using System;

namespace reversPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{2147483647,2147483647,2147483647,2147483647,2147483647,2147483647};
            // int[]  nums = new int[]{2,4,3,5,1};
            Console.WriteLine("reverse pairs: {0}", ReversePairs(nums));
        }

        static int ReversePairs(int[] nums) {
            return MergeSortCount(nums, 0, nums.Length-1);
        }
        
        static int MergeSortCount(int[] nums, int left, int right){
            if (left >= right) return 0;
            
            int mid = left + (right - left) / 2;
            int res = MergeSortCount(nums, left, mid) + MergeSortCount(nums, mid + 1, right);
            
            for (int i = left, j = mid + 1; i <= mid; i++) {
                // int 2147483647 is the Max. so doing it as / 2.0 to double
                // otherwise doing it as * 2 will over int32
                while (j <= right && nums[i] / 2.0 > nums[j]) j++;
                res += j - (mid + 1);
            }
            // sort: index, length
            Array.Sort(nums, left, right - left + 1);
            return res;
        }
    }
}
