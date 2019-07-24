public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int res = 0, sum = 0, cur = 0;
        foreach (int n in nums) {
            sum += n;
            // cur: flip 0 sum
            if (n == 0) cur = sum + 1;
            sum *= n; // if 0, reset sum
            // current sum + cur (flip 0 sum)
            res = Math.Max(res, cur + sum);
        }
        return res;
    }
}
