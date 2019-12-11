public class Solution {
    public bool IsMajorityElement(int[] nums, int target) {
        int l = 0, r = nums.Length;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (nums[m] < target) l = m + 1;
            else r = m;
        }
        int first = l; 
        int last = first + nums.Length / 2;
        return last < nums.Length && nums[last] == target ;        
    }
}
