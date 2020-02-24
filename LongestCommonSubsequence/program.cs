public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        int l1 = text1.Length, l2 = text2.Length;
        var dp = new int[l1+1, l2+1];
        for (int i = 0; i < l1; i++) {
            for (int j = 0; j < l2; j++) {
                if (text1[i] == text2[j]) dp[i+1,j+1] = dp[i,j] + 1;
                else dp[i+1,j+1] = Math.Max(dp[i,j+1], dp[i+1,j]);
            }
        }
        return dp[l1,l2];
    }
}
