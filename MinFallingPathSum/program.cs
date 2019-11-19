public class Solution {
    public int MinFallingPathSum(int[][] A) {
        int n = A.Length;
        for (int i = 1; i < n; i++) {
            for (int j = 0; j < n; j++) {
                // pick the min of 1st row
                // different from the previous row's column by at most one
                A[i][j] += Math.Min(A[i-1][j], Math.Min(A[i - 1][Math.Max(0, j - 1)], A[i - 1][Math.Min(n - 1, j + 1)]));
            }
        }
        return A[n-1].Min();
    }
}
