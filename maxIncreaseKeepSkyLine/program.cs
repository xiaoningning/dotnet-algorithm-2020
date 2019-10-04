public class Solution {
    public int MaxIncreaseKeepingSkyline(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, res = 0;
        int[] col = new int[m], row = new int[n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                row[i] = Math.Max(row[i], grid[i][j]);
                col[j] = Math.Max(col[j], grid[i][j]);
            }
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                res += Math.Min(row[i] - grid[i][j], col[j] - grid[i][j]);
            }
        }
        return res;
    }
}
