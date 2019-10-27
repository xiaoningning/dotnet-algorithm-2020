public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        if (k <= 1) return 0;
        int n = nums.Length;
        int prod = 1, res = 0, left = 0;
        var m = new Dictionary<int, int>();
        for (int i = 0; i < n; i++) {
            prod *= nums[i];
            while (prod >= k) prod /= nums[left++];
            res += i - left + 1;
        }
        return res;
    }
}
