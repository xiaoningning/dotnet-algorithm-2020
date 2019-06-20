public class Solution {
    public int FindPeakElement(int[] nums) {
        // right must be nums.Length - 1
        // otherwise mid+1 will out of index
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
