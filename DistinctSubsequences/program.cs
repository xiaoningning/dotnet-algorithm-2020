public class Solution {
    public int NumDistinct(string s, string t) {
        int ls = s.Length, lt = t.Length;
        var dp = new int[lt+1, ls+1];
        for (int i = 0; i <= ls; i++) dp[0,i] = 1;
        for (int i = 1; i <= lt; i++) {
            for (int j = 1; j <= ls; j++) {
                // if not equal, skip s[j-1]
                dp[i,j] = dp[i, j-1] + (t[i-1] == s[j-1] ? dp[i-1,j-1] : 0);
            }
        }
        return dp[lt,ls];
    }
}
