using System;

namespace rangeQuerySum_Immutable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{-2, 0, 3, -5, 2, -1};
            NumArray obj = new NumArray(nums);
            Console.WriteLine("sum range 0,2 :{0}", obj.SumRange(0, 2));           
            Console.WriteLine("sum range 2,5: {0}", obj.SumRange(2, 5)); 
            Console.WriteLine("sum range 0,5: {0}", obj.SumRange(0, 5)); 
        }
    }

    public class NumArray {
        int[] dp;
        public NumArray(int[] nums) {
            int n = nums.Length;
            dp = new int[n+1];
            for(int i = 0; i < n; i++){
                dp[i+1] = dp[i] + nums[i];
            }
        }
        
        public int SumRange(int i, int j) {
            // i <= j
            // inclusive of i, j
            return dp[j+1] - dp[i]; 
        }
    }
}
