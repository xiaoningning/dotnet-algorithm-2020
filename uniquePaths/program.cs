public class Solution {
    public int UniquePaths(int m, int n) {
        int[] dp = new int[n];
        Array.Fill(dp, 1);
        for (int i = 1; i < m; ++i) {
            for (int j = 1; j < n; ++j) {
                dp[j] += dp[j - 1]; 
            }
        }
        return dp[n - 1];
    }
    public int UniquePaths1(int m, int n) {
        int[,] dp = new int[m, n];
         for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                dp[i,j] = 1;
        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++)
                dp[i,j] = dp[i-1,j] + dp[i, j-1];
        }
        return dp[m-1,n-1];
    }
}
