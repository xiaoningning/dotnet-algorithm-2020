public class Solution {
    public int MajorityElement(int[] nums) {
        int res = 0, cnt = 0;
        foreach (int n in nums) {
            if (cnt == 0) res = n;
            // # of majority n > nums.Length / 2
            cnt += res == n ? 1 : -1; 
        }
        return res;
    }
}
