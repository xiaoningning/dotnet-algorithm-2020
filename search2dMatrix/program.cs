public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        if (matrix.Length == 0) return false;
        int m = matrix.GetLength(0), n = matrix[0].Length;
        if (n == 0 || target < matrix[0][0] || target > matrix[m-1][n-1]) return false;
        int left = 0, right = m*n;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (matrix[mid / n][mid % n] == target) return true;
            else if (matrix[mid / n][mid % n] < target) left = mid + 1;
            else right = mid;
        }
        return false;
    }
}
