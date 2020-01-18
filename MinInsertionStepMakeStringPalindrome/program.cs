public class Solution {
    // 516 longest palindromic subseq
    public int MinInsertions1(string s) {
        int n = s.Length;
        // dp[i][j] means the length of longest common sequence 
        // between i first letters in s1 and j first letters in s2
        // s2 is reverse string of s
        int[,] dp = new int[n+1, n+1];
        for (int i = 0; i < n; i++) 
            for (int j = 0; j < n; j++) 
                dp[i+1, j+1] = s[i] == s[n - 1 - j] ? dp[i,j] + 1: Math.Max(dp[i,j+1], dp[i+1,j]);
        return n - dp[n,n];
    }
    public int MinInsertions(string s) {
        int n = s.Length;
        // dp[i][j] := min chars to insert
        int[,] dp = new int[n, n];
        for (int len = 2; len <= n; len++) 
            for (int i = 0, j = len - 1; j < n; i++, j++) 
                dp[i, j] = s[i] == s[j] ? 
                        dp[i+1,j-1] : Math.Min(dp[i,j-1], dp[i+1,j]) + 1;
        return dp[0,n - 1];
    }
}
