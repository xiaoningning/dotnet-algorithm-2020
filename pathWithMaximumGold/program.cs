public class Solution {
    int[,] dirs = new int[4,2]{{0,1},{0,-1},{1,0},{-1,0}};
    public int GetMaximumGold(int[][] grid) {
        int res = 0;
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                res = Math.Max(res, Dfs(grid, i, j));
            }
        }
        return res;
    }
    int Dfs(int[][] grid, int i, int j) {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] <= 0) return 0;
        // mark as visited
        grid[i][j] = -grid[i][j];
        int res = new int[]{Dfs(grid, i+1, j), Dfs(grid, i, j+1), Dfs(grid, i - 1, j), Dfs(grid, i, j-1)}.Max();
        grid[i][j] = -grid[i][j];
        return res + grid[i][j];
    }
}
