public class Solution {
    public IList<int> CheapestJump(int[] A, int B) {
        var res = new List<int>();
        if (!A.Any() || A.Last() == -1) return res;
        int n = A.Length;
        int[] dp = new int[n], pos = new int[n];
        Array.Fill(pos, -1);
        Array.Fill(dp, Int32.MaxValue);
        dp[n - 1] = A[n - 1];
        for (int i = n - 2; i >= 0; --i) {
            if (A[i] == -1) continue;
            for (int j = i + 1; j <= Math.Min(i + B, n - 1); ++j) {
                if (dp[j] == Int32.MaxValue) continue;
                if (A[i] + dp[j] < dp[i]) {
                    dp[i] = A[i] + dp[j];
                    pos[i] = j;
                }
            }
        }
        if (dp[0] == Int32.MaxValue) return res;
        for (int cur = 0; cur != -1; cur = pos[cur]) {
            res.Add(cur + 1);
        }
        return res;
    }
}
