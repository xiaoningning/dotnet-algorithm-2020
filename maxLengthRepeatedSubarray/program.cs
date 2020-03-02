public class Solution {
     public int FindLength(int[] A, int[] B) { 
         if (A.Length < B.Length) {
             var t = A; A = B; B = t;
         }
         int res = 0, m = A.Length, n = B.Length;
         var dp = new int[m+1];
         for (int i = 1; i <= m; ++i) {
             // j-1 is previous i => j starts with n
            for (int j = n; j >= 1; --j) {
                dp[j] = (A[i - 1] == B[j - 1]) ? dp[j-1] + 1 : 0;
                res = Math.Max(res, dp[j]);
            }
         }
         // time: O(min(m,n))
         // space: O(min(m,n))
         return res;
     }
    public int FindLength1(int[] A, int[] B) {
        int res = 0, m = A.Length, n = B.Length;
        var dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                dp[i,j] = (A[i - 1] == B[j - 1]) ? dp[i - 1,j - 1] + 1 : 0;
                res = Math.Max(res, dp[i,j]);
            }
        }
        // time: O(m*n)
        // space: O(m*n)
        return res;
    }
}
