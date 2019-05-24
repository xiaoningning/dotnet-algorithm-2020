public class Solution {
    public int MaxSubArray1(int[] nums) {
        int res = Int32.MinValue, curSum = 0;
        foreach (int n in nums) {
            curSum = Math.Max(curSum + n, n);
            res = Math.Max(res, curSum);
        }
        return res;
    }
    public int MaxSubArray(int[] nums) {
        int n = nums.Length;
        //dp[i] means the maximum subarray ending with nums[i];
        int[] dp = new int[n]; 
        dp[0] = nums[0];
        int max = dp[0];
        
        for(int i = 1; i < n; i++){
            dp[i] = nums[i] + (dp[i - 1] > 0 ? dp[i - 1] : 0);
            max = Math.Max(max, dp[i]);
        }
        return max;
    }
}
