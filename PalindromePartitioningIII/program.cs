public class Solution {
    public int PalindromePartition(string s, int k) {
        int n = s.Length;
        int[,] cost = new int[n,n];
        for (int i = 0; i < n; ++i)
          for (int j = i + 1; j < n; ++j)
            cost[i,j] = minChange(s, i, j);
        // dp[i][k] := min changes to make s[0~i] into k palindromes
        int[,] dp = new int[n, k+1];
        for (int i = 0; i < n; i++) 
            for (int x = 0; x <= k; x++)
                dp[i,x] = Int32.MaxValue / 2; // avoid overflow
        for (int i = 0; i < n; i++) {
            dp[i,1] = cost[0,i]; // the whole substr
            for (int x = 1; x <= k; x++) {
                for (int j = 0 ; j < i; j++) {
                    dp[i,x] = Math.Min(dp[i,x], dp[j,x-1] + cost[j+1,i]);    
                }
            }
        }
        return dp[n-1,k];
    }
    int minChange(string s, int i, int j) {
        int cnt = 0;
        while (i < j) 
            if (s[i++] != s[j--]) cnt++;
        return cnt;
    }
        
}
