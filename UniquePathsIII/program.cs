public class Solution {
    Dictionary<int, Dictionary<int, int>> cache = new Dictionary<int, Dictionary<int, int>>();
    int m;
    int n;
    public int UniquePathsIII(int[][] grid) {
        m = grid.Length; n = grid[0].Length;
        int state = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) { 
                if (grid[i][j] == 0 || grid[i][j] == 2) state |= 1 << (i * n + j);
                else if (grid[i][j] == 1) {
                    sx = i; sy = j;    
                }
            }
        }
        // O(2^mn * mn)
        return dfs(grid, sx, sy, state);
    }
    int dfs(int[][] grid, int x, int y, int state) {
        if (cache.ContainsKey(x * n + y) && cache[x * n + y].ContainsKey(state))
            return cache[x * n + y][state];
        if (grid[x][y] == 2) return state == 0 ? 1 : 0; 
        var dirs = new int[,]{{-1,0}, {0,-1}, {1,0}, {0,1}};
        int cnt = 0;
        for (int i = 0; i < 4; ++i) {
            int tx = x + dirs[i, 0];
            int ty = y + dirs[i, 1];
            if (tx < 0 || tx >= m || ty < 0 || ty >= n || grid[tx][ty] == -1) continue;
            if ((state & (1 << (tx *n + ty))) == 0) continue;
            cnt += dfs(grid, tx, ty, state & ~(1 << (tx * n + ty)));            
        }
        if (!cache.ContainsKey(x * n + y)) cache.Add(x * n + y, new Dictionary<int,int>());
        if (!cache[x * n + y].ContainsKey(state)) cache[x * n + y].Add(state, 0);
        cache[x * n + y][state] = cnt;
        return cache[x * n + y][state];
    }
    
    int res = 0, empty = 1, sx, sy, ex, ey;
    public int UniquePathsIII1(int[][] grid) {
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
        // O(4^mn)
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
