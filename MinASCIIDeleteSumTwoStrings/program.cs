public class Solution {
    public int MinimumDeleteSum(string s1, string s2) {
        int l1 = s1.Length, l2 = s2.Length;
        var dp = new int[l1+1, l2+1];
        // similar to edit distance
        for (int i = 1; i <= l1; ++i) dp[i,0] = dp[i-1,0] + s1[i-1];
        for (int j = 1; j <= l2; j++) dp[0,j] = dp[0,j-1] + s2[j-1];
        for (int i = 1; i <= l1; ++i) {
            for (int j = 1; j <= l2; ++j) {
                dp[i,j] = (s1[i - 1] == s2[j - 1]) ? 
                    dp[i-1,j-1]
                    : Math.Min(dp[i-1,j] + s1[i-1], dp[i,j-1] + s2[j-1]);
            }
        }
        return dp[l1,l2];
    }
}
