public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        if (n == 0) return 0;
        if (n == 1) return nums[0];
        return Math.Max(Helper(nums, 0, n - 1), Helper(nums, 1, n));
    }
    int Helper(int[] nums, int left, int right) {
        int rob = 0, notRob = 0;
        for (int i = left; i < right; ++i) {
            int preRob = rob, preNotRob = notRob;
            rob = preNotRob + nums[i];
            notRob = Math.Max(preRob, preNotRob);
        }
        return Math.Max(rob, notRob);
    }
}
