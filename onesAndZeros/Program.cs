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
                    dp[zero, one] = Math.Max(dp[zero, one], 1 + dp[zero - tm, one - tn]);
                }
            }
        }
        return dp[m,n];
    }
}
