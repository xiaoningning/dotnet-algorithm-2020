public class Solution {
    int res = 0, empty = 1, sx, sy, ex, ey;
    public int UniquePathsIII(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) empty++;
                else if (grid[i][j] == 1) {
                    sx = i;
                    sy = j;
                } else if (grid[i][j] == 2) {
                    ex = i;
                    ey = j;
                }
            }
        }
        dfs(grid, sx, sy);
        return res;
    }
    void dfs(int[][] grid, int x, int y) {
        if (x < 0 || x >= grid.Length 
            || y < 0 || y >= grid[0].Length 
            || grid[x][y] < 0) return;
        if (x == ex && y == ey) {
            // walk all emtpy but exactly once
            if (empty == 0) res++;
            return;
        }
        grid[x][y] = -2;
        empty--;
        dfs(grid, x + 1, y);
        dfs(grid, x - 1, y);
        dfs(grid, x, y + 1);
        dfs(grid, x, y - 1);
        grid[x][y] = 0;
        empty++;
    }
}
