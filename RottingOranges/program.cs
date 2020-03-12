public class Solution {
    public int OrangesRotting(int[][] grid) {
        int n = grid.Length, m = grid[0].Length, fresh = 0, days = 0;
        var q = new Queue<int[]>();
        var dirs = new int[,]{{1,0}, {-1,0}, {0,1}, {0,-1}};
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1) fresh++;
                else if (grid[i][j] == 2) q.Enqueue(new int[]{i,j});
            }
        }   
        
        // BFS
        while (q.Any() && fresh > 0) {
            var size = q.Count;
            while (size-- > 0) {
                var t = q.Dequeue();
                int x = t[0], y = t[1];
                for (int d = 0; d < 4; d++) {
                    int dx = x + dirs[d,0], dy = y + dirs[d,1];
                    if (dx < 0 || dx >= n || dy < 0 || dy >= m || grid[dx][dy] != 1) continue;
                    fresh--;
                    grid[dx][dy] = 2;
                    q.Enqueue(new int[]{dx, dy});
                }
            }
            days++;
        }
        // O(mn)
        return fresh == 0 ? days : -1;
    }
}
