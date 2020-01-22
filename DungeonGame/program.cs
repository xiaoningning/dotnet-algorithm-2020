public class Solution {
    public int CalculateMinimumHP(int[][] dungeon) {
        int m = dungeon.GetLength(0), n = dungeon[0].GetLength(0);
        // dp[y][x]: min health point required to reach bottom right (P).
        int[] dp = new int[n+1];
        Array.Fill(dp, Int32.MaxValue);
        dp[n - 1] = 1; //n -1 at least 1 to reach [m,n]
        for (int i = m - 1; i >= 0; --i)
            for (int j = n - 1; j >= 0; --j)
                dp[j] = Math.Max(1, Math.Min(dp[j], dp[j + 1]) - dungeon[i][j]);
        return dp[0];
    }
}
