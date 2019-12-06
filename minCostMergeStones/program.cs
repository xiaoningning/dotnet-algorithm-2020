public class Solution {
    // similar to burst balloons
    public int MergeStones(int[] stones, int K) {
        int n = stones.Length;
        // merge k to 1 => k - 1
        if ((n - 1) % (K - 1) != 0) return -1;
        int[] sums = new int[n+1];
        // cost of i to j merge as K
        int[,] dp = new int[n,n];
        for (int i = 1; i <= n; ++i) {
            sums[i] = sums[i - 1] + stones[i - 1];
        }
        for (int len = K; len <= n; ++len) {
            for (int i = 0; i + len <= n; ++i) {
                int j = i + len - 1;
                dp[i,j] = Int32.MaxValue;
                for (int t = i; t < j; t += K - 1) {
                    dp[i,j] = Math.Min(dp[i,j], dp[i,t] + dp[t + 1,j]);
                }
                // merge to 1 sum of j to i
                if ((j - i) % (K - 1) == 0) {
                    dp[i,j] += sums[j + 1] - sums[i];
                }
            }
        }
        return dp[0,n - 1];
    }
}
