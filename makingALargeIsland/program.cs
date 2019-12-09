public class Solution {
    public int LargestIsland(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, res = 0;
        bool hasZero = false;
        var dirs = new int[4,2]{{0,-1},{-1,0},{0,1},{1,0}};
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                // change 0 to 1;
                if (grid[i][j] == 1) continue;
                var visited = new bool[m,n];
                var q = new Queue<int>(); q.Enqueue(i * n + j);
                int sum = 0;
                while (q.Any()) {
                    int t = q.Dequeue();
                    ++sum;
                    for (int k = 0; k < 4; ++k) {
                        int x = t / n + dirs[k,0], y = t % n + dirs[k,1];
                        if (x < 0 || x >= m || y < 0 || y >= n || grid[x][y] == 0 || visited[x,y]) continue;
                        visited[x,y] = true;
                        q.Enqueue(x * n + y);
                    }
                }
                res = Math.Max(res, sum);
                // reach the max just return
                if (res == m * n) return res;
                // changed one 0 to 1 already
                hasZero = true;
            }
        }
        return hasZero ? res : m * n;
    }
}
