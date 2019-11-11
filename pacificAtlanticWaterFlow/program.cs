public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] matrix) {
        var res = new List<IList<int>>();
        if (!matrix.Any() || !matrix[0].Any()) return res;
        int m = matrix.Length, n = matrix[0].Length;
        var pacific = new bool[m,n];
        var atlantic = new bool[m,n];
        for (int i = 0; i < m; ++i) {
            dfs(matrix, pacific, Int32.MinValue, i, 0);
            dfs(matrix, atlantic, Int32.MinValue, i, n - 1);
        }
        for (int i = 0; i < n; ++i) {
            dfs(matrix, pacific, Int32.MinValue, 0, i);
            dfs(matrix, atlantic, Int32.MinValue, m - 1, i);
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (pacific[i,j] && atlantic[i,j]) {
                    res.Add(new List<int>(){i, j});
                }
            }
        }
        return res;
    }
    void dfs (int[][] matrix, bool[,] visited, int pre, int i, int j) {
        int m = matrix.Length, n = matrix[0].Length;
        if (i < 0 || i >= m || j < 0 || j >= n || visited[i,j] || matrix[i][j] < pre) return;
        visited[i,j] = true;
        dfs(matrix, visited, matrix[i][j], i + 1, j);
        dfs(matrix, visited, matrix[i][j], i - 1, j);
        dfs(matrix, visited, matrix[i][j], i, j + 1);
        dfs(matrix, visited, matrix[i][j], i, j - 1);
    }
}
