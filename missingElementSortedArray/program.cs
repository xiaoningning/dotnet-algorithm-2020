public class Solution {
    public int MissingElement(int[] nums, int k) {
        int l = 0, r = nums.Length;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (nums[0] + m + k <= nums[m]) r = m;
            else l = m + 1;
        }
        // O(logn)
        // k is outside nums.last()
        // -1 since l = 0
        return nums[0] + l + k - 1;
    }
    
    public int MissingElement1(int[] nums, int k) {
        int low = nums[0], i = 1;
        while (i < nums.Length) {
            if (k == 0) return low;
            if (nums[i] != ++low) k--;
            else i++;
        }
        // O(n) TLE
        return low + k;
    }
}
