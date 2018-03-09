using System;

namespace MinCostClimbingStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("stair cost: {0}", args[0]);
            int[] cost = Array.ConvertAll(args[0].Split(','), s => int.Parse(s));
            Console.WriteLine("min cost climbing stairs: {0}", MinCostClimbingStairs(cost));
        }
        static int MinCostClimbingStairs(int[] cost) {
            int n = cost.Length;
            int[] dp = new int[n];
            dp[0] = cost[0];
            dp[1] = cost[1];
            for (int i = 2; i < n; i++){
                dp[i] = cost[i] + Math.Min(dp[i-1], dp[i-2]);
            }
            return Math.Min(dp[n-2], dp[n-1]);
        }
    }
}
