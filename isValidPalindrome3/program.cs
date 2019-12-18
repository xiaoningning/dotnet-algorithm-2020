public class Solution {
    public bool IsValidPalindrome(string s, int k) {
        int n = s.Length;
        int[,] dp = new int[n,n];
        for (int i = n-1; i >= 0; i--) {
            for (int j = i+1; j < n; j++) {
                if (s[j] == s[i]) dp[i,j] = dp[i+1,j-1];
                else dp[i,j] = 1+ Math.Min(dp[i + 1,j], dp[i,j - 1]);
            }
        }
        return dp[0,n-1] <= k;
    }
    public bool IsValidPalindrome1(string s, int k) {
        int n = s.Length;
        // steps to be palindrome
        int[,] m = new int[n,n];
        return helper(s, 0, n-1, m) <= k;
    }
    int helper(string s, int l, int r, int[,] m) {
        if (l == r) return 0;
        if (l > r) return 0;
        if (m[l,r] != 0) return m[l,r];
        m[l,r] = s[l] == s[r] ? 
            0 + helper(s, l+1, r-1, m)
            : Math.Min(helper(s, l+1, r, m), helper(s, l, r-1, m)) + 1;
        return m[l,r];
    }
}
