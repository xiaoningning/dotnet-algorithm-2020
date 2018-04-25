using System;
using System.Collections.Generic;

namespace MaxSizeSubArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{1, -1, 5, -2, 3};
            int k = 3;
            Console.WriteLine("Max size subarray eqaul Sum {0} : {1}", k, obj.MaxSubArrayLen(nums, k));
        }
    }
    public class Solution {
        public int MaxSubArrayLen(int[] nums, int k) {
            int n = nums.Length;
            int sum = 0;
            int max = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            // min index is 0, -1 is dummy value
            map[0] = -1; 
            for(int i = 0; i < n; i++){
                sum += nums[i];
                if(!map.ContainsKey(sum)) map[sum] = i;
                if(map.ContainsKey(sum - k)) max = Math.Max(max, i - map[sum - k]);
            }
            return max;
        }
    }
}
