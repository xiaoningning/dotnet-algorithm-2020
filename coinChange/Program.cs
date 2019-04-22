using System;

namespace coinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("coin change  {0}", obj.CoinChange1(new int[]{1,2,5}, 11));
        }
    }

    public class Solution {
        public int CoinChange1(int[] coins, int amount) {
            return Helper(coins, amount, new int[amount+1]);
        }
        
        // rem: remaining coins after the last step; 
        // count[rem]: minimum number of coins to sum up to rem
        private int Helper(int[] coins, int rem, int[] count) {
            if(rem < 0) return -1; // not valid
            if(rem == 0) return 0; // completed
            if(count[rem-1] != 0) return count[rem-1]; // already computed, so reuse
            int min = Int32.MaxValue;
            foreach (int coin in coins) {
                int res = Helper(coins, rem-coin, count);
                if(res>=0 && res < min) min = 1+res;
            }
            count[rem-1] = (min==Int32.MaxValue) ? -1 : min;
            return count[rem-1];
        }
        
        public int CoinChange(int[] coins, int amount) {
            int[] dp = new int[amount+1];
            // dont use int.maxvalue, 
            // later dp[i] +1 will overflow
            for (int i = 1; i <= amount; ++i) dp[i] = amount+1;
            dp[0] = 0;
            for (int i = 1; i <= amount; ++i) {
                for (int j = 0; j < coins.Length; ++j) {
                    if (coins[j] <= i) {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }
            return (dp[amount] > amount) ? -1 : dp[amount];
        }
    }
}
