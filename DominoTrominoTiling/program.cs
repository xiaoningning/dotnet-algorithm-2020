public class Solution {
    public int NumTilings(int N) {
        int M = (int)1e9+7;
        /**
        dp[n]=dp[n-1]+dp[n-2]+ 2*(dp[n-3]+...+d[0])
        =dp[n-1]+dp[n-2]+dp[n-3]+dp[n-3]+2*(dp[n-4]+...+d[0])
        =dp[n-1]+dp[n-3]+(dp[n-2]+dp[n-3]+2*(dp[n-4]+...+d[0]))
        =dp[n-1]+dp[n-3]+dp[n-1]
        =2*dp[n-1]+dp[n-3]
            */
        if(N <= 1) return 1;
        var dp = new long[N+1];
        dp[0] = 1; dp[1] = 1; dp[2] = 2;
        for (int i = 3; i <= N; i++) {
            dp[i] = (2 * dp[i - 1] + dp[i - 3]) % M;
        }
        return (int)dp[N];
    }
}
