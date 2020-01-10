public class Solution {
    public int LongestPalindromeSubseq(string s) {
        int n = s.Length;
        // # of palindrome str of i~j
        int[,] dp = new int[n+1,n+1];
        for (int len = 1; len <= n; ++len)
            for (int i = 0; i + len <= n; ++i) 
              dp[i,i + len] = s[i] == s[i + len - 1] ? 
                dp[i + 1,i + len - 1] + (len == 1 ? 1 : 2) 
                : Math.Max(dp[i,i + len - 1], dp[i + 1,i + len]);
        return dp[0,n];
    }
    public int LongestPalindromeSubseq1(string s) {
        int n = s.Length;
        int[,] m = new int[n,n];
        return helper(s, 0, n-1, m);
    }
    int helper(string s, int l, int r, int[,] m) {
        if (l > r) return 0;
        if (m[l,r] != 0) return m[l,r];
        m [l,r] = s[l] == s[r] ? 
            l == r ? 1 : 2 + helper(s, l+1, r-1, m)
            : Math.Max(helper(s, l+1, r, m), helper(s, l, r-1, m));
        return m[l,r];
    }
}
