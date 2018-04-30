using System;

namespace missingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{3, 0, 1};
            Console.WriteLine("find missing number: {0}", obj.MissingNumber(nums));            
        }
    }
    public class Solution {
        public int MissingNumber(int[] nums) {
            int sum = 0;
            int n = nums.Length;
            foreach(int i in nums){
                sum += i;
            }
            int targetSum = 0;
            for(int i = 1; i <= n; i++){
                targetSum += i;
            }
            return targetSum - sum;
        }
    }
}
