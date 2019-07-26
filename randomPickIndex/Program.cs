using System;

namespace randomPickIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {1,2,3,3,3};
            var obj = new Solution(nums);
            Console.WriteLine("random pick index:{0}", obj.Pick(3));
        }
    }
    public class Solution {
        int[] nums;
        Random rnd;

        public Solution(int[] nums) {
            this.nums = nums;
            this.rnd = new Random();
        }
        
        public int Pick(int target) {
            int result = -1;
            int count = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] != target) continue;
                // Random.Next(min, max) ->
                // min: inclusive
                // max: exclusive
                if (rnd.Next(0, ++count) == 0) result = i;
            }        
            return result;
        }
    }
}
