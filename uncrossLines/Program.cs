public class Solution {
    public int MaxUncrossedLines(int[] A, int[] B) {
        int n = A.Length, m = B.Length;
        int[,] dp = new int[n+1,m+1];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                dp[i+1, j+1] = Math.Max(dp[i+1, j], dp[i, j+1]);
                if (A[i] == B[j]) dp[i+1, j+1] = Math.Max(dp[i+1, j+1], dp[i, j] + 1);
            }
        }
        return dp[n, m];
    }
}
