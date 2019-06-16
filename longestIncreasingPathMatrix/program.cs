public class Solution {
    public int LongestIncreasingPath(int[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0) return 0;
        int res = 0, n = matrix.GetLength(0), m = matrix[0].GetLength(0);
        int[,] dp = new int[n,m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                res = Math.Max(res, DFS(matrix, dp, i, j));
            }
        }
        return res;
    }
    int[,] dirs = new int[,]{{0, -1}, {-1, 0}, {0, 1}, {1, 0}};
    int DFS(int[][] matrix, int[,] dp, int i, int j) {
        if (dp[i,j] != 0) return dp[i,j];
        int mx = 1, n = matrix.GetLength(0), m = matrix[0].GetLength(0);
        for (int k = 0; k < dirs.GetLength(0); k++) {
            int x = i + dirs[k,0], y = j + dirs[k,1];
            if (x < 0 || x >= n || y < 0 || y >= m || matrix[x][y] <= matrix[i][j]) continue;
            int len = 1 + DFS(matrix, dp, x, y);
            mx = Math.Max(mx, len);
        }
        dp[i,j] = mx;
        return mx;
    }
}
