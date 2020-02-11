public class Solution {
    public int MaxDistance(int[][] grid) {
        int res = -1;
        int n = grid.Length, m = grid[0].Length;
        var dirs = new int[4,2]{{0,-1},{-1,0},{0,1},{1,0}};
        var q = new Queue<int>();        
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (grid[i][j] == 1) q.Enqueue(i * m + j);
                
        int cnt = 0;
        while (q.Any()) {
            int size = q.Count;
            while (size-- > 0) {
                int t = q.Dequeue();
                int x = t / m, y = t % m;
                // visited already check distance cnt
                if (grid[x][y] == 2) res = Math.Max(res, cnt);
                for (int k = 0; k < 4; ++k) {
                    int tx = x + dirs[k,0], ty = y + dirs[k,1];
                    if (tx >= 0 && tx < n && ty >= 0 && ty < m && grid[tx][ty] == 0) {
                        grid[tx][ty] = 2; // 2 visited
                        q.Enqueue(tx * m + ty);    
                    } 
                }
            }
            cnt++;
        }
        // O(n^2)   
        return res;
    }
}
