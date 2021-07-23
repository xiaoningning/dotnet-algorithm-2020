public class Solution {
    public int MinCostII(int[][] costs) {
        if (costs.Length == 0 || costs[0].Length == 0) return 0;
        int m1 = 0, m2 = 0, k = -1;
        for (int i = 0; i < costs.Length; i++) {
            int lastm1 = Int32.MaxValue, lastm2 = lastm1, lastk = -1;
            for (int j = 0; j < costs[i].Length; j++) {
                var cost = costs[i][j] + ((j != k) ? m1 : m2);
                if (cost < lastm1) {
                    lastm2 = lastm1; lastm1 = cost; lastk = j;
                }
                else if (cost < lastm2) lastm2 = cost;
            }
            m1 = lastm1; m2 = lastm2; k = lastk;
        }
        return m1;
    }
    public int MinCostII2(int[][] costs) {
        if (costs.Length == 0 || costs[0].Length == 0) return 0;
        int n = costs.Length, k = costs[0].Length;
        // j1 is the index of the 1st-smallest cost till previous house
        // j2 is the index of the 2nd-smallest cost till previous house
        int j1 = -1, j2 = j1;
        var dp = costs;
        for (int i = 0; i < n; i++) {
            int tj1 = j1, tj2 = j2; 
            j1 = -1; j2 = j1;
            for (int j = 0; j < k; j++) {
                // only check the house with previous min cost and 2nd min cost colors
                dp[i][j] +=  (j != tj1) ? 
                    ((tj1 < 0) ? 0 : dp[i-1][tj1])
                    : ((tj2 < 0) ? 0 : dp[i-1][tj2]);
                // update the two min costs of index in this row of house
                if (j1 < 0 || dp[i][j] < dp[i][j1]) {
                    // assign 1st min to 2nd min index since there is a new min
                    j2 = j1; j1 = j;
                }
                else if (j2 < 0 || dp[i][j] < dp[i][j2]) j2 = j;
            }
        }
        return dp[n-1][j1];
    }
}
