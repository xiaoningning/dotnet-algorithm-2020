public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        int m = matrix.GetLength(0), n = matrix[0].GetLength(0);
        int left = matrix[0][0], right = matrix[m-1][n-1];
        // matrix is NOT sorted in snake order.
        // but sorted in col and row
        while (left < right) {
            int mid = left + (right - left) / 2;
            int cnt = 0, i = m - 1, j = 0;
            while (i >= 0 && j < n) {
                if (matrix[i][j] <= mid)  {
                    cnt += i+1;
                    j++;
                }
                else i--;
            }
            if (cnt < k) left = mid + 1;
            else right = mid;
        }
        return left;
    }
}
