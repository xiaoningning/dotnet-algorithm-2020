public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int res = 0, sum = 0;
        foreach (int num in nums) {
            // if 0, sum reset to 0
            sum = (sum + num) * num;
            res = Math.Max(res, sum);
        }
        return res;
    }
}
