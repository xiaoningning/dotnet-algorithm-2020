public class Solution {
    public int NumSquares(int n) {
        var dp = new int[n + 1];
        Array.Fill(dp, Int32.MaxValue);
        dp[0] = 0;
        for (int i = 0; i <= n; ++i) {
            for (int j = 1; i + j * j <= n; ++j) {
                dp[i + j * j] = Math.Min(dp[i + j * j], dp[i] + 1);
            }
        }
        return dp[n];
    }
}
