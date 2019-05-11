public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int res = 0, cnt = 0;
        foreach (int num in nums) {
            cnt = (num == 0) ? 0 : cnt + 1;
            res = Math.Max(res, cnt);
        }
        return res;
    }
}
