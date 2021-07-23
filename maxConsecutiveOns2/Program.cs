public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int res = 0, right = 0, left = 0, cnt0 = 0, n = nums.Length;
        while (right < n) {
            if (nums[right] == 0) cnt0++;
            while (cnt0 == 2) {
                res = Math.Max(res, right - left);
                if (nums[left++] == 0) cnt0--;
            }
            right++;
        }
        // case: only < 1 zero 
        if (cnt0 < 2) res = Math.Max(res, right - left);
        return res;
    }
    
    public int FindMaxConsecutiveOnes1(int[] nums) {
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
