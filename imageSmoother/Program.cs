public class Solution {
    public int[][] ImageSmoother(int[][] M) {
        if (M.Length == 0 || M[0].Length == 0) return new int[][]{};
        int m = M.Length, n = M[0].Length;
        int[][] res = M;
        int[,] dirs = new int[,]{{0,-1},{-1,-1},{-1,0},{-1,1},{0,1},{1,1},{1,0},{1,-1}};
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                int cnt = M[i][j], all = 1;
                for (var k = 0; k < dirs.GetLength(0); k++) {
                    int x = i + dirs[k,0], y = j + dirs[k,1];
                    if (x < 0 || x >= m || y < 0 || y >= n) continue;
                    ++all;
                    cnt += M[x][y];
                }
                res[i][j] = cnt / all;
            }
        }
        return res;
    }
}
