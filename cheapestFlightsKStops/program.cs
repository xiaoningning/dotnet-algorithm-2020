public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
        var dp = new int[n];
        // don't use int32.maxvalue
        // + price later overflow as negative
        for (int j = 0; j < n; j++) dp[j] = (int)1e9;
        dp[src] = 0;
        for (int i = 0; i <= K; ++i) {
            // dp is prevous K
            int[] t = new int[n];
            Array.Copy(dp, 0, t, 0, n);
            foreach (var x in flights) {
                t[x[1]] = Math.Min(t[x[1]], dp[x[0]] + x[2]);
            }
            Array.Copy(t, 0, dp, 0, n);;
        }
        return (dp[dst] == (int)1e9) ? -1 : dp[dst];
    }
}
