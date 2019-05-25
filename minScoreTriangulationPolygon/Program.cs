public class Solution {
    public int MinScoreTriangulation(int[] A) {
        int n = A.Length;
        int[,] dp = new int[n,n];
        // triangle
        for (int k = 2; k <  n; k++) {
            for (int i = 0; i < n; i++) {
                int j = i + k;
                if (j >= n) break;
                // middle point of triangle
                for (int m = i+1; m < j; m++) {
                    // first time
                    if (dp[i,j] == 0) dp[i,j] = dp[i,m] + A[i]*A[m]*A[j] + dp[m,j];
                    // calc min value
                    else dp[i,j] = Math.Min(dp[i,j], dp[i,m] + A[i]*A[m]*A[j] + dp[m,j]);
                }
            }
        }
        return dp[0,n-1];
    }
}
