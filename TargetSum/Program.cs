using System;
using System.Collections.Generic;

namespace TargetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{1,1,1,1,1};
            int S = 3;
            Console.WriteLine("Find the ways of target sum: {0}", string.Join(",", nums));
            Console.WriteLine("The target sum: {0}", S);
            Console.WriteLine("the ways of target sum: {0}", FindTargetSumWays(nums, S));
        }
        static int FindTargetSumWays(int[] nums, int S) {
            int n = nums.Length;
            List<Dictionary<int, int>> dp = new List<Dictionary<int, int>>();
            
            // dict: key -> sum, value -> total cnt to get sum
            dp.Add(new Dictionary<int, int>());
            dp[0].Add(0,1);
            for (int i = 0; i < n; ++i) {
                dp.Add(new Dictionary<int, int>());
                foreach (var a in dp[i]) {
                    int sum = a.Key, cnt = a.Value;
                    dp[i + 1][sum + nums[i]] = dp[i+1].ContainsKey(sum + nums[i])? dp[i + 1][sum + nums[i]] + cnt : cnt;
                    dp[i + 1][sum - nums[i]] = dp[i+1].ContainsKey(sum - nums[i])? dp[i + 1][sum - nums[i]] + cnt : cnt;
                }
            }
            return dp[n].ContainsKey(S) ? dp[n][S] : 0;
        }
    }
}
