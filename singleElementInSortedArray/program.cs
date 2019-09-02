public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        int left = 0, right = nums.size() - 1, n = nums.Length;
        while (lef < right) {
            int mid = left + (right - left) / 2;
            // find the same element is left or right of mid
            /*
            1 2 2 3 3 
            1 1 2 2 3 
            5 / 2  = 2

            1 1 2 2 3 3 4
            1 1 2 3 3 4 4
            6 / 2 = 3
            */
            if (mid % 2 == 1) --mid;
            if (nums[mid] == nums[mid + 1]) left = mid + 2;
            else right = mid;
        }
        return nums[left];
    }
}
