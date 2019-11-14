public class Solution {
    public int MaxVacationDays(int[][] flights, int[][] days) {
        int n = flights.Length, k = days[0].Length;
        var dp = new int[n];
        Array.Fill(dp, Int32.MinValue);
        dp[0] = 0;
        for (int j = 0; j < k; ++j) {
            // dp is prevous K
            int[] t = new int[n];
            Array.Copy(dp, 0, t, 0, n);
            for (int i = 0; i < n; ++i) {
                for (int p = 0; p < n; ++p) {
                    if (i == p || flights[p][i] == 1) {
                        t[i] = Math.Max(t[i], dp[p] + days[i][j]);
                    }
                }
            }
            Array.Copy(t, 0, dp, 0, n);;
        }
        return dp.Max();
    }
    
    public int MaxVacationDays1(int[][] flights, int[][] days) {
        int n = flights.Length, k = days[0].Length;
        var m = new int[n,k];
        // init start city 0 on Monday
        return helper(flights, days, 0, 0, m);
    }
    int helper (int[][] flights, int[][] days, int city, int day, int[,] memo) {
        int n = flights.Length, k = days[0].Length, res = 0;
        if (day == k) return 0;
        if (memo[city,day] > 0) return memo[city,day];
        for (int i = 0; i < n; ++i) {
            if (i == city || flights[city][i] == 1) {
                res = Math.Max(res, days[i][day] + helper(flights, days, i, day + 1, memo));
            }
        }
        memo[city,day] = res;
        return res;
    }
}
