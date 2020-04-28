public class Solution {
    public int MaxKilledEnemies(char[][] grid) {
        if (grid.Length == 0 || grid[0].Length == 0) return 0;
        int m = grid.Length, n = grid[0].Length, res = 0, rowCnt = 0;
        var colCnt = new int[n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) { 
                if (j == 0 || grid[i][j-1] == 'W') {
                    rowCnt = 0;
                    for (int k = j; k < n && grid[i][k] != 'W'; k++) 
                        rowCnt += grid[i][k] == 'E' ? 1 : 0;
                }
                if (i == 0 || grid[i-1][j] == 'W') {
                    colCnt[j] = 0;
                    for (int k = i; k < m && grid[k][j] != 'W'; k++) 
                        colCnt[j] += grid[k][j] == 'E' ? 1 : 0;
                }
                if (grid[i][j] == '0') res = Math.Max(res, rowCnt + colCnt[j]);
            }
        }
        return res;
    }
}
