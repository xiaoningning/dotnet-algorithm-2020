using System;

namespace bestTimeBuySellStockWithFee
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("price array: {0}", args[0]);
            int fee = int.Parse(args[1]);
            Console.WriteLine("transaction fee: {0}", fee);            
            int[] princes = Array.ConvertAll(args[0].Split(','), s => int.Parse(s));
            Console.WriteLine("Max profit: {0}", MaxProfit(princes, fee));
        }
        
        static int MaxProfit(int[] prices, int fee) {
            if(prices == null || prices.Length <= 1) return 0;

            int sell = 0, buy = -prices[0];
            for (int i = 1; i < prices.Length; i++) {
                int prev_sell = sell;
                sell = Math.Max(sell, buy + prices[i] - fee);
                buy = Math.Max(buy, prev_sell - prices[i]);
            }
            return sell;
        }
    }
}
