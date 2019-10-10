public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        var res = new int[2]{-1,-1};
        if (nums.Length == 0)  return res;
        int left = 0, right = nums.Length -1;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target) left = mid + 1;
            else right = mid;
        }
        if (right == nums.Length || nums[right] != target) return res;
        res[0] = right;
        // search the last index
        // it can be at the border.
        right = nums.Length;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (nums[mid] <= target) left = mid + 1;
            else right = mid;
        }
        // in case: [1], [2,2]
        res[1] = right - 1;
        return res;
    }
}
