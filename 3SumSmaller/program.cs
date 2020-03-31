public class Solution {
    public int ThreeSumSmaller(int[] nums, int target) {
        int res = 0, n = nums.Length;
        if (n < 3) return res;
        Array.Sort(nums);
        for (int i = 0; i < n - 2; i++) {
            int left = i + 1, right = n - 1;
            while (left < right) {
                if (nums[i] + nums[left] + nums[right] < target) {
                    res += right - left;
                    left++;
                }
                else right--;
            }
        }
        return res;
    }
}
