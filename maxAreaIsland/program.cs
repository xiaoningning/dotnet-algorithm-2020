public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int res = 0;
        for(int i = 0; i < grid.Length; i++)
            for(int j = 0; j < grid[0].Length; j++)
                if(grid[i][j] == 1)
                    res = Math.Max(res, AreaOfIsland(grid, i, j));
        return res ;
    }
    int AreaOfIsland(int[][] grid, int i, int j) {
        if (i >= 0 && i < grid.Length 
            && j >= 0 && j < grid[0].Length
            && grid[i][j] == 1) {
            // set it as 0 for visited
            grid[i][j] = 0;
            return 1 
                + AreaOfIsland(grid, i + 1, j)
                + AreaOfIsland(grid, i, j + 1)
                + AreaOfIsland(grid, i - 1, j)
                + AreaOfIsland(grid, i, j - 1);
        }
        return 0;
    }
}
