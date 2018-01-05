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
