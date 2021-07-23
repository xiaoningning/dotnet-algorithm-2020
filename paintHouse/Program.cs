public class Solution {
    public int MinCost(int[][] costs) {
        if (costs.Length == 0 || costs[0].Length == 0 ) return 0;
        var n = costs.Length;
        var dp = costs;
        for (int i = 1; i < n; i++) {
            for (int j = 0; j < 3; j++) {
                dp[i][j] += Math.Min(dp[i-1][(j + 1) % 3], dp[i-1][(j + 2) % 3]);
            }
        }
        return new int[]{dp[n-1][0], dp[n-1][1], dp[n-1][2]}.Min();
    }
}
