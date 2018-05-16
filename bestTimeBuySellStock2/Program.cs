using System;

namespace bestTimeBuySellStock2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] prices = new int[]{7,1,5,3,6,4};
            Console.WriteLine("best time buy sell stock 2 : {0}", string.Join(",", obj.MaxProfit(prices)));
        }
    }
    public class Solution {
        public int MaxProfit(int[] prices) {
            int res = 0;
            for (int i = 0; i < prices.Length - 1; ++i) {
                if (prices[i] < prices[i + 1]) {
                    res += prices[i + 1] - prices[i];
                }
            }
            return res;    
        }
    }
}
