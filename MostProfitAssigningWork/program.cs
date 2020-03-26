public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        var dp = new int[100001]; // difficulty -> profit and sorted
        int n = difficulty.Length, res = 0; 
        for (int i = 0; i < n; i++) dp[difficulty[i]] = Math.Max(dp[difficulty[i]], profit[i]);
        for (int i = 1; i < dp.Length; i++) dp[i] = Math.Max(dp[i], dp[i-1]);
        foreach(var a in worker) res += dp[a];
        return res; 
    }
}
