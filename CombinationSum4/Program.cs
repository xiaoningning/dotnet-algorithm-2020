using System;

namespace CombinationSum4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{1, 2, 3};
            int target = 4;
            Console.WriteLine("CombinationSum4: {0}", CombinationSum4(nums, target));
        }
        static int CombinationSum4(int[] nums, int target) {
            int[] dp = new int[target+1];
            dp[0] = 1;
            for(int i = 1; i <= target; i++){
                for(int j = 0; j < nums.Length; j++){
                    if (i >= nums[j]) dp[i] += dp[i - nums[j]];
                }
            }
            return dp[target];
        }
    }
}
