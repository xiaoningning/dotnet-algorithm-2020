public class Solution {
    int[,] m;
    public int MaxCoins(int[] nums) {
        int n = nums.Length;
        var l = nums.ToList();
        // 1 to boarder for calculation
        l.Insert(0, 1);
        l.Add(1);
        m = new int[n+2, n+2];
        return helper(l, 1, n);
    }
    int helper(List<int> nums, int i, int j) {
        if (i > j) return 0;
        if (m[i,j] != 0) return m[i,j];
        int res = 0;
        for (int k = i; k <= j; k++)
            res = Math.Max(res, nums[i-1]*nums[k]*nums[j+1] + helper(nums, i, k-1) + helper(nums, k+1, j));       
        return m[i,j] = res;
    }
    public int MaxCoins1(int[] nums) {
        int n = nums.Length;
        var l = nums.ToList();
        // 1 to boarder for calculation
        l.Insert(0, 1);
        l.Add(1);
        var dp = new int[n + 2, n + 2];
        for (int len = 1; len <= n; ++len) {
            // burst 1, then burst 2...
            for (int i = 1; i + len <= n + 1; ++i) {
                int j = i + len - 1;
                for (int k = i; k <= j; ++k) {
                    // i,j is len, if len > 1, k neighbors are bursted already
                    // => nums[i - 1] * nums[k] * nums[j + 1]
                    dp[i,j] = Math.Max(dp[i,j], l[i - 1] * l[k] * l[j + 1] + dp[i,k - 1] + dp[k + 1,j]);
                }
            }
        }
        return dp[1,n];
    }
}
