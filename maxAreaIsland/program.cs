public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int res = 0, m = grid.Length, n = grid[0].Length;
        var dirs = new int[4,2]{{0,-1},{-1,0},{0,1},{1,0}};
        for(int i = 0; i < m; i++) {
            for(int j = 0; j < n; j++) {
                if (grid[i][j] != 1) continue;
                int cnt = 0;
                var q = new Queue<int[]>();
                q.Enqueue(new int[]{i,j});
                grid[i][j] = -1;
                while (q.Any()) {
                    var t = q.Dequeue();
                    res = Math.Max(res, ++cnt);
                    for(int d = 0; d < dirs.GetLength(0); d++) {
                        int x = t[0] + dirs[d,0], y = t[1] + dirs[d,1];
                        if (x >= 0 && x < m && y >=0 && y < n && grid[x][y] == 1) {
                            grid[x][y] = -1;
                            q.Enqueue(new int[]{x,y});
                        }
                    }
                }
            }
        }
        return res; 
    }
    
    public int MaxAreaOfIsland1(int[][] grid) {
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
