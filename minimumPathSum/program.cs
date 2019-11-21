public class Solution {
    public int MinPathSum(int[][] grid) {
        if (!grid.Any() || !grid[0].Any()) return 0;
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[i].Length; ++j) {
                if (i == 0 && j == 0) continue;
                if (i == 0) grid[0][j] += grid[0][j - 1];
                else if (j == 0) grid[i][0] += grid[i - 1][0];
                else grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
            }
        }
        return grid.Last().Last();
    }
}
