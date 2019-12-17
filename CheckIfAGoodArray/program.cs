public class Solution {
    public bool IsGoodArray(int[] nums) {
        int res = nums[0];
        foreach (int a in nums) {
            res = gcd(res, a);
        }
        return res == 1;
    }
    int gcd(int a, int b) {
        return (b == 0) ? a : gcd(b, a % b);
    }
}
