public class Solution {
    public int IslandPerimeter(int[][] grid) {
        if (!grid.Any() || !grid[0].Any()) return 0;
        int m = grid.Length, n = grid[0].Length, res = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) continue;
                //left
                if (j == 0 || grid[i][j - 1] == 0) ++res;
                // top
                if (i == 0 || grid[i - 1][j] == 0) ++res;
                // right
                if (j == n - 1 || grid[i][j + 1] == 0) ++res;
                // down
                if (i == m - 1 || grid[i + 1][j] == 0) ++res;
                // has land as neighbor, don't count edge
            }
        }
        return res;
    }
}
