public class Solution {
    public int MinMoves2(int[] nums) {
        // distance of two nums = # of moves
        int res = 0, i = 0, j = nums.Length - 1;
        Array.Sort(nums);
        while (i < j) {
            res += nums[j--] - nums[i++];
        }
        return res;
    }
}
