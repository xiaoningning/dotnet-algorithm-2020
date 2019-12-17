public class Solution {
    public bool IsGoodArray(int[] nums) {
        // all positive nums
        // If x > 1, making it impossible pa + qb = 1.
        int res = nums[0];
        foreach (int a in nums) {
            res = gcd(res, a);
        }
        // O(n) since gcd is O(logmin(a,b)) and res == 1 then O(1)
        // there is an upper limit of nums[i]
        // 1 <= nums[i] <= 10^9 O(log(10^9)) => O(30) => O(1)
        return res == 1;
    }
    int gcd(int a, int b) {
        return (b == 0) ? a : gcd(b, a % b);
    }
}
