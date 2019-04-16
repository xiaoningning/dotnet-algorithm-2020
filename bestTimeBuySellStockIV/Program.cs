using System;

namespace bestTimeBuySellStockIV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("price array: {0}", args[0]);
            int k = int.Parse(args[1]);
            Console.WriteLine("# transaction: {0}", k);            
            int[] princes = Array.ConvertAll(args[0].Split(','), s => int.Parse(s));
            Console.WriteLine("Max profit: {0}", MaxProfit(k, princes));
        }

        /**
        * dp[i, j] represents the max profit up until prices[j] using at most i transactions. 
        * dp[i, j] = max(dp[i, j-1], prices[j] - prices[jj] + dp[i-1, jj]) { jj in range of [0, j-1] }
        *          = max(dp[i, j-1], prices[j] + max(dp[i-1, jj] - prices[jj]))
        * dp[0, j] = 0; 0 transactions makes 0 profit
        * dp[i, 0] = 0; if there is only one price data point you can't make any transaction.
        */
        
        static int MaxProfit(int k, int[] prices) {
            if(prices == null || prices.Length <= 1) return 0;

            if ( k >= prices.Length / 2) {
                int sell = 0, buy = -prices[0];
                for (int i = 1; i < prices.Length; i++) {
                    int prev_sell = sell;
                    sell = Math.Max(sell, buy + prices[i]);
                    buy = Math.Max(buy, prev_sell - prices[i]);
                }
                return sell;
            }
            else {
                int[,] dp = new int[k+1, prices.Length];
                for (int i = 1; i <= k; i++) {
                   int tmpMax = dp[i-1,0]-prices[0];
                   for (int j = 1; j < prices.Length; j++) {
                      dp[i,j] = Math.Max(dp[i,j - 1], prices[j] + tmpMax);
                      tmpMax =  Math.Max(tmpMax, dp[i - 1,j - 1] - prices[j]);
                   }
                }
                return dp[k,prices.Length-1];
            }
        }
        
        static int MaxProfit1(int k, int[] prices) {
            if(prices == null || prices.Length <= 1) return 0;

            if ( k >= prices.Length / 2) {
                int sell = 0, buy = -prices[0];
                for (int i = 1; i < prices.Length; i++) {
                    int prev_sell = sell;
                    sell = Math.Max(sell, buy + prices[i]);
                    buy = Math.Max(buy, prev_sell - prices[i]);
                }
                return sell;
            }
            else {
                /*
                local[i][j] = max(global[i - 1][j - 1] + max(diff, 0), local[i - 1][j] + diff)
                global[i][j] = max(local[i][j], global[i - 1][j])
                 */
                
                int[] local = new int[k+1], global = new int[k+1];
                for (int i = 0; i < prices.Length - 1; i++) {
                    int diff = prices[i + 1] - prices[i];
                    for (int j = k; j >= 1; j--){
                        local[j] = Math.Max(global[j-1] + Math.Max(diff, 0), local[j] + diff);
                        global[j] = Math.Max(global[j], local[j]);
                    }
                }
                return global[k];
            }
        }
    }
}
