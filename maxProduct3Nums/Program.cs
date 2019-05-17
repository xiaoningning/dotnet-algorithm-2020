public class Solution {
    public int MaximumProduct(int[] nums) {
        int n = nums.Length;
        Array.Sort(nums);
        // -2,-1,0,1
        int p = nums[0] * nums[1] * nums[n - 1];
        // 1,2,3,4
        // -4,-3,-2,-1
        return Math.Max(p, nums[n - 1] * nums[n - 2] * nums[n - 3]);
    }
}
