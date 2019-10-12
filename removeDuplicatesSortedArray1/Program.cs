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
        public int RemoveDuplicates1(int[] nums) {
            int n = nums.Length;
            if (n == 0) return 0;
            int j = 0;
            for (int i = 0; i < n; i++) {
               if (nums[i] != nums[j]) nums[++j] = nums[i];
            }
            return j + 1;
        }

        public int RemoveDuplicates(int[] nums) {
            int n = nums.Length;
            if (n == 0) return 0;
            int pre = 0, cur = 0;
            while (cur < n) {
                if (nums[pre] == nums[cur]) ++cur;
                else nums[++pre] = nums[cur++];
            }
            return pre + 1;
        }
    }
}
