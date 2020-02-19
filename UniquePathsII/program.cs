public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        if (!obstacleGrid.Any() || !obstacleGrid[0].Any() || obstacleGrid[0][0] == 1) return 0;
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        var dp = new int[n]; 
        dp[0] = 1;
        for(int i = 0 ; i < m ; ++i)
            for(int j = 0 ; j < n ; ++j) {
                if(obstacleGrid[i][j] == 1) dp[j] = 0;
                // only care prev i
                else if (j > 0) dp[j] += dp[j - 1];
            }
        return dp[n-1];
    }
    public int UniquePathsWithObstacles1(int[][] obstacleGrid) {
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        var dp = new int[m+1, n+1];
        // dp[1][1] = 1  <= dp[0][1] + dp[1][0]
        // init dp[0][1] or dp[1][0] is enough
        dp[0,1] = 1;
        for(int i = 1 ; i <= m ; ++i)
            for(int j = 1 ; j <= n ; ++j)
                if(obstacleGrid[i-1][j-1] != 1)
                    dp[i,j] = dp[i-1, j]+dp[i, j-1];
        return dp[m,n];
    }
}
