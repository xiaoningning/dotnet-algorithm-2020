public class Solution {
    public int CherryPickup(int[][] grid) {
        int n = grid.Length;
        int mx = 2 * n - 1; // max steps of (0,0) -> (j,j)
        int[,] dp = new int[n,n];
        for (int i = 0; i < n*n; i++) dp[i % n, i / n] = -1; 
        dp[0, 0] = grid[0][0];
        for (int k = 1; k < mx; ++k) {
            for (int i = n - 1; i >= 0; --i) {
                for (int p = n - 1; p >= 0; --p) {
                    // i,p go forward
                    // j,q come back
                    int j = k - i, q = k - p;
                    if (j < 0 || j >= n || q < 0 || q >= n 
                        || grid[i][j] < 0 || grid[p][q] < 0) {
                        dp[i,p] = -1; continue;
                    }
                    if (i > 0) dp[i, p] = Math.Max(dp[i, p], dp[i - 1, p]);
                    if (p > 0) dp[i, p] = Math.Max(dp[i, p], dp[i, p - 1]);
                    if (i > 0 && p > 0) dp[i, p] = Math.Max(dp[i, p], dp[i - 1, p - 1]);
                    if (dp[i, p] >= 0) dp[i, p] += grid[i][j] + (i != p ? grid[p][q] : 0);
                }
            }
        }
        return Math.Max(dp[n - 1, n - 1], 0);
    }
}
