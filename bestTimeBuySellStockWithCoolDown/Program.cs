public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices == null || !prices.Any()) return 0;
        int sell = 0, buy = -prices[0], rest = 0;
        foreach(var p in prices){
            int prev_sell = sell;
            sell = buy + p;
            buy = Math.Max(buy, rest - p); 
            rest = Math.Max(rest, prev_sell); // rest a day
        }
        return Math.Max(rest, sell);
    }
    public int MaxProfit1(int[] prices) {
        if(prices == null || prices.Length <= 1) return 0;

        // one day rest in between buy and sell
        // buy[i]  = max(sell[i-2] - price, buy[i-1]) 
        // sell[i] = max(buy[i-1] + price, sell[i-1])
        int sell = 0, prev_sell = 0, buy = -prices[0], prev_buy;
        for (int i = 0; i < prices.Length; i++) {
            prev_buy = buy;
            buy = Math.Max(buy, prev_sell - prices[i]);
            prev_sell = sell;
            sell = Math.Max(sell, prev_buy + prices[i]);
        }
        return sell;
    }
}
