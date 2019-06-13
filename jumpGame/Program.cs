public class Solution {
    public bool CanJump(int[] nums) {
        int n = nums.Length, reach = 0;
        for (int i = 0; i < n; ++i) {
            // if i > reach, it can not jump to i
            // if reach >= n -1, it already jump to the last
            if (i > reach || reach >= n - 1) break;
            reach = Math.Max(reach, i + nums[i]);
        }
        return reach >= n - 1;
    }
}
