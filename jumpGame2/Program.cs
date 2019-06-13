public class Solution {
    public int Jump(int[] nums) {
        int n = nums.Length, res = 0, cur = 0, i = 0;
        while (cur < n - 1) {
            res++;
            int pre = cur;
            for (; i <= pre; i++) {
                cur = Math.Max(cur, i + nums[i]);
            }
            // could not reach the last
            if (pre == cur) retur -1;
        }
        return res;
    }
}
