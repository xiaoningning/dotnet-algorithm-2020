public class Solution {
    public int[] FindDiagonalOrder(int[][] matrix) {
        if (matrix.Length == 0 || matrix[0].GetLength(0) == 0) return new int[]{};
        int m = matrix.GetLength(0), n = matrix[0].GetLength(0), r = 0, c = 0, k = 0;
        int[,] dirs = new int[,]{{-1,1}, {1,-1}};
        int[] res = new int[m*n];
        for (int i = 0; i < m * n; ++i) {
            res[i] = matrix[r][c];
            r += dirs[k, 0];
            c += dirs[k, 1];
            // over boundary, reset and change direction
            if (r >= m) {r = m - 1; c += 2; k = (k + 1) % 2;}
            if (c >= n) {c = n - 1; r += 2; k = (k + 1) % 2;}
            if (r < 0) {r = 0; k = (k + 1) % 2;}
            if (c < 0) {c = 0; k = (k + 1) % 2;}
        }
        return res;
    }
}
