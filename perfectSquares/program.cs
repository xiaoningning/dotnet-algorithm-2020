public class Solution {
    public int NumSquares1(int n) {
        var dp = new int[n + 1];
        Array.Fill(dp, Int32.MaxValue);
        dp[0] = 0;
        for (int i = 0; i <= n; ++i) {
            for (int j = 1; i + j * j <= n; ++j) {
                dp[i + j * j] = Math.Min(dp[i + j * j], dp[i] + 1);
            }
        }
        return dp[n];
    }
    // 1, 4, 9, 16 ...
    public int NumSquares(int n) {
        while (n % 4 == 0) n /= 4;
        // 4+1+1+1
        if (n % 8 == 7) return 4;
        for (int a = 0; a * a <= n; ++a) {
            int b = (int) Math.Sqrt(n - a * a);
            if (a * a + b * b == n) {
                return a != 0 && b != 0 ? 2 : 1;
            }
        }
        // 4+1+1
        return 3;
    }
}
