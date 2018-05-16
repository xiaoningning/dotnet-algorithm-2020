using System;

namespace bestTimeBuySellStock
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] prices = new int[]{7,1,5,3,6,4};
            Console.WriteLine("best time buy sell stock {0}", string.Join(",", obj.MaxProfit(prices)));
        }        
    }
    public class Solution {
        public int MaxProfit(int[] prices) {
            int res = 0, minPrice = Int32.MaxValue;
            foreach (int price in prices) {
                minPrice = Math.Min(minPrice, price);
                res = Math.Max(res, price - minPrice);
            }
            return res;
        }
    }
}
