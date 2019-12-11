public class Solution {
    public int Jump(int[] nums) { 
        int n = nums.Length, res = 0, cur = 0, pre = 0;
        // only check till n - 2 if it can reach n - 1
        for (int i = 0; i < n - 1; i++) {
            cur = Math.Max(cur, i + nums[i]);
            if (i == pre) {
                pre = cur;
                res++;
                // reach n-1 for min steps
                if (cur >= n - 1) break;
            }
        }
        return res;
    }
    
    public int Jump1(int[] nums) {
        int n = nums.Length, res = 0, cur = 0, i = 0;
        // only check till n - 2 if it can reach n - 1
        while (cur < n - 1) {
            res++;
            int pre = cur;
            for (; i <= pre; i++) {
                cur = Math.Max(cur, i + nums[i]);
            }
            // could not reach the last
            if (pre == cur) return -1;
        }
        return res;
    }
}
