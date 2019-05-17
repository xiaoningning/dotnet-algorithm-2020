public class Solution {
    public int MaxProduct1(int[] nums) {
        int max = nums[0], min = nums[0];
        // negative num case :[-2]
        int res = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] < 0) {
                int t = min;
                min = max;
                max = t;
            }
            max = Math.Max(max * nums[i], nums[i]);
            min = Math.Min(min * nums[i], nums[i]);
            res = Math.Max(max, res);
        }
        return res;
    }
    public int MaxProduct(int[] nums) {
        int res = nums[0], prod = 1, n = nums.Length;
        for (int i = 0; i < n; ++i) {
            res = Math.Max(res, prod *= nums[i]);
            if (nums[i] == 0) prod = 1;
        }
        prod = 1;
        // [-1,-2,-3]
        for (int i = n - 1; i >= 0; --i) {
            res = Math.Max(res, prod *= nums[i]);
            if (nums[i] == 0) prod = 1;
        }
        return res;
    }
}
