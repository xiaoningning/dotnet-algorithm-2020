public class Solution {
    public int FindLength(int[] A, int[] B) {
        int res = 0, m = A.Length, n = B.Length;
        var dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                dp[i,j] = (A[i - 1] == B[j - 1]) ? dp[i - 1,j - 1] + 1 : 0;
                res = Math.Max(res, dp[i,j]);
            }
        }
        return res;
    }
}
