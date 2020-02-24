public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        int l1 = s1.Length, l2 = s2.Length, l3 = s3.Length;
        if (l1 + l2 != l3) return false;
        var dp = new bool[l1+1, l2+1];
        dp[0,0] = true;
        for (int i = 0; i <= l1; i++) {
            for (int j = 0; j <= l2; j++) {
                if (i > 0) dp[i,j] |= dp[i-1,j] && s1[i - 1] == s3[i + j - 1];
                if (j > 0) dp[i,j] |= dp[i,j-1] && s2[j - 1] == s3[i + j - 1];
            }
        }
        return dp[l1,l2];
    }
}
