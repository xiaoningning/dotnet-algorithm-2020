public class Solution {
    public int MinDistance(string word1, string word2) {
        int l1 = word1.Length, l2 = word2.Length;
        var dp = new int[l1+1, l2+1];
        // similar to edit distance
        for (int i = 0; i <= l1; i++) dp[i,0] = i;
        for (int j = 0; j <= l2; j++) dp[0,j] = j;
        for (int i = 1; i <= l1; ++i) {
            for (int j = 1; j <= l2; ++j) {
                if (word1[i - 1] == word2[j - 1]) {
                    dp[i,j] = dp[i - 1,j - 1];
                } else {
                    dp[i,j] = 1 + Math.Min(dp[i - 1,j], dp[i,j - 1]);
                }
            }
        }
        return dp[l1,l2];
    }
}
