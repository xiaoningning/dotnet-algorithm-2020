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
            int cash = 0, hold = -prices[0];
            for (int i = 1; i < prices.Length; i++) {
                cash = Math.Max(cash, hold + prices[i] - fee);
                hold = Math.Max(hold, cash - prices[i]);
            }
            return cash;
        }
    }
}
