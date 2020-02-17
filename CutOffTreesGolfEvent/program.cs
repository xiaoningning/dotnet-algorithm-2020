public class Solution {
    public int CutOffTree(IList<IList<int>> forest) {
        int m = forest.Count, n = forest[0].Count, row = 0, col = 0, res = 0;
        var trees = new List<int[]>();
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (forest[i][j] > 1) trees.Add(new int[]{forest[i][j], i, j});
        trees.Sort((a,b) => a[0] - b[0]);
        foreach (var t in trees) {
            int cnt = bfs(forest, row, col, t[1], t[2]);
            if (cnt == -1) return -1;
            res += cnt;
            row = t[1]; col = t[2];
        } 
        // O(mn * mn)
        return res;
    }
    int bfs(IList<IList<int>> forest, int sx, int sy, int tx, int ty) {
        if (sx == tx && sy == ty) return 0;
        int m = forest.Count, n = forest[0].Count, cnt = 0;
        var dirs = new int[]{-1, 0, 1, 0, -1};
        var q = new Queue<int>();
        var visited = new HashSet<int>(sx * n + sy); 
        q.Enqueue(sx * n + sy);
        while (q.Any()){
            int size = q.Count;
            cnt++;
            while (size-- > 0) {
                int t = q.Dequeue();
                int r = t / n, c = t % n;
                for (int k = 0; k < 4; ++k) {
                    int nr = r + dirs[k], nc = c + dirs[k+1];
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n 
                        || visited.Contains(nr * n + nc)
                        || forest[nr][nc] == 0) continue;
                    if (nr == tx && nc == ty) return cnt;
                    visited.Add(nr * n + nc);
                    q.Enqueue(nr * n + nc);
                } 
                
            }
        }
        return -1;
    }
}
