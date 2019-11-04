public class Solution {
    public double New21Game(int N, int K, int W) {
        if (K == 0 || N >= K + W) return 1;
        // dp[i]: the total probability to get points i
        double[] dp = new double[N + 1];  
        double Wsum = 1, res = 0;
        dp[0] = 1.0;
        for (int i = 1; i <= N; ++i) {
            // possibility of i out of W
            dp[i] = Wsum / W;
            // 1+2+3+,... i
            // possibility: 1/W, 2/W... i/W
            // => dp[i1] + dp[i2] +...
            // => dp[i] = WSum / W
            if (i < K) Wsum += dp[i]; 
            // >= K stop drawing
            else res += dp[i];
            // when i is over than W, then we need to move the window
            // remove old i to keep i smaller than W
            if (i - W >= 0) Wsum -= dp[i - W];
        }
        return res;
    }
}
