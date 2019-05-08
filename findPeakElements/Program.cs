public class Solution {
    public int FindPeakElement(int[] nums) {
        int left = 0, right = nums.Length - 1;
        // binary search
        // just need to find one of peak elements
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (nums[mid] < nums[mid + 1]) left = mid + 1;
            else right = mid;
        }
        return right;
    }
}
