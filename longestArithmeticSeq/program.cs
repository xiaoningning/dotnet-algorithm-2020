public class Solution {
    public int LongestArithSeqLength(int[] A) {
        int res = 2; // min 2 if A.Length == 2
        // key: diff, val: <idx, len>
        var dp = new Dictionary<int, Dictionary<int, int>>();
        for (int i = 0; i < A.Length; i++) {
            for (int j =  i + 1; j < A.Length; j++) {
                int d = A[j] - A[i];
                if (!dp.ContainsKey(d)) dp[d] = new Dictionary<int, int>();
                if (dp[d].ContainsKey(i)) dp[d][j] = dp[d][i] + 1; 
                else dp[d][j] = 2;
                res = Math.Max(res, dp[d][j]);
            }
        }
        return res;
    }
}
