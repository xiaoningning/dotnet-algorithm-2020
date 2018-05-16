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
