public class Solution {
    // Union Find
    int[] uf;
    int Find(int id) {
        while (id != uf[id]) id = uf[id] = uf[uf[id]];
        return id;
    }
    void UnionFind(int i, int j) {
        i = Find(i); j = Find(j);
        uf[j] = i;
    }
    public int MaximumMinimumPath(int[][] A) {
        var dirs = new int[,] {{0,1},{1,0},{0,-1},{-1,0}};
        var q = new List<int[]>();
        int n = A.Length, m = A[0].Length;
        uf = new int[n*m];
        var visited = new int[n*m];
        var ids = new List<int[]>();
        for (int i = 0; i < n; ++i) 
            for (int j = 0; j < m; ++j) {
                uf[i*m + j] = i*m + j;
                ids.Add(new int[]{i,j});
            }
        ids.Sort((x,y) => A[y[0]][y[1]] - A[x[0]][x[1]]);
        // started with the biggest value cell to connect the find
        // the last one will be the smallest value in the path.
        foreach (var id in ids) {
            int i = id[0], j = id[1], k = i*m+j;
            visited[k] = 1;
            for (int d = 0; d < 4; d++) {
                int ni = i + dirs[d,0], nj = j + dirs[d,1], nk = ni*m+nj;
                if (ni >= 0 && ni < n && nj >= 0 && nj < m && visited[nk] == 1) UnionFind(k, nk);
            }
            if (Find(0) == Find(n*m - 1)) return A[i][j];
        }
        // O(nmlog(mn)).
        return -1;
    }
    // DFS
    public int MaximumMinimumPath1(int[][] A) {
        var dirs = new int[,] {{0,1},{1,0},{0,-1},{-1,0}};
        var q = new List<int[]>();
        int r = A.Length, c = A[0].Length, res = A[0][0];
        q.Add(new int[]{A[0][0], 0, 0});
        A[0][0] = -1; // visited
        while (q.Any()) {
            q.Sort((a,b) => b[0] - a[0]);
            var t = q.First();
            q.RemoveAt(0);
            int sc = t[0], i = t[1], j = t[2];
            res = Math.Min(res, sc);
            if (i == r - 1 && j == c - 1) break;
            for (int d = 0; d < 4; d++) {
                int ni = i + dirs[d,0], nj = j + dirs[d,1];
                if (ni < 0 || ni >= r || nj < 0 || nj >= c || A[ni][nj] < 0) continue;
                q.Add(new int[]{A[ni][nj], ni, nj});
                // q.Sort((a,b) => b[0] - a[0]);
                A[ni][nj] = -1;
            }
        }
        // O(rc*logrc)
        return res;
    }
}
