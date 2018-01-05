using System;

namespace bestTimeBuySellStockWithCoolDown
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("price array: {0}", args[0]);
            int[] princes = Array.ConvertAll(args[0].Split(','), s => int.Parse(s));
            Console.WriteLine("Max profit: {0}", MaxProfit(princes));
        }
        
        static int MaxProfit(int[] prices) {
            if(prices == null || prices.Length <= 1) return 0;

            // After you sell your stock, you cannot buy stock on next day
            // one day rest in between buy and sell
            // it must be buy rest sell
            // can not be buy rest buy
            // buy[i] <= rest[i] => rest[i] = max(sell[i-1], rest[i-1])
            /*
                buy[i]  = max(rest[i-1] - price, buy[i-1]) 
                sell[i] = max(buy[i-1] + price, sell[i-1])
                rest[i] = max(sell[i-1], buy[i-1], rest[i-1])
             */
            int sell = 0, prev_sell = 0, buy = -prices[0], prev_buy;
            for (int i = 1; i < prices.Length; i++) {
                prev_buy = buy;
                buy = Math.Max(prev_buy, prev_sell - prices[i]);
                prev_sell = sell;
                sell = Math.Max(prev_sell, prev_buy + prices[i]);
                
            }
            return sell;
        }
    }
}
