public class Solution {
    public int TriangleNumber(int[] nums) {
        Array.Sort(nums);
        int n = nums.Length, res = 0;
        for (int i = n - 1; i >= 2; i--) {
            int left = 0, right = i - 1;
            while (left < right) {
                // triangle
                if (nums[left] + nums[right] > nums[i]) {
                    res += right - left;
                    right--;
                }
                else left++;
            }
        }
        return res;
    }
}
