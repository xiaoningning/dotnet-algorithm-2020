public class Solution {
    public int FindMin(int[] nums) {
        int l = 0, r = nums.Length - 1;
        while (l < r) {
            if (nums[l] < nums[r]) return nums[l];
            int m = l + (r - l) / 2;
            // rotated
            if (nums[m] > nums[r]) l = m + 1;
            else r = m;
        }
        return nums[l];
    }
}
