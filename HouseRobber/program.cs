public class Solution {
    public int Rob(int[] nums) {
        if (!nums.Any()) return 0;
        int n = nums.Length;
        var dp = new int[n];
        for (int i = 0; i < n; i++) {
            dp[i] = Math.Max((i > 1 ? dp[i - 2] : 0) + nums[i], i > 0 ? dp[i - 1] : 0);
        }
        return dp.Last();
    }
}
