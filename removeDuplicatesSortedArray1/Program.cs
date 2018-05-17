using System;

namespace removeDuplicatesSortedArray1
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{1,1,2,2,3};
            Console.WriteLine("remove duplicated from sorted array 1 {0}", obj.RemoveDuplicates(nums));
        }
    }
    public class Solution {
        public int RemoveDuplicates(int[] nums) {
            // only 1 duplicate
            if (nums.Length == 0) return 0;
            int pre = 0, n = nums.Length;
            for (int i = 1; i < n; ++i) {
                if (nums[i] != nums[pre]) nums[++pre] = nums[i];
            }
            return pre + 1;    
        }
    }
}
