public class Solution {
    public int MinDistance(string word1, string word2) {
        int n = word1.Length, m = word2.Length;
        int[,] dp = new int[n+1,m+1];
        for (int i = 1; i <= n; i++) dp[i,0] = i;
        for (int j = 1; j <= m; j++) dp[0,j] = j;
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m; j++) {
                if (word1[i-1] == word2[j-1]) dp[i,j] = dp[i-1,j-1];
                else {
                    dp[i,j] = Math.Min(dp[i-1,j-1], Math.Min(dp[i-1,j], dp[i,j-1])) + 1;
                }
            }
        }
        return dp[n,m];
    }
}
