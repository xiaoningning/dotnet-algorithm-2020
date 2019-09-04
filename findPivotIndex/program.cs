public class Solution {
    public int PivotIndex(int[] nums) {
        int sum = nums.Sum();
        int curSum = 0, n = nums.Length;
        for (int i = 0; i < n; ++i) {
            // the pivot index
            if (sum - nums[i] == 2 * curSum) return i;
            curSum += nums[i];
        }
        return -1;
    }
}
