public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        int m = matrix.GetLength(0), n = matrix[0].GetLength(0), p = m - 1, q = 0;
        while (p >= 0 && q < n) {
            int val = matrix[p][q], i = p, j = q;
            while (i + 1 < m && j + 1 < n) {
                if (matrix[++i][++j] != val) return false;
            }
            if (p > 0) --p;
            else ++q;
        }
        return true;
    }
    
    public bool IsToeplitzMatrix1(int[][] matrix) {
        // not check the last element at the boundery to avoid over flow index
        for (int i = 0; i < matrix.GetLength(0) - 1; ++i) {
            for (int j = 0; j < matrix[i].GetLength(0) - 1; ++j) {
                if (matrix[i][j] != matrix[i + 1][j + 1]) return false;
            }
        }
        return true;
    }
}
