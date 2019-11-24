public class Solution {
    public int ThreeSumMulti(int[] A, int target) {
        long res = 0, M = (long)(1e9 + 7);
        int n = A.Length;
        Array.Sort(A);
        for (int i = 0; i < n - 2; ++i) {
            int sum = target - A[i];
            int j = i + 1, k = n - 1;
            while (j < k) {
                if (A[j] + A[k] < sum)  ++j;
                else if (A[j] + A[k] > sum) --k;
                else {
                    // duplicates
                    int left = 1, right = 1;
                    while (j + left < k && A[j + left] == A[j]) ++left;
                    while (j + left <= k - right && A[k - right] == A[k]) ++right;
                    res += A[j] == A[k] ? (k - j + 1) * (k - j) / 2 : left * right;
                    j += left;
                    k -= right;
                }
            }
        }
        return (int)(res % M);
    }
    // TLE
    public int ThreeSumMulti2(int[] A, int target) {
        long res = 0, n = A.Length, M = (int)(1e9 + 7);
        // res is large, => use log
        var numCnt = new Dictionary<int, long>();
        for (int i = 0; i < n; ++i) {
            res = (res + numCnt.GetValueOrDefault(target - A[i],0)) % M;
            for (int j = 0; j < i; ++j) {
                int sum = A[i] + A[j];
                if (!numCnt.ContainsKey(sum)) numCnt.Add(sum, 0);
                numCnt[sum]++;
            }
        }
        return (int)res;
    }
    // DP
    public int ThreeSumMulti1(int[] A, int target) {
        int n = A.Length, M = (int)(1e9 + 7);
        int[,,] dp = new int[n+1, target+1, 4];
        for (int i = 0; i <= n; i++) dp[i,0,0] = 1;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= target; ++j) {
                for (int k = 1; k <= 3; ++k) {
                    dp[i,j,k] = (dp[i,j,k] + dp[i - 1,j,k]) % M;
                    if (j >= A[i - 1]) {
                        dp[i,j,k] = (dp[i,j,k] + dp[i - 1,j - A[i - 1],k - 1]) % M;
                    }
                }
            }
        }
        return dp[n,target,3];
    }
}
