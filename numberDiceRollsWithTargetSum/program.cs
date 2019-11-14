public class Solution {
    public int NumRollsToTarget(int d, int f, int target) {
        var dp = new int[target + 1];
        dp[0] = 1;
        for (int i = 1; i <= d; ++i) {
            // each dice is independent of previous
            // so no dp -> copy to dp1
            var dp1 = new int[target + 1];
            for (int j = 1; j <= f; ++j) {
                for (int k = j; k <= target; ++k) {
                    dp1[k] = (dp1[k] + dp[k - j]) % (int)(1e9 + 7);  
                }                
            }
            Array.Copy(dp1, 0, dp, 0, target + 1);
        }
        return dp[target];
    }
}
