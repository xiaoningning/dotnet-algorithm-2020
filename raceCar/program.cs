public class Solution {
    // BFS + memo
    // DP
    public int Racecar(int target) {
        int[] dp = new int[target + 1];
        for (int i = 1; i <= target; i++) {
            dp[i] = Int32.MaxValue;
            int j = 1, cnt1 = 1;
            // before i, acclerate
            for (; j < i; j = (1 << ++cnt1) - 1) {
                for (int k = 0, cnt2 = 0; k < j; k = (1 << ++cnt2) - 1) {
                    dp[i] = Math.Min(dp[i], cnt1 + 1 + cnt2 + 1 + dp[i - (j - k)]);
                }
            }
            // by pass i
            dp[i] = Math.Min(dp[i], cnt1 + (i == j ? 0 : 1 + dp[j - i]));
        }
        return dp[target];
    }
}
