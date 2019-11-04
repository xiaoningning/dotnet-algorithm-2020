public class Solution {
    public int LongestPalindromeSubseq(string s) {
        int n = s.Length;
        int[,] m = new int[n,n];
        return helper(s, 0, n-1, m);
    }
    int helper(string s, int l, int r, int[,] m) {
        if (l == r) return 1;
        if (l > r) return 0;
        if (m[l,r] != 0) return m[l,r];
        m [l,r] = s[l] == s[r] ? 
            2 + helper(s, l+1, r-1, m)
            : Math.Max(helper(s, l+1, r, m), helper(s, l, r-1, m));
        return m[l,r];
    }
}
