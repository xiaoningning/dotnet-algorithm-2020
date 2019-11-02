using System;

namespace bestTimeBuySellStock3
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] prices = new int[]{3,3,5,0,0,3,1,4};
            Console.WriteLine("best time buy sell stock 3 : {0}", string.Join(",", obj.MaxProfit(prices)));
        }
    }
    public class Solution {
        public int MaxProfit(int[] prices) {
            if (prices.Length == 0) return 0;
            // at most 2 transactions
            var dp = new int[3, prices.Length];
            for (int k = 1; k <= 2; k++) {
                int min = prices[0];
                for (int i = 1; i < prices.Length; i++) {
                    min = Math.Min(min, prices[i] - dp[k-1, i-1]);
                    dp[k, i] = Math.Max(dp[k, i-1], prices[i] - min);
                }
            }
            return dp[2, prices.Length - 1];
        }
        
        public int MaxProfit1(int[] prices) {
            return MaxProfitWithK(prices, 2);
        }
        
        int MaxProfitWithK(int[] prices, int k){
            int n = prices.Length;
            if(n == 0) return 0;
            int[,] localRes = new int[n,k+1];
            int[,] globalRes = new int[n,k+1];
            for (int i = 1; i < n; ++i) {
                int diff = prices[i] - prices[i - 1];
                for (int j = 1; j <= k; ++j) {
                    // localRes: the last j transaction happens on the day i
                    // globalRes: j transaction happens in the past i day, the last transaction is not necessary on the day i
                    localRes[i,j] = Math.Max(globalRes[i - 1,j - 1] + Math.Max(diff, 0), localRes[i - 1,j] + diff);
                    globalRes[i,j] = Math.Max(localRes[i,j], globalRes[i - 1,j]);
                    
                }
            }
            return globalRes[n-1, k];      
        }
    }
}
