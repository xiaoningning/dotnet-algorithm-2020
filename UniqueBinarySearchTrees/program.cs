public class Solution {
    public int NumTrees(int n) {
        // sum of BSTs
        var dp = new int[n + 1];
        dp[0] = 1; // root
        for (int i = 1; i <= n; i++)
          for(int j = 0; j < i; j++)
              // left child * right child
              dp[i] += dp[j] * dp[i - j - 1];
        return dp[n];
    }
}
