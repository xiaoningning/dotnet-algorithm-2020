public class Solution {
    public int ShortestPathAllKeys(string[] grid) {
        int m = grid.Length, n = grid[0].Length;    
        int allKeys = 0;
        var q = new Queue<int[]>();
        var visited = new HashSet<string>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                char c = grid[i][j];
                if (c == '@')  {
                    q.Enqueue(new int[]{i * n + j, 0}); 
                    visited.Add((i * n + j) + "-" + 0);
                }
                else if (c >= 'a' && c <= 'f') allKeys |= 1 << (c - 'a');
            }
        }
        var dirs = new int[,]{{-1,0}, {0,-1}, {1,0}, {0,1}};
        int res = 0;
        while (q.Any()) {
            int cnt = q.Count;
            while ( cnt-- > 0) {
                int[] t = q.Dequeue();
                int x = t[0] / n, y = t[0] % n;
                int keys = t[1];
                if (keys == allKeys) return res;
                for (int d = 0; d < 4; d++) {
                    int nx = x + dirs[d, 0], ny = y + dirs[d, 1];
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;
                    char c = grid[nx][ny];    
                    if (c == '#') continue;
                    // no key for A ~ F
                    if (c >= 'A' && c <= 'F' && (keys & (1 << (c - 'A'))) == 0) continue;
                    int nkeys = keys;
                    if (c >= 'a' && c <= 'f') nkeys |= 1 << (c - 'a');
                    if (visited.Contains((nx * n + ny) + "-" + nkeys)) continue;
                    q.Enqueue(new int[]{nx * n + ny, nkeys});
                    visited.Add((nx * n + ny) + "-" + nkeys);
                }
            }
            res++;
        }
        return -1;
    }
}
