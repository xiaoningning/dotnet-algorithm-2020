public class Solution {
    public int CountSquares(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        int res = 0;
        // dp[i][j] := edge of largest square with right bottom corner at (i, j)
        var dp = new int[m,n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                dp[i,j] = matrix[i][j];
                if (i > 0 && j > 0 && matrix[i][j] == 1) {
                    dp[i,j] = new int[]{dp[i-1,j-1], dp[i-1,j], dp[i,j-1]}.Min() + 1;
                }
                res += dp[i,j];
            }
        }
        return res;
    }
}
