public class Solution {
    public int TrapRainWater(int[][] heightMap) {
        if (!heightMap.Any()) return 0;
        int res = 0, mx = Int32.MinValue, m = heightMap.GetLength(0), n = heightMap[0].GetLength(0);
        int[,] dir = new int[,]{{0,-1},{-1,0},{0,1},{1,0}};
        var q = new List<int[]>();
        var visited = new bool[m,n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i == 0 || i == m - 1 || j == 0 || j == n - 1) {
                    q.Add(new int[]{heightMap[i][j], i * n + j});
                    visited[i,j] = true;
                }
            }
        }
        q = q.OrderBy(x => x[0]).ToList();
        while (q.Any()) {
            var t = q.First(); q.Remove(t);
            int h = t[0], r = t[1] / n, c = t[1] % n;
            mx = Math.Max(mx, h);
            for (int i = 0; i < dir.GetLength(0); ++i) {
                int x = r + dir[i,0], y = c + dir[i,1];
                if (x < 0 || x >= m || y < 0 || y >= n || visited[x,y]) continue;
                visited[x,y] = true;
                if (heightMap[x][y] < mx) res += mx - heightMap[x][y];
                q.Add(new int[]{heightMap[x][y], x * n + y});
            }
            q = q.OrderBy(x => x[0]).ToList();
        }
        return res;
    }
}
