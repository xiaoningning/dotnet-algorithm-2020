public class Solution {
    public int FindMaxForm(string[] strs, int m, int n) {
        int[,] dp = new int[m+1,n+1];
        foreach (var s in strs) {
            int tm = s.Count(c => c == '0');
            int tn = s.Count(c => c == '1');
            for (int zero = m; zero >= tm; zero--) {
                for (int one = n; one >= tn; one--) {
                    // Each 0 and 1 can be used at most once.
                    // so bottom right to top left
                    // if top left to bottom right, then overcounting
                    // since reuse dp[i,j]
                    // Catch: have to go from bottom right to top left
                    // Why? If a cell in the memo is updated(because s is selected),
                    // we should be adding 1 to memo[i][j] from the previous iteration (when we were not considering s)
                    // If we go from top left to bottom right, we would be using results from this iteration => overcounting
                    dp[zero, one] = Math.Max(dp[zero, one], 1 + dp[zero - tm, one - tn]);
                }
            }
        }
        return dp[m,n];
    }
}
