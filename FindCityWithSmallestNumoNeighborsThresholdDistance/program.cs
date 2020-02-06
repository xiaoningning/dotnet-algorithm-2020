public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++) {
            dp[i] = new int[n];
            Array.Fill(dp[i], Int32.MaxValue / 2);
        }
        foreach (var e in edges) {
            dp[e[0]][e[1]] = e[2];
            dp[e[1]][e[0]] = e[2];
        }
        for (int i = 0; i < n; i++) dp[i][i] = 0;
        for (int k = 0; k < n; k++) 
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dp[i][j] = Math.Min(dp[i][j], dp[i][k] + dp[k][j]);
        int res = 0, mn = Int32.MaxValue;
        for (int i = 0; i < n; i++) {
            int cnt = 0;
            for (int j = 0; j < n; j++) {
                if (dp[i][j] <= distanceThreshold) cnt++;
            }
            if (cnt <= mn) {
                mn = cnt;
                res = i;
            }
        }
        return res;
    }
}
