public class Solution {
    // BFS + memo
    // DP
    public int Racecar(int target) {
        int[] dp = new int[target + 1];
    
        for (int i = 1; i <= target; i++) {
            dp[i] = Int32.MaxValue;

            int m = 1, j = 1;
            // before i, acclerate
            for (; j < i; j = (1 << ++m) - 1) {
                for (int q = 0, p = 0; p < j; p = (1 << ++q) - 1) {
                    dp[i] = Math.Min(dp[i], m + 1 + q + 1 + dp[i - (j - p)]);
                }
            }
            // by pass i
            dp[i] = Math.Min(dp[i], m + (i == j ? 0 : 1 + dp[j - i]));
        }

        return dp[target];
    }
}
