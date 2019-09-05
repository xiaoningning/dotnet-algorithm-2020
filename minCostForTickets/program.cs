public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        int lastDay = days.Last();
        int[] dp = new int[lastDay + 1];
        for (int i = 1; i <= lastDay; i++) {
            if (!days.Contains(i)) {
                dp[i] = dp[i-1];
                continue;
            }
            // 1-day cost
            dp[i] = dp[i-1] + costs[0]; 
            // 7-day cost
            dp[i] = Math.Min(costs[1] + dp[Math.Max(i - 7, 0)], dp[i]);
            // 30-day cost
            dp[i] = Math.Min(costs[2] + dp[Math.Max(i - 30, 0)], dp[i]);       
        }
        return dp[lastDay];
    }
}
