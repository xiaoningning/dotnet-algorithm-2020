public class Solution {
    public bool PredictTheWinner(int[] nums) {
        int n = nums.Length;
        // dp: score of first player
        var dp = new int[n,n];
        for (int i = 0; i < n; i++) dp[i,i] = nums[i];
        for (int len = 1; len < n; len++) {
            for (int i = 0; i < n - len; i++) {
                int j = i + len;
                dp[i,j] = Math.Max(nums[i] - dp[i+1,j], nums[j] - dp[i,j-1]);
            }
        }
        return dp[0,n-1] >= 0;
    }
    public bool PredictTheWinner1(int[] nums) {
        int n = nums.Length;
        // dp: score of first player
        var dp = new int[n][];
        for (int i = 0; i < n; i++) {
            dp[i] = new int[n];
            Array.Fill(dp[i], -1);
        }
        return canWin(nums, 0, n - 1, dp) >= 0;
    }
    // canWin: first play recursive winning score result.  play1 > play 2 => play 1 win
    int canWin(int[] nums, int s, int e, int[][] dp) {
        if (dp[s][e] == -1) {
            dp[s][e] = s == e ? nums[s] :
                Math.Max(nums[s] - canWin(nums, s+1, e, dp), nums[e] - canWin(nums, s, e-1, dp));
        }
        return dp[s][e];
    }
}
