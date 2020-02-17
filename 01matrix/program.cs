public class Solution {
    public int[][] UpdateMatrix(int[][] matrix) {
        int m = matrix.GetLength(0), n = matrix[0].GetLength(0);
        int[][] res = new int[m][];
        for (int i = 0; i < m; ++i) res[i] = new int[n];
        for (int i = 0; i < m; ++i)
            for (int j = 0; j < n; ++j)
                res[i][j] = Int32.MaxValue - 1;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (matrix[i][j] == 0) res[i][j] = 0;
                else {
                    if (i > 0) res[i][j] = Math.Min(res[i][j], res[i - 1][j] + 1);
                    if (j > 0) res[i][j] = Math.Min(res[i][j], res[i][j - 1] + 1);
                }
            }
        }
        for (int i = m - 1; i >= 0; --i) {
            for (int j = n - 1; j >= 0; --j) {
                if (res[i][j] != 0 && res[i][j] != 1) {
                    if (i < m - 1) res[i][j] = Math.Min(res[i][j], res[i + 1][j] + 1);
                    if (j < n - 1) res[i][j] = Math.Min(res[i][j], res[i][j + 1] + 1);
                }
            }
        }
        // DP O(mn)
        return res;
    }
}
